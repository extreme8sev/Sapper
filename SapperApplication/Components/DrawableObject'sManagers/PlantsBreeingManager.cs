using SapperApplication.Components.DrawableObjects.Plants;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SapperApplication.Components.DrawableObject_sManagers
{
    class PlantsBreeingManager
    {
        private static PlantsBreeingManager _instance;
        private int _gameFieldHeight;
        private int _gameFieldWidth;
        private LinkedList<PlantBase> _plants;


        public static PlantsBreeingManager Instance => _instance ?? (_instance = new PlantsBreeingManager());

        private PlantsBreeingManager()
        {
            //singleton
        }

        public void SetSettings(int gameFieldHeight, int gameFieldWidth, LinkedList<PlantBase> plants)
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
