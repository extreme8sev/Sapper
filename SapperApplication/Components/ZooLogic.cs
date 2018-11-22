#region Usings

using System.Collections.Generic;
using SapperApplication.Components.DrawableObjects.Plants;
using SapperApplication.Enums;

#endregion

namespace SapperApplication.Components
{
    public class ZooLogic
    {
        #region Private Members

        private readonly int _gameFieldHeight;
        private readonly int _gameFieldWidth;

        #endregion

        #region  .ctor

        public ZooLogic(int gameFieldWidth,
                        int gameFieldHeight)
        {
            SapperPoint = 1000;
            _gameFieldHeight = gameFieldHeight;
            _gameFieldWidth = gameFieldWidth;
            Plants = new List<PlantBase>();
        }

        #endregion

        #region  Properties

        public List<PlantBase> Plants { get; }

        public int SapperPoint { get; set; }

        #endregion

        #region  Public Methods

        public void MakePlantAndBush(int quantity) //Временно
        {
            var plantsFactory = new PlantsFactory(_gameFieldHeight,
                                                  _gameFieldWidth);

            for (int i = 0; i < quantity; i++)
            {
                Plants.Add(plantsFactory.CreateRandom(PlantTypeEnum.Bush));
                Plants.Add(plantsFactory.CreateRandom(PlantTypeEnum.Tree));
            }
        }

        #endregion
    }
}