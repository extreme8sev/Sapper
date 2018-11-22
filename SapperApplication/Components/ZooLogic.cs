#region Usings

using System;
using System.Drawing;

#endregion

namespace SapperApplication.Components
{
    public class ZooLogic
    {
        #region Public Members

        public PlantList CurrentPlantList;

        #endregion

        #region  .ctor

        public ZooLogic(int gameFieldWidth,
                        int gameFieldHeight)
        {
            SapperPoint = 1000;
            GameFieldHeight = gameFieldHeight;
            GameFieldWidth = gameFieldWidth;
            CurrentPlantList = new PlantList();
        }

        #endregion

        #region  Properties

        public int SapperPoint { get; set; }

        #endregion

        #region  Private Properties

        private int GameFieldHeight { get; }
        private int GameFieldWidth { get; }

        #endregion

        #region  Public Methods

        public void Make10Plants() //Временно
        {
            var plantPoint = new Point();
            var rnd = new Random();

            plantPoint.X = rnd.Next(20,
                                    GameFieldWidth - 20);
            plantPoint.Y = rnd.Next(20,
                                    GameFieldHeight - 2);
            PlantBase plant = new PlantBush(true,
                                            plantPoint);
            CurrentPlantList.AddNewPlant(plant);
            plantPoint.X = rnd.Next(20,
                                    GameFieldWidth - 20);
            plantPoint.Y = rnd.Next(20,
                                    GameFieldHeight - 2);
            plant = new PlantTree(true,
                                  plantPoint);
            CurrentPlantList.AddNewPlant(plant);
        }

        #endregion
    }
}