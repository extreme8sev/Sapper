#region Usings

using System.Collections.Generic;
using SapperApplication.Enums;

#endregion

namespace SapperApplication.Components
{
    public class ZooLogic
    {
        #region Public Members

        public PlantList CurrentPlantList { get; }
        public LinkedList<PlantBase> Plants { get; }

        #endregion

        #region  .ctor

        public ZooLogic(int gameFieldWidth,
                        int gameFieldHeight)
        {
            SapperPoint = 1000;
            _gameFieldHeight = gameFieldHeight;
            _gameFieldWidth = gameFieldWidth;
            CurrentPlantList = new PlantList();
            Plants = new LinkedList<PlantBase>();
        }

        #endregion

        #region  Properties

        public int SapperPoint { get; set; }

        #endregion

        #region  Private Properties

        private readonly int _gameFieldHeight;
        private readonly int _gameFieldWidth;

        #endregion

        #region  Public Methods

        public void MakePlantAndBush() //Временно
        {
            var plantsFactory = new PlantsFactory(_gameFieldHeight, _gameFieldWidth);
            CurrentPlantList.AddNewPlant(plantsFactory.CreateRandom(PlantTypeEnum.Bush));
            CurrentPlantList.AddNewPlant(plantsFactory.CreateRandom(PlantTypeEnum.Tree));
        }

        #endregion
    }
}