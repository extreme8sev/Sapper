﻿using System;
using System.Drawing;
using SapperApplication.Enums;

namespace SapperApplication.Components
{
    public class PlantsFactory
    {
        private readonly int _gameFieldHeight;
        private readonly int _gameFieldWidth;
        private readonly Random _random;

        public PlantsFactory(int gameFieldHeight, int gameFieldWidth)
        {
            _gameFieldHeight = gameFieldHeight;
            _gameFieldWidth = gameFieldWidth;
            _random = new Random();
        }

        public PlantBase Create(PlantTypeEnum plantType, Point plantLocation) => MakePlant(plantType,
                                                                                           plantLocation);

        public PlantBase CreateRandom(PlantTypeEnum plantType)
        {
            var plantRandomLocation = GetPlantRandomLocation();
            return Create(plantType, plantRandomLocation);
        }

        private Point GetPlantRandomLocation()
        {
            var x = _random.Next(20,
                                 _gameFieldWidth - 20);
            var y = _random.Next(20,
                                 _gameFieldHeight - 2);

            return new Point(x,
                             y);
        }

        private PlantBase MakePlant(PlantTypeEnum plantType, Point plantLocation)
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

        private PlantTree MakeTree(Point plantLocation) => new PlantTree(true, plantLocation);

        private PlantBush MakeBush(Point plantLocation) => new PlantBush(true, plantLocation);
    }
}