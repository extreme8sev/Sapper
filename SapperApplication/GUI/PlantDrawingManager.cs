using SapperApplication.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SapperApplication.GUI
{
    class PlantDrawingManager
    {
        private Graphics _grField;
        private int _zoom;

        public void Iniatilization(Graphics grField, int zoom)
        {
            _grField = grField;
            _zoom = zoom;
        }

        public void DrawPlant(PlantBase plant)
        {
            switch (plant.GetType().ToString())
            {
                case "PlantBush":
                    DrawPlantBush(plant as PlantBush);
                    break;
            }
        }

        private void DrawPlantBush(PlantBush plant)
        {
            var userBlack = new Pen(Color.Black,
                                  2);
            /*
            _grField.FillEllipse(Brushes.DarkOliveGreen,
                                _myCoordinate.X - Radius,
                                _myCoordinate.Y - Radius,
                                2 * Radius,
                                2 * Radius);
            _grField.DrawEllipse(userBlack,
                                _myCoordinate.X - Radius,
                                _myCoordinate.Y - Radius,
                                2 * Radius,
                                2 * Radius);
                                */
        }
    }
}
