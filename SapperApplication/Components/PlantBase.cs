using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SapperApplication.Components
{
    public abstract class PlantBase
    {
        public static int MaxHealth;
        public static int HealthToGrow;
        public int GrownTime { get; set; }
        public TimerCallback GrownTimerCallback;
        public int Health { get; set; }
        public bool IsFistGeneration { get; set; }
        public int Sun { get; set; }
        public Point MyCoordinate;

        public PlantBase(bool isFirstGeneration, Point coord)
        {
            IsFistGeneration = isFirstGeneration;
            MyCoordinate = coord;
        }

        public void Initial()
        {
            GrownTimerCallback = new TimerCallback(GrowUp);
            Timer GrownUpTimer = new Timer(GrownTimerCallback, null, GrownTime, GrownTime);
            Health = MaxHealth/4;
        }
        public int BeEaten(int howMutch)
        {
            if (howMutch < Health)
            {
                return howMutch;
            }
            else return Health;
        }

        public void GrowUp(object Obj)
        {
            Health += Sun;
            if (Health >= HealthToGrow)
            {
                Health = MaxHealth;
                GiveOffspring();
            }
        }

        public void GiveOffspring()
        {
        }

    }

}
