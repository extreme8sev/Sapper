#region

using System.Drawing;

#endregion

namespace SapperApplication.Components.DrawableObjects.Plants
{
    public class PlantBush : PlantBase
    {
        #region  .ctor

        public PlantBush(bool isFirstGeneration,
                         Point location)
            : base(isFirstGeneration,
                   location)
        {
            MaxHealth = 1000;
            HealthToGrow = MaxHealth * 2;
            GrownTime = 5000;
            Sun = 50;
            Initial();
        }

        #endregion
    }
}