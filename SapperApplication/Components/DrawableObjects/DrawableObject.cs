#region Usings

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

        public Point Location { get; }

        #endregion
    }
}