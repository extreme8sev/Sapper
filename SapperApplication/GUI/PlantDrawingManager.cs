#region Usings

using System.Drawing;
using SapperApplication.Components;
using SapperApplication.Components.DrawableObjects;
using SapperApplication.Components.DrawableObjects.Plants;

#endregion

namespace SapperApplication.GUI
{
    internal class PlantDrawingManager
    {
        #region Private Members

        private Graphics _grField;
        private int _zoom;

        #endregion

        #region  Public Methods

        public void Iniatilization(Graphics grField,
                                   int zoom)
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

        #endregion

        #region  Private Methods

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

        #endregion
    }
}