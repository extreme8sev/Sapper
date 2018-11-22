#region Usings

using System.Drawing;
using SapperApplication.Enums;

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

        #region  Properties

        public override PlantTypeEnum PlantType => PlantTypeEnum.Bush;

        #endregion
    }
}