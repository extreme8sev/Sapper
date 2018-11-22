#region Usings

using System.Drawing;
using SapperApplication.Components.DrawableObjects;
using SapperApplication.Components.ObjectDrawers;

#endregion

namespace SapperApplication.Components
{
    public class ZooGIU
    {
        #region Private Members

        private const int SCALE = 3;
        private readonly ZooLogic _currentZooLogic;
        private readonly int _gameFieldHeight;
        private readonly int _gameFieldWidth;
        private readonly Graphics _grField;

        #endregion

        #region  .ctor

        public ZooGIU(Graphics grField,
                      ZooLogic currentZooLogic,
                      int gameFieldWidth,
                      int gameFieldHeight)
        {
            _grField = grField;
            _currentZooLogic = currentZooLogic;
            _gameFieldHeight = gameFieldHeight;
            _gameFieldWidth = gameFieldWidth;
        }

        #endregion

        #region  Public Methods

        public void DrawAllPlants()
        {
            ClearScreen();

            foreach (var plant in _currentZooLogic.Plants)
            {
                Draw(plant);
            }
        }

        #endregion

        #region  Private Methods

        private void ClearScreen()
        {
            _grField.FillRectangle(Brushes.Goldenrod,
                                   0,
                                   0,
                                   _gameFieldWidth,
                                   _gameFieldHeight);
        }

        private void Draw(DrawableObject objectToDraw)
        {
            DrawerFactory.Instance[objectToDraw]
                         .Draw(_grField,
                               objectToDraw,
                               SCALE);
        }

        #endregion
    }
}