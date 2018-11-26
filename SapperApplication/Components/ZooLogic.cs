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
            Plants = new LinkedList<PlantBase>();
        }

        #endregion

        #region  Properties

        public LinkedList<PlantBase> Plants { get; }

        public int SapperPoint { get; set; }

        #endregion

        #region  Public Methods

        public void MakePlantAndBush(int quantity) //Временно
        {
            var plantsFactory = new PlantsFactory(_gameFieldHeight,
                                                  _gameFieldWidth);

            for (int i = 0; i < quantity; i++)
            {
                for (var j = 0; j < 5; j++)
                {
                    AddPlant(plantsFactory.CreateRandom(PlantTypeEnum.Bush));
                }
                AddPlant(plantsFactory.CreateRandom(PlantTypeEnum.Tree));
            }
        }

        public void AddPlant(PlantBase addedPlant)
        {
            if (Plants.Count == 0 || addedPlant.Location.Y < Plants.First.Value.Location.Y)
            {
                Plants.AddFirst(addedPlant);
            }
            else
            {
                LinkedListNode<PlantBase> currentPlant = Plants.First;
                while (true)
                {
                    if (addedPlant.Location.Y < currentPlant.Value.Location.Y)
                    {
                        Plants.AddBefore(currentPlant, addedPlant);
                        break;
                    }
                    currentPlant = currentPlant.Next;
                    if (currentPlant == null)
                    {
                        Plants.AddLast(addedPlant);
                        break;
                    }
                }
            }
        }
        #endregion
    }
}