using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SuperMargalitProj
{
    class Class1
    {
        //public static bool[]  Game = new bool[]{false,false,false,false};
        public static bool[] Game = new bool[] { false, false, false, false };
        public static bool Bots = true;
        public static bool BVoice = false;
        public static double Volume = 1.0;
        public static double brightness = 1850;

        public static void Dir(ref bool DirB, Image Bad, int Left, int Right,int s)
        {
            if (Canvas.GetLeft(Bad) >= Right)
                DirB = false;

            if (DirB)
                Canvas.SetLeft(Bad, Canvas.GetLeft(Bad) + s);
            else
            {
                Canvas.SetLeft(Bad, Canvas.GetLeft(Bad) - s);
                if (Canvas.GetLeft(Bad) <= Left)
                    DirB = true;
            }

        }
    }
}
