using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem
{
    public struct Location
    {
        int x, y;

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public int X
        {
            get { return x; }
            set { x = value; }
        }
    }
    public static class DarkKnight
    {
        #region YOUR CODE IS HERE
        //Your Code is Here:
        //==================
        /// <summary>
        /// Given the dimention of the board and the current location of the DarkKnight, calculate the min number of moves to reach the given target or return -1 if can't be reach ed
        /// </summary>
        /// <param name="N">board dimension</param>
        /// <param name="src">current location of the DarkKnight</param>
        /// <param name="target">target location</param>
        /// <returns>min number of moves to reach the target OR -1 if can't reach the target</returns>
        public static int Equal(Location source, Location destintion)
        {
            int Result = 0;
            if (source.X == destintion.X && source.Y == destintion.Y)
                Result = 0;
            return Result;
        }
        public static int Sub_Equal(Location source, Location destintion)
        {
            int Result = 0;
            if ((source.X - destintion.X) == (source.Y - destintion.Y))
                Result= source.X - destintion.X;

            return Result;
        }
        public static int less(Location source, Location destintion)
        {
            int Result = 0;
            if (source.X < destintion.X)
                return destintion.X - source.X;
            return Result;
        }
        public static int more(Location source, Location destintion)
        {
            int Result = 0;
            if (source.X > destintion.X)
                return (destintion.X - source.X)*-1;
            return Result;
        }
        public static void Check(int N, Queue<Location> q, bool[,] gone, int x, int y, int m)
        {
            if (x > 0 && x <= N && y > 0 && y <= N && !gone[x - 1, y - 1])
            {
                q.Enqueue(new Location { X = x, Y = y });
                gone[x - 1, y - 1] = true;
            }
        }
        public static int Valid(Location source, Location destintion, int size_new, bool[,] gone) 
        {
            Queue<Location> q = new Queue<Location>();
            q.Enqueue(source);

            int m = 0;
            int r = 0;
            while (q.Count > 0)
            {
                int count = q.Count;
                for (int i = 0; i < count; i++)
                {
                    Location c = q.Dequeue();

                    if (c.X == destintion.X && c.Y == destintion.Y)
                    {
                        
                        return m;
                        
                        
                    }            
                    Check(size_new, q, gone, c.X - 2, c.Y - 1, m + 1);
                    Check(size_new, q, gone, c.X - 2, c.Y + 1, m + 1);
                    Check(size_new, q, gone, c.X - 1, c.Y, m + 1);
                    Check(size_new, q, gone, c.X - 1, c.Y - 2, m + 1);
                    Check(size_new, q, gone, c.X - 1, c.Y + 2, m + 1);
                    Check(size_new, q, gone, c.X, c.Y, m + 1);
                    Check(size_new, q, gone, c.X, c.Y - 1, m + 1);
                    Check(size_new, q, gone, c.X, c.Y + 1, m + 1);
                    Check(size_new, q, gone, c.X + 1, c.Y, m + 1);
                    Check(size_new, q, gone, c.X + 1, c.Y - 2, m + 1);
                    Check(size_new, q, gone, c.X + 1, c.Y + 2, m + 1);
                    Check(size_new, q, gone, c.X + 2, c.Y + 1, m + 1);
                    Check(size_new, q, gone, c.X + 2, c.Y - 1, m + 1);

                }

                m++;
            }

            return r;

        }
        public static int Play(int N, Location src, Location target)
        {
            int size_new = N, new_x = src.X - 1, new_y = src.Y - 1;
            bool[,] gone = new bool[size_new, size_new];
            gone[new_x,new_y] = true;
            if ((src.X - target.X) == (src.Y - target.Y)) return src.X - target.X;
            if (src.X < target.X) return target.X - src.X;
            if (src.X > target.X) return (target.X - src.X) * -1;
            Equal(src, target);          
            Sub_Equal(src, target);         
            less(src, target);
            more(src, target);
            Valid(src, target, size_new, gone);
            return -1;
        }        
            #endregion
    }
}


