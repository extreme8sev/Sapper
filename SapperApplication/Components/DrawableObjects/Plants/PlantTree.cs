#region Usings

using System.Drawing;

#endregion

namespace SapperApplication.Components.DrawableObjects.Plants
{
    public class PlantTree : PlantBase
    {
        #region  .ctor

        public PlantTree(bool isFirstGeneration,
                         Point location)
            : base(isFirstGeneration,
                   location)
        {
            MaxHealth = 5000;
            HealthToGrow = (int) (MaxHealth * 1.2);
            GrownTime = 5000;
            Sun = 10;
            Initial();
        }

        #endregion
    }
}