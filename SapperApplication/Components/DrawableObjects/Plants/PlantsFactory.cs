#region Usings

using System;
using System.Drawing;
using SapperApplication.Enums;

#endregion

namespace SapperApplication.Components.DrawableObjects.Plants
{
    public class PlantsFactory
    {
        #region Private Members

        private static PlantsFactory _instance;
        private int _gameFieldHeight;
        private int _gameFieldWidth;
        private Random _random;

        #endregion

        #region  .ctor

        private PlantsFactory()
        {
            //Singleton because of Random incorrect working in case of multiple creations in same time
        }

        #endregion
        public void Initialize(int gameFieldHeight,
                             int gameFieldWidth)
        {
            _gameFieldHeight = gameFieldHeight;
            _gameFieldWidth = gameFieldWidth;
            _random = new Random();
        }

        #region  Public Methods
        public static PlantsFactory Instance => _instance ?? (_instance = new PlantsFactory());

        public PlantBase Create(PlantTypeEnum plantType,
                                Point plantLocation) => MakePlant(plantType,
                                                                  plantLocation);

        public PlantBase CreateRandom(PlantTypeEnum plantType)
        {
            var plantRandomLocation = GetPlantRandomLocation();
            return Create(plantType,
                          plantRandomLocation);
        }

        #endregion

        #region  Private Methods

        private Point GetPlantRandomLocation()
        {
            var x = _random.Next(20,
                                 _gameFieldWidth - 20);
            var y = _random.Next(20,
                                 _gameFieldHeight - 2);

            return new Point(x,
                             y);
        }

        private PlantBase MakePlant(PlantTypeEnum plantType,
                                    Point plantLocation)
        {
            switch (plantType)
            {
                case PlantTypeEnum.Bush:
                    return MakeBush(plantLocation);
                case PlantTypeEnum.Tree:
                    return MakeTree(plantLocation);
                default:
                    throw new ArgumentOutOfRangeException(nameof(plantType),
                                                          plantType,
                                                          null);
            }
        }

        private PlantTree MakeTree(Point plantLocation) => new PlantTree(true,
                                                                         plantLocation);

        private PlantBush MakeBush(Point plantLocation) => new PlantBush(true,
                                                                         plantLocation);

        #endregion
    }
}