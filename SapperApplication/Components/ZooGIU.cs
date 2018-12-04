#region Usings

using System.Drawing;
using System.Linq;
using SapperApplication.Components.DrawableObjects;
using SapperApplication.Components.DrawableObjects.Plants;
using SapperApplication.Components.ObjectDrawers;
using SapperApplication.Interfaces;
using System.Collections.Generic;
using System.Threading;

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
        private const int TIME_BETWEEN_REDRAVS = 1000;
        private readonly Timer _redrawTimer;

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
            _redrawTimer = new Timer(RedrawTimerCallback, null, 0, TIME_BETWEEN_REDRAVS);
        }

        #endregion

        #region  Public Methods
        private void RedrawTimerCallback(object obj)
        {
            DrawAllPlants();
        }
        public void DrawAllPlants()
        {
            ClearScreen();

            for (LinkedListNode<PlantBase> plant = _currentZooLogic.Plants.First;
                plant != null;
                plant = plant.Next)
            {
                Draw(plant.Value);
            }
        }

        #endregion

        #region  Private Methods

        private void ClearScreen()
        {
            _grField.FillRectangle(Brushes.OliveDrab,
                                   0,
                                   0,
                                   _gameFieldWidth,
                                   _gameFieldHeight);
        }

        private void Draw(DrawableObject objectToDraw)
        {
            IDrawer drawer = DrawerFactory.Instance.GetDrawer(objectToDraw);
            drawer.Draw(_grField,
                        objectToDraw,
                        SCALE);
        }

        #endregion
    }
}