#region

using System.Drawing;
using SapperApplication.Components.DrawableObjects;

#endregion

namespace SapperApplication.Interfaces
{
    public interface IDrawer
    {
        #region  Public Methods

        void Draw(Graphics graphics,
                  DrawableObject objectToDraw,
                  int scale);

        #endregion
    }
}