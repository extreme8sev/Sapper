namespace SapperApplication.Components
{
    public class PlantListItem
    {
        #region  .ctor

        public PlantListItem(PlantBase plant,
                             PlantListItem next,
                             PlantListItem prev)
        {
            Plant = plant;
            Next = next;
            Prev = prev;
        }

        #endregion

        #region  Properties

        public PlantListItem Next { get; set; }
        public PlantBase Plant { get; set; }
        public PlantListItem Prev { get; set; }

        #endregion
    }
}