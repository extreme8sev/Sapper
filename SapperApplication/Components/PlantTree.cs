#region Usings

using System.Drawing;
using SapperApplication.Enums;

#endregion

namespace SapperApplication.Components
{
    internal class PlantTree : PlantBase
    {
        #region  .ctor

        public PlantTree(bool isFirstGeneration,
                         Point coord)
            : base(isFirstGeneration,
                   coord)
        {
            MaxHealth = 5000;
            HealthToGrow = (int) (MaxHealth * 1.2);
            GrownTime = 500;
            Sun = 500;
            Initial();
        }

        #endregion

        #region  Properties

        public override PlantTypeEnum PlantType => PlantTypeEnum.Tree;

        #endregion
    }
}