#region

using System.Collections.Generic;
using SapperApplication.Components.DrawableObjects.Plants;

#endregion

namespace SapperApplication.Components.DrawableObject_sManagers
{
    internal class PlantsBreeingManager
    {
        private static PlantsBreeingManager _instance;
        private int _gameFieldHeight;
        private int _gameFieldWidth;
        private LinkedList<PlantBase> _plants;

        private PlantsBreeingManager()
        {
            //singleton
        }


        public static PlantsBreeingManager Instance => _instance ?? (_instance = new PlantsBreeingManager());

        public void SetSettings(int gameFieldHeight,
                                int gameFieldWidth,
                                LinkedList<PlantBase> plants)
        {
            if (_plants == null)
            {
                _gameFieldHeight = gameFieldHeight;
                _gameFieldWidth = gameFieldWidth;
                _plants = plants;
            }
        }

        /* public Point GetCoordinateOfOffspring(Point parentCoordinate, int radiusOfBreeding)
        {

        }*/
    }
}