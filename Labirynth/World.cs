using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.IO;

namespace Labirynth
{
    /// <summary>
    /// Here are located Item classes, a Logger class and all custom functions that influence the world.
    /// </summary>
    [DataContract(IsReference = true)]
    public abstract class Item
    {
        [DataMember]
        public Point Position { get; set; }

        [DataMember]
        public List<Item> ItemContainer { get; set; }

        [DataMember]
        public const int ShapeSize = 100;

        [DataMember]
        public string Name;

        protected Item(Point pos)
        {
            Position = pos;
            ItemContainer = new List<Item>();
            Name = "Item " + Position.ToString();
        }
        abstract public void DrawShape(Image target, RectangleF rect);

        protected void DrawInsides(Image target, RectangleF rectangle)
        {
            Graphics g = Graphics.FromImage(target);

            int numInRow;
            for (numInRow = 1; Math.Pow(numInRow, 2) < ItemContainer.Count; numInRow++) ;

            for (int i = 0; i < ItemContainer.Count; i++)
            {
                RectangleF rect = new RectangleF();
                
                rect.Location = new PointF(rectangle.X + rectangle.Width * (i % numInRow) / numInRow,
                                          rectangle.Y + rectangle.Height * (i / numInRow) / numInRow);

                rect.Size = new SizeF(rectangle.Width / numInRow, rectangle.Height / numInRow);

                ItemContainer[i].DrawShape(target, rect);
            }
        }
    }

    [DataContract(IsReference = true)]
    public class Area : Item
    {
        [DataMember]
        private bool _blocked;
        [DataMember]
        private float _friction;
        public bool Blocked
        {
            get
            {
                return _blocked;
            }
            set
            {
                _blocked = value;
            }
        }
        public float Friction
        {
            get
            {
                return _friction;
            }
            set
            {
                _friction = Math.Abs(value);
                if (_friction > 1)
                    _friction /= _friction;
            }
        }
        [DataMember]
        public bool Selected;

        public Area(Point position, bool blocked = false, float friction = 0) : base(position)
        {
            Blocked = blocked;
            Friction = friction;
            Selected = false;
            Name = "Area " + Position.ToString();
        }

        override public void DrawShape(Image target, RectangleF rectangle)
        {
            Graphics g = Graphics.FromImage(target);
            if (Blocked)
            {
                g.FillRectangle(Brushes.Black, rectangle);
            }
            else
            {
                Color c = Color.FromArgb((int)(Friction * 255), Color.DimGray);
                g.FillRectangle(new SolidBrush(c), rectangle);
            }
            if (Selected)
                g.FillRectangle(new SolidBrush(Color.FromArgb(150, Color.Yellow)), rectangle);
            DrawInsides(target, rectangle);
        }

        /*
        override public string ToString()
        {
            if (Blocked)
                return "X" + Environment.NewLine;
            string res = "";
            res += Position.X.ToString() + '\t';
            res += Position.Y.ToString() + '\t';
            res += Friction.ToString("0,000") + '\t';
            foreach (Item i in ItemContainer)
                res += i.ToString() + '\t';
            res += '\n';
            return res;
        }
        */
    }

    [DataContract(IsReference = true)]
    public class Agent : Item
    {
        [DataMember]
        public int Activity; // to measure the progress of current action (0 = completed)
        [DataMember]
        public Action CurrentAction
        {
            get
            {
                return ActionSchedule[0];
            }
            set
            {

            }
        }
        [DataMember]
        public List<Action> ActionSchedule;

        [DataMember]
        Logger rLogger;

        [DataMember]
        public Item Target;

        [DataMember]
        public int GroundDelay;

        [DataMember]
        public float Speed;

        public const int MovementDelay = 100;
        public const int PickupDelay = 200;
        public const int DropDelay = 50;

        public Agent(Point position) : base(position)
        {
            Activity = 0;
            ActionSchedule = new List<Action>();
            ActionSchedule.Add(Action.Idle);
            Target = null;

            rLogger = new Logger();

            Speed = 1;
            GroundDelay = 0;

            Name = "Agent " + Position.ToString();
        }

        override public void DrawShape(Image target, RectangleF rectangle)
        {
            Graphics g = Graphics.FromImage(target);
            RectangleF r = rectangle;
            float shift = r.Width * 0.10f;
            float border = r.Width * 0.05f;
            r.Offset(new PointF(shift, shift));
            r.Width -= 2*shift;
            r.Height -= 2*shift;

            g.FillRectangle(Brushes.Black, r.Location.X, r.Location.Y, 
                                           r.Width, r.Height);
            g.FillRectangle(Brushes.White, r.Location.X + border, r.Location.Y + border,
                                           r.Width - 2*border, r.Height - 2*border);

            DrawInsides(target, r);
        }

        /// <summary>
        /// Basic schedule processing. Was not debugged, might not work.
        /// </summary>
        public void ProcessSchedule()
        {
            if (Activity > 0)
            {
                Activity--;
                return;
            }
            ActionSchedule.RemoveAt(0); //Activity = 0 -> action have been finished
            if (!ActionSchedule.Any())
                ActionSchedule.Add(Action.Idle);

            Action a = ActionSchedule[0];
            switch (a)
            {
                case Action.Idle:
                    break;
                case Action.MoveUp:
                    Activity += (int)(Speed*MovementDelay + GroundDelay);
                    Position.Offset(0, 1);
                    foreach (Item i in ItemContainer)
                        i.Position = Position;
                    break;
                case Action.MoveLeft:
                    Activity += (int)(Speed * MovementDelay + GroundDelay);
                    Position.Offset(-1, 0);
                    foreach (Item i in ItemContainer)
                        i.Position = Position;
                    break;
                case Action.MoveDown:
                    Activity += (int)(Speed * MovementDelay + GroundDelay);
                    Position.Offset(0, -1);
                    foreach (Item i in ItemContainer)
                        i.Position = Position;
                    break;
                case Action.MoveRight:
                    Activity += (int)(Speed * MovementDelay + GroundDelay);
                    Position.Offset(1, 0);
                    foreach (Item i in ItemContainer)
                        i.Position = Position;
                    break;
                case Action.PickUp:
                    if (Target != null)
                        if (Position == Target.Position)
                        {
                            Activity += (int)(Speed * PickupDelay);
                            ItemContainer.Add(Target);
                        }
                        else
                            rLogger.Push("Target is too far, cannot pick up. The action is cancelled.");
                    else
                        rLogger.Push("Have no target. The action is cancelled.");
                    break;
                case Action.Drop:
                    if (Target != null)
                        if (ItemContainer.Contains(Target))
                        {
                            Activity += (int)(Speed * DropDelay);
                            ItemContainer.Remove(Target);
                        }
                        else
                            rLogger.Push("Target is not owned, cannot drop. The action is cancelled.");
                    else
                        rLogger.Push("Have no target.The action is cancelled.");
                    break;

            }
        }
        public enum Action
        {
            Idle,
            MoveUp, MoveLeft, MoveDown, MoveRight,
            PickUp, Drop
        }
    }

    [DataContract(IsReference = true)]
    public class Flag : Item
    {

        public Flag(Point position) : base(position)
        {
            Name = "Flag " + Position.ToString();
        }

        override public void DrawShape(Image target, RectangleF rectangle)
        {
            Graphics g = Graphics.FromImage(target);
            RectangleF r = rectangle;

            Pen p = new Pen(Color.Black, 3);
            g.DrawLine(p, r.X + 0.20f * r.Width, r.Y + 0.10f * r.Height, r.X + 0.20f * r.Width, r.Y + 0.90f * r.Height);
            g.FillRectangle(Brushes.Green, r.X + 0.22f * r.Width, r.Y + 0.15f * r.Height, 0.50f * r.Width, 0.40f * r.Height);
        }
    }

    public partial class ProjectManager
    {
        public Point WorldSize;

        float AreaSize
        {
            get
            {
                return WorldViewport.Parent.Width * 1.0f / trackBar1.Value;
            }
        }

        public void CreateWorld(int width, int height, string type)
        {
            Map.Clear();
            ItemContainer.Clear();

            WorldSize.X = width;
            WorldSize.Y = height;

            for (int i = 0; i < WorldSize.Y; i++)
                for (int j = 0; j < WorldSize.X; j++)
                {
                    Point p = new Point(j, i);
                    bool blkd = type == "Blocked";
                    Map.Add(p, new Area(p, blkd));
                    ItemContainer.Add(Map[p]);
                }

            if (type == "Random")
            {
                //MapHandler gen = new MapHandler(width, height, Map, (int)numeric_Seed.Value, 60);
                //gen.RandomFillMap();
                AltMapHandler gen = new AltMapHandler(width, height, Map, (int)numeric_Seed.Value);
                gen.FillWorld();
            }

            trackBar1.Maximum = Math.Max(width, height);
            trackBar1.Value = trackBar1.Maximum;
            iLogger.Push(String.Format("Created world with size: W{0} H{1}.", WorldSize.X, WorldSize.Y));
        }
        public void CreateWorld(Dictionary<Point, Area> map)
        {
            Map.Clear();
            ItemContainer.Clear();

            Map = map;

            WorldSize = Map.Keys.Last();
            WorldSize.Offset(1, 1); //Because keys start from 0, but size is a count.
            foreach (Item i in Map.Values)
            {
                ItemContainer.Add(i);
                ItemContainer.AddRange(UnwrapItems(i.ItemContainer));
            }

            trackBar1.Maximum = Math.Max(WorldSize.X, WorldSize.Y);
            trackBar1.Value = trackBar1.Maximum;
            iLogger.Push(String.Format("Created world with size: W{0} H{1}.", WorldSize.X, WorldSize.Y));
        }
        public void Render()
        {
            if (!Map.Any())
            {
                iLogger.Push("No world to render.");
                return;
            }

            Graphics g = Graphics.FromImage(WorldViewport.Image);
            g.Clear(Color.White);
            for (int i = 0; i < WorldSize.Y; i++)
                for (int j = 0; j < WorldSize.X; j++)
                {
                    Area a = Map[new Point(j, i)];
                    PointF loc = new PointF(j * AreaSize, (WorldSize.Y - 1 - i) * AreaSize);
                    RectangleF rect = new RectangleF(j * AreaSize, (WorldSize.Y - 1 - i) * AreaSize,
                                                     AreaSize, AreaSize);

                    a.DrawShape(WorldViewport.Image, rect);
                }
            WorldViewport.Refresh();
            //iLogger.Push(String.Format("The world was rendered in \"{0}\" image", WorldViewport.Name));
        }
        public void Render(Point tileLoc)
        {
            if (!Map.Any())
            {
                iLogger.Push("No world to render.");
                return;
            }
            if (!Map.ContainsKey(tileLoc))
            {
                iLogger.Push(String.Format("Point {0} is outside of the world.", tileLoc));
            }

            Graphics g = Graphics.FromImage(WorldViewport.Image);
            Area a = Map[tileLoc];
            PointF loc = new PointF(tileLoc.X * AreaSize, (WorldSize.Y - 1 - tileLoc.Y) * AreaSize);
            RectangleF rect = new RectangleF(tileLoc.X * AreaSize, (WorldSize.Y - 1 - tileLoc.Y) * AreaSize,
                                             AreaSize, AreaSize);
            g.FillRectangle(Brushes.White, rect);
            a.DrawShape(WorldViewport.Image, rect);

            WorldViewport.Refresh();
        }

        /// <summary>
        /// Influences only the selection.
        /// </summary>
        /// <param name="area"></param>
        void ToggleTile(Area area)
        {
            area.Selected = true != area.Selected;

            if (area.Selected)
            {
                Selection.Add(area);
            }
            else
            {
                Selection.Remove(area);
            }
        }

        /// <summary>
        /// Transfers clicked pixel location to the location of the map
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        Point GetCoordinateFromPicture(Point location)
        {
            int X = (location.X);
            int Y = (WorldViewport.Height - location.Y);
            if (X < 0 || X > WorldViewport.Width || Y < 0 || Y > WorldViewport.Height)
            {
                //iLogger.Push("Clicked wrong area.");
                return new Point(0, 0);
            }
            X /= (int)AreaSize;
            Y /= (int)AreaSize;
            //iLogger.Push(String.Format("You clicked tile at X{0} Y{1}", X, Y));
            return new Point(X, Y);

        }

        void SaveMap(string path)
        {
            //http://stackoverflow.com/questions/26733/getting-all-types-that-implement-an-interface
            var type = typeof(Item);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p) && !p.IsInterface);

            DataContractSerializer DCS = new DataContractSerializer(typeof(Dictionary<Point, Area>), types);
            FileStream FS = new FileStream(path, FileMode.Create);
            DCS.WriteObject(FS, Map);
            FS.Close();

        }
        void LoadMap(string path)
        {
            //http://stackoverflow.com/questions/26733/getting-all-types-that-implement-an-interface
            var type = typeof(Item);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p) && !p.IsInterface);


            DataContractSerializer DCS = new DataContractSerializer(typeof(Dictionary<Point, Area>), types);
            FileStream FS = new FileStream(path, FileMode.Open);

            CreateWorld((Dictionary<Point, Area>)DCS.ReadObject(FS));
            FS.Close();
            Render();
        }

        /// <summary>
        /// Adds item to Area on the map. Do not add Areas, pls
        /// </summary>
        /// <param name="item"></param>
        /// <param name="loc"></param>
        public void AddItem(Item item)
        {
            if (Map.ContainsKey(item.Position))
            {
                if (!Map[item.Position].Blocked)
                {
                    Map[item.Position].ItemContainer.Add(item);
                    ItemContainer.Add(item);
                    if (item.GetType() == typeof(Agent))
                        Agents.Add((Agent)item);
                    Render(item.Position);
                }
                else
                {
                    iLogger.Push("Cannot add item to world: area is blocked in " + item.Position.ToString());
                }
            }
            else
            {
                iLogger.Push("Cannot add item to world: wrong location " + item.Position.ToString());
            }
        }
        public void AddItem(Item host, Item guest)
        {
            guest.Position = host.Position;
            host.ItemContainer.Add(guest);
            ItemContainer.Add(guest);
            Render(host.Position);
        }
        /// <summary>
        /// Gets the first object with that name. System has no protection against creation of objects with the same name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Item GetItem(string name)
        {
            Item i = ItemContainer.Find(t => (t.Name == name));
            return i;
        }
        public void RemoveItem(Item item)
        {
            ItemContainer.Remove(item);
            Map[item.Position].ItemContainer.Remove(item);
            if (item.GetType() == typeof(Agent))
                Agents.Remove((Agent)item);
        }
        /// <summary>
        /// Recursive function that creates a list of all objects in the list of items (including those included in included items)
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        List<Item> UnwrapItems(List<Item> items)
        {
            if (!items.Any())
                return new List<Item>();
            List<Item> res1 = new List<Item>();
            foreach (Item i in items)
            {
                res1.Add(i);
                res1.AddRange(UnwrapItems(i.ItemContainer));
            }
            return res1;
        }

        /// <summary>
        /// Keeps target point inside the rectangle pt1-pt2. Order and relative position of pt1 and pt2 do not matter.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="pt1"></param>
        /// <param name="pt2"></param>
        /// <returns></returns>
        Point SaturatePoint(Point target, Point pt1, Point pt2)
        {
            Point res = target;
            Point bottom = pt1;
            Point top = pt2;

            //Checks for inversion of conditions.
            if (pt1.X > pt2.X)
            {
                bottom.X = pt2.X;
                top.X = pt1.Y;
            }
            if (pt1.Y > pt2.Y)
            {
                bottom.Y = pt2.Y;
                top.Y = pt1.Y;
            }

            //Limits target point if necessary.
            if (res.X < bottom.X)
                res.X = bottom.X;
            else if (res.X > top.X)
                res.X = top.X;

            if (res.Y < bottom.Y)
                res.Y = bottom.Y;
            else if (res.Y > top.Y)
                res.Y = top.Y;

            return res;
        }

    }

    /// <summary>
    /// Use it to log, feed a ProjectManager form to receive logs in the RichTextBox of the form.
    /// </summary>
    public class Logger
    {
        public List<string> Log;

        ProjectManager Master;

        public Logger()
        {
            Log = new List<string>();
        }
        public Logger(ProjectManager master)
        {
            Master = master;
            Log = new List<string>();
        }

        public void Push(string text)
        {
            Log.Add(DateTime.Now.ToString("hh:mm:ss") + " | " + text);
            if (Master != null)
            {
                Master.MainStatusStrip.Text = Log[Log.Count - 1];
                Master.LogWindow.Text += Log[Log.Count - 1] + "\n";
                Master.LogWindow.SelectionStart = Master.LogWindow.Text.Length - 1;
                Master.LogWindow.ScrollToCaret();
            }
        }
    }
}
