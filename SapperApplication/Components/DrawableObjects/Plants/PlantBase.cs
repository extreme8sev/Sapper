#region Usings

using System.Drawing;
using System.Threading;

#endregion

namespace SapperApplication.Components.DrawableObjects.Plants
{
    public abstract class PlantBase : DrawableObject
    {
        #region  .ctor

        protected PlantBase(bool isFirstGeneration,
                            Point location)
            : base(location)
        {
            IsFistGeneration = isFirstGeneration;        }

        #endregion

        #region  Properties

        public TimerCallback GrownTimerCallback { get; private set; }
        public static int MaxHealth { get; protected set; }
        public static int HealthToGrow { get; protected set; }

        public int GrownTime { get; set; }
        public int Health { get; set; }
        public bool IsFistGeneration { get; set; }
        public int Sun { get; set; }

        #endregion

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