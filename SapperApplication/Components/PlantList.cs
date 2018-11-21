using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SapperApplication.Components
{
    public class PlantList
    {
        public PlantListItem FirstPlant;
        public PlantList()
        {
        }

        public void AddNewPlant(PlantBase plant)
        {
            if (FirstPlant == null)
            {
                FirstPlant = new PlantListItem(plant, null, null);
            }

            else
            {
                var AddedPlantListItem = new PlantListItem(plant, null, null);
                var CurrentPlantListItem = FirstPlant;
                for (;;)
                {
                    if (CurrentPlantListItem.Plant.MyCoordinate.Y > plant.MyCoordinate.Y)
                    {
                        if (CurrentPlantListItem == FirstPlant)
                        {
                            FirstPlant = AddedPlantListItem;
                        }
                        AddedPlantListItem.Next = CurrentPlantListItem;
                        AddedPlantListItem.Prev = CurrentPlantListItem.Prev;
                        CurrentPlantListItem.Prev = AddedPlantListItem;
                        if (AddedPlantListItem.Prev != null)
                        {
                            AddedPlantListItem.Prev.Next = AddedPlantListItem;
                        }
                        break;
                    }
                    if (CurrentPlantListItem.Next == null)
                    {
                        AddedPlantListItem.Prev = CurrentPlantListItem;
                        CurrentPlantListItem.Next = AddedPlantListItem;
                        break;
                    }
                    CurrentPlantListItem = CurrentPlantListItem.Next;
                }
            }
        }


        public class PlantListItem
        {
            public PlantBase Plant;
            public PlantListItem Next;
            public PlantListItem Prev;
            public PlantListItem(PlantBase plant, PlantListItem next, PlantListItem prev)
            {
                Plant = plant;
                Next = next;
                Prev = prev;
            }

        }
    }
}
