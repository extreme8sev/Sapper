﻿#region Usings

using System;
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
        public Timer GrownUpTimer { get; protected set; }

        public int GrownTime { get; set; }
        public int Health { get; set; }
        public bool IsFistGeneration { get; set; }
        public int Sun { get; set; }
        public Random Rand { get; protected set; }


        #endregion

        #region  Public Methods

        public void Initial()
        {
            GrownTimerCallback = GrowUp;
            GrownUpTimer = new Timer(GrownTimerCallback,
                                         null,
                                         GrownTime,
                                         GrownTime);
            Health = MaxHealth / 4;
            Rand = new Random();
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
            //GiveOffspring();
            Health += Sun*Rand.Next(2, 10);
            if (Health >= HealthToGrow)
            {
                Health = MaxHealth;
                GiveOffspring();
            }
            
        }

        public delegate void GiveOffspringDelegate(int quantity);
        public event GiveOffspringDelegate GiveOffspringEvent;

        virtual public void GiveOffspring()
        {
            GiveOffspringEvent?.Invoke(1);
        }

        public void GiveOffspringEventInvoke(int quantity)
        {
            GiveOffspringEvent?.Invoke(quantity);
        }

        #endregion
    }
}