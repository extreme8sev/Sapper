﻿#region Usings

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
        private DrawableObjectDrawer _drawableObjectDrawer;

        #endregion

        #region  .ctor

        private DrawerFactory()
        {
            //singleton
        }

        #endregion

        #region  Properties

        public static DrawerFactory Instance => _instance ?? (_instance = new DrawerFactory());

        /// <summary>
        /// Returns a drawer by object type, if there is no suitable drawer method throws an exception
        /// </summary>
        /// <param name="o">Object inherited from DrawableObject</param>
        /// <returns>An instance of IDrawer interface</returns>
        public IDrawer GetDrawer(DrawableObject o)
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
                        return DrawableObjectDrawer;
                }
                case PlantTree _:
                {
                        return DrawableObjectDrawer;
                }
                default:
                {
                    throw new NotSupportedException("This type is not supported yet!");
                }
            }
        }

        public BryozoaActivatorDrawer BryozoaActivatorDrawer => _bryozoaActivatorDrawer ?? (_bryozoaActivatorDrawer = new BryozoaActivatorDrawer());

        #endregion

        #region Internal Properties

        protected PlantTreeDrawer PlantTreeDrawer => _plantTreeDrawer ?? (_plantTreeDrawer = new PlantTreeDrawer());
        protected PlantBushDrawer PlantBushDrawer => _plantBushDrawer ?? (_plantBushDrawer = new PlantBushDrawer());
        protected BryozoaDrawer BryozoaDrawer => _bryozoaDrawer ?? (_bryozoaDrawer = new BryozoaDrawer());
        protected DrawableObjectDrawer DrawableObjectDrawer => _drawableObjectDrawer ?? (_drawableObjectDrawer = new DrawableObjectDrawer());

        #endregion
    }
}