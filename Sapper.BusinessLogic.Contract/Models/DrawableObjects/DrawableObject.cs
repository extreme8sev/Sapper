#region

using System.Drawing;

#endregion

namespace Sapper.BusinessLogic.Contract.Models.DrawableObjects
{
    public abstract class DrawableObject
    {
        #region  .ctor

        protected DrawableObject(Point location)
        {
            Location = location;
        }

        #endregion

        #region  Properties

        public Point Location { get; }

        #endregion
    }
}