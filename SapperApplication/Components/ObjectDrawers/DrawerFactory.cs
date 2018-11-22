#region Usings

using System;
using SapperApplication.Components.DrawableObjects;
using SapperApplication.Components.DrawableObjects.Bryozoa;
using SapperApplication.Components.DrawableObjects.Plants;
using SapperApplication.Interfaces;

#endregion

namespace SapperApplication.Components.ObjectDrawers
{
    public class DrawerFactory
    {
        #region Private Members

        private static DrawerFactory _instance;
        private BryozoaActivatorDrawer _bryozoaActivatorDrawer;
        private BryozoaDrawer _bryozoaDrawer;
        private PlantBushDrawer _plantBushDrawer;
        private PlantTreeDrawer _plantTreeDrawer;

        #endregion

        #region  .ctor

        private DrawerFactory()
        {
            //singleton
        }

        #endregion

        #region  Properties

        public static DrawerFactory Instance => _instance ?? (_instance = new DrawerFactory());

        public IDrawer this[DrawableObject o]
        {
            get
            {
                switch (o)
                {
                    case BryozoaActivator _:
                    {
                        return BryozoaActivatorDrawer;
                    }
                    case Bryozoa _:
                    {
                        return BryozoaDrawer;
                    }
                    case PlantBush _:
                    {
                        return PlantBushDrawer;
                    }
                    case PlantTree _:
                    {
                        return PlantTreeDrawer;
                    }
                    default:
                    {
                        throw new NotSupportedException("This type is not supported yet!");
                    }
                }
            }
        }

        public BryozoaActivatorDrawer BryozoaActivatorDrawer => _bryozoaActivatorDrawer ?? (_bryozoaActivatorDrawer = new BryozoaActivatorDrawer());

        #endregion

        #region Internal Properties

        protected PlantTreeDrawer PlantTreeDrawer => _plantTreeDrawer ?? (_plantTreeDrawer = new PlantTreeDrawer());
        protected PlantBushDrawer PlantBushDrawer => _plantBushDrawer ?? (_plantBushDrawer = new PlantBushDrawer());
        protected BryozoaDrawer BryozoaDrawer => _bryozoaDrawer ?? (_bryozoaDrawer = new BryozoaDrawer());

        #endregion
    }
}