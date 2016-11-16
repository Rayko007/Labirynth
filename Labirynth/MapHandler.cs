using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labirynth
{
    /// <summary>
    /// http://www.csharpprogramming.tips/2013/07/Rouge-like-dungeon-generation.html
    /// 
    /// With tuning for the project.
    /// </summary>
    public class MapHandler
    {
        Random rand;

        public Dictionary<Point, Area> Map;

        public int MapWidth { get; set; }
        public int MapHeight { get; set; }
        public int PercentAreWalls { get; set; }

        public void MakeCaverns()
        {
            // By initilizing column in the outter loop, its only created ONCE
            for (int column = 0, row = 0; row <= MapHeight - 1; row++)
            {
                for (column = 0; column <= MapWidth - 1; column++)
                {
                    Map[new Point(column, row)] = PlaceWallLogic(column, row);
                }
            }
        }

        public Area PlaceWallLogic(int x, int y)
        {
            int numWalls = GetAdjacentWalls(x, y, 1, 1);
            Point p = new Point(x, y);

            if (Map[p].Blocked)
            {
                if (numWalls >= 4)
                {
                    return new Area(p, true);
                }
                if (numWalls < 4)
                {
                    return new Area(p, friction: 1.0f * rand.Next(1000) / 1000);
                }

            }
            else
            {
                if (numWalls >= 8)
                {
                    return new Area(p, true);
                }
            }
            return new Area(p, friction: 1.0f * rand.Next(1000) / 1000);
        }

        public int GetAdjacentWalls(int x, int y, int scopeX, int scopeY)
        {
            int startX = x - scopeX;
            int startY = y - scopeY;
            int endX = x + scopeX;
            int endY = y + scopeY;

            int iX = startX;
            int iY = startY;

            int wallCounter = 0;

            for (iY = startY; iY <= endY; iY++)
            {
                for (iX = startX; iX <= endX; iX++)
                {
                    if (!(iX == x && iY == y))
                    {
                        if (IsWall(iX, iY))
                        {
                            wallCounter += 1;
                        }
                    }
                }
            }
            return wallCounter;
        }

        bool IsWall(int x, int y)
        {
            Point p = new Point(x, y);
            // Consider out-of-bound a wall
            if (IsOutOfBounds(x, y))
            {
                return true;
            }

            if (Map[p].Blocked)
            {
                return true;
            }
            
            return false;
        }

        bool IsOutOfBounds(int x, int y)
        {
            if (x < 0 || y < 0)
            {
                return true;
            }
            else if (x > MapWidth - 1 || y > MapHeight - 1)
            {
                return true;
            }
            return false;
        }
        
        public void BlankMap()
        {
            for (int column = 0, row = 0; row < MapHeight; row++)
            {
                for (column = 0; column < MapWidth; column++)
                {
                    Point p = new Point(row, column);
                    Map[p] = new Area(p);
                }
            }
        }

        public void RandomFillMap()
        {
            
            int mapMiddle = 0; // Temp variable
            for (int column = 0, row = 0; row < MapHeight; row++)
            {
                for (column = 0; column < MapWidth; column++)
                {
                    Point p = new Point(column, row);
                    // If coordinants lie on the the edge of the map (creates a border)
                    if (column == 0)
                    {
                        Map[p] = new Area(p, true);
                    }
                    else if (row == 0)
                    {
                        Map[p] = new Area(p, true);
                    }
                    else if (column == MapWidth - 1)
                    {
                        Map[p] = new Area(p, true);
                    }
                    else if (row == MapHeight - 1)
                    {
                        Map[p] = new Area(p, true);
                    }
                    // Else, fill with a wall a random percent of the time
                    else
                    {
                        mapMiddle = (MapHeight / 2);

                        if (row == mapMiddle)
                        {
                            Map[p] = new Area(p, friction: 1.0f * rand.Next(1000)/1000);
                        }
                        else
                        {
                            Map[p] = RandomPercent(p, PercentAreWalls);
                        }
                    }
                }
            }
        }
        
        Area RandomPercent(Point pos, int percent)
        {
            if (percent >= rand.Next(1, 101))
            {
                return new Area(pos, true);
            }
            return new Area(pos, friction: 1.0f * rand.Next(1000) / 1000);
        }

        public MapHandler(int mapWidth, int mapHeight, Dictionary<Point, Area> map, int seed, int percentWalls = 40)
        {
            this.MapWidth = mapWidth;
            this.MapHeight = mapHeight;
            this.PercentAreWalls = percentWalls;
            this.Map = map;
            this.rand = new Random(seed);
        }
    }

    /// <summary>
    /// https://habrahabr.ru/post/262345/
    /// C# realisation of ^
    /// </summary>
    class AltMapHandler
    {
        Random rand;

        public Dictionary<Point, Area> Map;

        public int MapWidth { get; set; }
        public int MapHeight { get; set; }

        List<Area> unvisited;

        public AltMapHandler(int width, int height, Dictionary<Point, Area> map, int seed)
        {
            MapWidth = width;
            MapHeight = height;
            Map = map;
            rand = new Random(seed);
            unvisited = new List<Area>();
        }

        public void FillWorld()
        {
            Map.Clear();
            for (int i = 0; i < MapWidth; i++)
                for (int j = 0; j < MapHeight; j++)
                {
                    Point p = new Point(i, j);
                    if (i == 0 || i == MapWidth - 1)
                    {
                        Area a = new Area(p, true);
                        Map.Add(p, a);
                        continue;
                    }
                    if (j == 0 || j == MapHeight - 1)
                    {
                        Area a = new Area(p, true);
                        Map.Add(p, a);
                        continue;
                    }
                    if (i % 2 != 0 & j % 2 != 0)
                    {
                        Area a = new Area(p);
                        Map.Add(p, a);
                    }
                    else
                    {
                        Area a = new Area(p, true);
                        Map.Add(p, a);
                    }
                }

            if (MapWidth < 3 || MapHeight < 3)
                return;

            Stack<Area> stack = new Stack<Area>();
            Area startArea = Map[new Point(1, 1)];
            Area currentArea = startArea;
            Area neighbourArea;

            foreach (Area a in Map.Values)
                if (!a.Blocked)
                    unvisited.Add(a);
            do
            {
                List<Area> neighbours = GetNeighbours(currentArea.Position);
                if (neighbours.Any())
                {
                    int randomNumber = rand.Next(0, neighbours.Count);
                    neighbourArea = neighbours[randomNumber];
                    Point p = new Point((int)Math.Abs((currentArea.Position.X + neighbourArea.Position.X) / 2),
                                        (int)Math.Abs((currentArea.Position.Y + neighbourArea.Position.Y) / 2));
                    Map[p].Blocked = false;

                    unvisited.Remove(currentArea);
                    stack.Push(currentArea);
                    currentArea = neighbourArea;
                }
                else
                {
                    unvisited.Remove(currentArea);
                    if (stack.Any())
                        currentArea = stack.Pop();
                }
            }
            while (unvisited.Count > 0);

            foreach (Area a in Map.Values)
                if (!a.Blocked)
                    a.Friction = rand.Next(1001) / 1000f;
        }

        List<Area> GetNeighbours(Point loc)
        {
            List<Area> res = new List<Area>();

            List<Point> Keys = new List<Point>();
            Keys.Add(new Point(loc.X, loc.Y + 2));
            Keys.Add(new Point(loc.X, loc.Y - 2));
            Keys.Add(new Point(loc.X - 2, loc.Y));
            Keys.Add(new Point(loc.X + 2, loc.Y));
 
            if (loc.X > 0 && loc.Y > 0 && loc.X < MapWidth - 1 && loc.Y < MapHeight - 1)
            {
                foreach (Point p in Keys)
                    if (Map.Keys.Contains(p))
                        if (unvisited.Contains(Map[p]))
                            res.Add(Map[p]);
            }
            return res;
        }
    }
}
