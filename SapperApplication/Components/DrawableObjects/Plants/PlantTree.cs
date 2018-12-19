#region

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
            HealthToGrow = MaxHealth * 3;
            GrownTime = 5000;
            Sun = 10;
            Initial();
        }

        public override void GiveOffspring()
        {
            GiveOffspringEventInvoke(5);
        }

        #endregion
    }
}