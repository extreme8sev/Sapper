using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SapperApplication.Components
{
    class PlantBush : PlantBase
    {
        public PlantBush(bool isFirstGeneration, Point coord) : base(isFirstGeneration, coord)
        {
            MaxHealth = 1000;
            HealthToGrow = MaxHealth * 2;
            GrownTime = 500;
            Sun = 500;
            Initial();
        }


    }
}
