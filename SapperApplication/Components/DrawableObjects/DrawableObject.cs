#region

using System.Drawing;

#endregion

namespace SapperApplication.Components.DrawableObjects
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

        public const string PICTURES_SOURSE = "../../Pictures/";

        public Point Location { get; }

        #endregion
    }
}