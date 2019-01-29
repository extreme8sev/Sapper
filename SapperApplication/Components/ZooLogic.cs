#region Usings

using System.Collections.Generic;
using SapperApplication.Components.DrawableObjects.Plants;
using SapperApplication.Enums;
using SapperApplication.Components.DrawableObject_sManagers;

#endregion

namespace SapperApplication.Components
{
    public class ZooLogic
    {
        #region Private Members

        private readonly int _gameFieldHeight;
        private readonly int _gameFieldWidth;
        private const int MAX_NUMBER_OF_PLANTS = 300;


        #endregion

        #region  .ctor

        public ZooLogic(int gameFieldWidth,
                        int gameFieldHeight)
        {
            SapperPoint = 1000;
            _gameFieldHeight = gameFieldHeight;
            _gameFieldWidth = gameFieldWidth;
            Plants = new LinkedList<PlantBase>();
            PlantsBreeingManager.Instance.SetSettings(gameFieldHeight, 
                                                        gameFieldWidth, 
                                                        Plants);
            PlantsFactory.Instance.Initialize(_gameFieldHeight,
                                                  _gameFieldWidth);
        }

        #endregion

        #region  Properties

        public LinkedList<PlantBase> Plants { get; }

        public int SapperPoint { get; set; }

        #endregion

        #region  Public Methods

        public void MakePlantAndBush(int quantity) //Временно
        {
            for (int i = 0; i < quantity; i++)
            {
                    PlantBase plantBush = PlantsFactory.Instance.CreateRandom(PlantTypeEnum.Bush);
                    AddPlant(plantBush);
                    plantBush.GiveOffspringEvent += MakePlantsOffspring;
                    PlantBase plantTree = PlantsFactory.Instance.CreateRandom(PlantTypeEnum.Tree);
                    AddPlant(plantTree);
                    plantTree.GiveOffspringEvent += MakePlantsOffspring;
            }
        }

        public void MakePlantsOffspring(int quantity)
        {
            if (Plants.Count < MAX_NUMBER_OF_PLANTS)
            {
                MakePlantAndBush(quantity);
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