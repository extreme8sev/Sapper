using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SapperApplication.Components
{
    class PlantTree : PlantBase
    {
        public PlantTree(bool isFirstGeneration, Point coord) : base(isFirstGeneration, coord)
        {
            MaxHealth = 5000;
            HealthToGrow = (int)(MaxHealth * 1.2);
            GrownTime = 500;
            Sun = 500;
            Initial();
        }
    }
}
