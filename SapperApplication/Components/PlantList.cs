namespace SapperApplication.Components
{
    public class PlantList
    {
        #region Public Members

        public PlantListItem FirstPlant;

        #endregion

        #region  Public Methods

        public void AddNewPlant(PlantBase plant)
        {
            if (FirstPlant == null)
            {
                FirstPlant = new PlantListItem(plant,
                                               null,
                                               null);
            }

            else
            {
                var addedPlantListItem = new PlantListItem(plant,
                                                           null,
                                                           null);
                PlantListItem currentPlantListItem = FirstPlant;
                for (;;)
                {
                    if (currentPlantListItem.Plant.MyCoordinate.Y > plant.MyCoordinate.Y)
                    {
                        if (currentPlantListItem == FirstPlant)
                        {
                            FirstPlant = addedPlantListItem;
                        }

                        addedPlantListItem.Next = currentPlantListItem;
                        addedPlantListItem.Prev = currentPlantListItem.Prev;
                        currentPlantListItem.Prev = addedPlantListItem;
                        if (addedPlantListItem.Prev != null)
                        {
                            addedPlantListItem.Prev.Next = addedPlantListItem;
                        }

                        break;
                    }

                    if (currentPlantListItem.Next == null)
                    {
                        addedPlantListItem.Prev = currentPlantListItem;
                        currentPlantListItem.Next = addedPlantListItem;
                        break;
                    }

                    currentPlantListItem = currentPlantListItem.Next;
                }
            }
        }

        #endregion
    }
}