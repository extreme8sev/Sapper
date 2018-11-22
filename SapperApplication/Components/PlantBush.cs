﻿#region Usings

using System.Drawing;

#endregion

namespace SapperApplication.Components
{
    internal class PlantBush : PlantBase
    {
        #region  .ctor

        public PlantBush(bool isFirstGeneration,
                         Point coord)
            : base(isFirstGeneration,
                   coord)
        {
            MaxHealth = 1000;
            HealthToGrow = MaxHealth * 2;
            GrownTime = 500;
            Sun = 500;
            Initial();
        }

        #endregion
    }
}