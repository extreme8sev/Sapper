#region Usings

using System.Drawing;
using System.Threading;
using SapperApplication.Enums;

#endregion

namespace SapperApplication.Components
{
    public abstract class PlantBase
    {
        #region Public Members

        public TimerCallback GrownTimerCallback;
        public Point MyCoordinate;
        public static int MaxHealth;
        public static int HealthToGrow;

        #endregion

        #region  .ctor

        protected PlantBase(bool isFirstGeneration,
                            Point coord)
        {
            IsFistGeneration = isFirstGeneration;
            MyCoordinate = coord;
        }

        #endregion

        #region  Properties

        public int GrownTime { get; set; }
        public int Health { get; set; }
        public bool IsFistGeneration { get; set; }
        public int Sun { get; set; }

        #endregion

        public abstract PlantTypeEnum PlantType { get; }

        #region  Public Methods

        public void Initial()
        {
            GrownTimerCallback = GrowUp;
            var grownUpTimer = new Timer(GrownTimerCallback,
                                         null,
                                         GrownTime,
                                         GrownTime);
            Health = MaxHealth / 4;
        }

        public int BeEaten(int howMutch)
        {
            if (howMutch < Health)
            {
                return howMutch;
            }

            return Health;
        }

        public void GrowUp(object obj)
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

        #endregion
    }
}