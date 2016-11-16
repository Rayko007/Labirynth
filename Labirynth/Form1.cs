using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;

namespace Labirynth
{
    /// <summary>
    /// Form1: contains only initialization and interface features, event handlers.
    /// </summary>
    public partial class ProjectManager : Form
    {
        public Dictionary<Point, Area> Map;
        public List<Item> ItemContainer;
        public List<Area> Selection;

        public StatusStrip MainStatusStrip;
        public RichTextBox LogWindow;
        public Logger iLogger;
        public Point MouseLocation;

        public ProjectManager()
        {
            InitializeComponent();

            WorldViewport.Image = new Bitmap(WorldViewport.Width, WorldViewport.Height);

            typeBox.DropDownStyle = ComboBoxStyle.DropDownList;
            MainStatusStrip = statusStrip1;
            LogWindow = richTextBox1;
            iLogger = new Logger(this);

            Selection = new List<Area>();
            Agents = new List<Agent>();
            Map = new Dictionary<Point, Area>();
            ItemContainer = new List<Item>();

            //Default setup
            CreateWorld(15, 15, "Random");
            AddItem(new Agent(new Point(1, 1)));
            AddItem(new Flag(new Point(13, 13)));
            Render();

            this.Select();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = Application.StartupPath;
            sfd.Filter = "XML Files | *.xml";
            sfd.DefaultExt = "xml";
            if (DialogResult.OK == sfd.ShowDialog())
            {
                SaveMap(sfd.FileName);
            }

            iLogger.Push(String.Format("World has been saved."));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Application.StartupPath;
            ofd.Filter = "XML Files | *.xml";
            ofd.DefaultExt = "xml";
            if (DialogResult.OK == ofd.ShowDialog())
                LoadMap(ofd.FileName);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            WorldViewport.Size = new Size((int)(AreaSize * WorldSize.X), (int)(AreaSize * WorldSize.Y));
            WorldViewport.Image.Dispose();
            WorldViewport.Image = new Bitmap(WorldViewport.Size.Width, WorldViewport.Size.Height);
            Render();
        }

        private void world_view_DragDrop(object sender, DragEventArgs e)
        {

        }

        private void world_view_MouseDown(object sender, MouseEventArgs e)
        {
            MouseLocation = e.Location;
            if (e.Button == MouseButtons.Left)
            {
                Point coordinate;
                if (sender == WorldViewport)
                    coordinate = GetCoordinateFromPicture(e.Location);
                else
                {
                    Point p = new Point();
                    p.X = e.Location.X - WorldViewport.Location.X;
                    p.Y = e.Location.Y - WorldViewport.Location.Y;
                    coordinate = GetCoordinateFromPicture(p);
                }

                Map[coordinate].Selected = true != Map[coordinate].Selected;
                if (Map[coordinate].Selected)
                    Selection.Add(Map[coordinate]);
                else
                    Selection.Remove(Map[coordinate]);
                Render();
            }
        }

        private void world_view_MouseUp(object sender, MouseEventArgs e)
        {
            MouseLocation = e.Location;
        }

        private void world_view_MouseMove(object sender, MouseEventArgs e)
        {
            Point Delta = new Point(e.Location.X - MouseLocation.X, e.Location.Y - MouseLocation.Y);
            if (e.Button == MouseButtons.Middle)
            {
                Point newLocation = new Point(WorldViewport.Location.X + Delta.X,
                                                WorldViewport.Location.Y + Delta.Y);
                Point limit1 = new Point(WorldViewport.Parent.Size.Width / 2, WorldViewport.Parent.Size.Height / 2);
                Point limit2 = new Point(limit1.X - WorldViewport.Size.Width, limit1.Y - WorldViewport.Size.Height);
                WorldViewport.Location = SaturatePoint(newLocation, limit1, limit2);
                WorldViewport.Update();
            }
            if (e.Button == MouseButtons.Left)
            {
                Point p1 = GetCoordinateFromPicture(e.Location);
                Point p2 = GetCoordinateFromPicture(MouseLocation);
                if (Map[p1].Selected != Map[p2].Selected)
                {
                    Map[p1].Selected = Map[p2].Selected;

                    if (Map[p1].Selected)
                        Selection.Add(Map[p1]);
                    else
                        Selection.Remove(Map[p1]);

                    Render(p1);
                }
            }
            if (((Control)sender) != WorldViewport && ((Control)sender).Parent != WorldViewport)
                MouseLocation = e.Location;
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            WorldViewport.Location = new Point(0, 0);
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            List<Control> movables = new List<Control>();

            foreach (Control c in vScrollBar1.Parent.Controls)
                if (c != vScrollBar1)
                    movables.Add(c);

            foreach (Control c in movables)
            {
                c.Location = new Point(c.Location.X, c.Location.Y - (e.NewValue - e.OldValue));
                c.Update();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CreateWorld((int)widthNumeric.Value, (int)heightNumeric.Value, typeBox.Text);
            Render();
            trackBar1.Maximum = Math.Max(WorldSize.X, WorldSize.Y);
        }

        private void button_Assert_Click(object sender, EventArgs e)
        {
            
            foreach (Area p in Selection)
            {
                p.Friction = (float)numericUpDown_Friction.Value;
                p.Blocked = checkBox_IsBlocked.Checked;
            }
            Render();
        }

        private void ProjectManager_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                iLogger.Push("You pressed Enter");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Add_Item form = new Add_Item(this);
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                timer1.Enabled = false;
                button3.Text = "Start simulation";
            }
            else
            {
                timer1.Enabled = true;
                button3.Text = "Stop simulation";
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Show();
        }

        private void ProjectManager_Resize(object sender, EventArgs e)
        {

            int distance = 20;
            int distanceBetween = 5;

            panel4.Location = new Point(this.Width - distance - panel4.Width, panel4.Location.Y);

            int sizeV = MainStatusStrip.Location.Y - 15;
            int sizeH = panel4.Location.X - distanceBetween - panel1.Location.X;
            int size = (int)Math.Min(sizeV, sizeH);
            panel1.Size = new Size(size, size);


            WorldViewport.Size = new Size((int)(AreaSize * WorldSize.X), (int)(AreaSize * WorldSize.Y));
            WorldViewport.Image.Dispose();
            WorldViewport.Image = new Bitmap(WorldViewport.Size.Width, WorldViewport.Size.Height);
            Render();
        }

        private void ProjectManager_ResizeEnd(object sender, EventArgs e)
        {

        }
    }

}
