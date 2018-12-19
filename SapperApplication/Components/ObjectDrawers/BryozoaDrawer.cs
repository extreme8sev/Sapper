#region

using System.Drawing;
using SapperApplication.Components.DrawableObjects;
using SapperApplication.Components.DrawableObjects.Bryozoa;
using SapperApplication.Interfaces;

#endregion

namespace SapperApplication.Components.ObjectDrawers
{
    public class BryozoaDrawer : IDrawer
    {
        public void Draw(Graphics graphics,
                         DrawableObject objectToDraw,
                         int scale)
        {
            if (objectToDraw is Bryozoa bryozoa)
            {
                var userBlack = new Pen(Color.Black,
                                        2);
                graphics.FillEllipse(Brushes.DarkOliveGreen,
                                     objectToDraw.Location.X - bryozoa.Radius,
                                     objectToDraw.Location.Y - bryozoa.Radius,
                                     2 * bryozoa.Radius,
                                     2 * bryozoa.Radius);
                graphics.DrawEllipse(userBlack,
                                     objectToDraw.Location.X - bryozoa.Radius,
                                     objectToDraw.Location.Y - bryozoa.Radius,
                                     2 * bryozoa.Radius,
                                     2 * bryozoa.Radius);
            }
        }
    }
}