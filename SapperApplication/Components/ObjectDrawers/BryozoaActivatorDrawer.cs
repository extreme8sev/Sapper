#region

using System.Drawing;
using SapperApplication.Components.DrawableObjects;
using SapperApplication.Components.DrawableObjects.Bryozoa;
using SapperApplication.Interfaces;

#endregion

namespace SapperApplication.Components.ObjectDrawers
{
    public class BryozoaActivatorDrawer : IDrawer
    {
        public void Draw(Graphics graphics,
                         DrawableObject objectToDraw,
                         int scale)
        {
            if (objectToDraw is BryozoaActivator bryozoaActivator)
            {
                var userBlack = new Pen(Color.Black,
                                        2);
                graphics.FillEllipse(Brushes.Crimson,
                                     bryozoaActivator.Location.X - bryozoaActivator.RadiusAct,
                                     bryozoaActivator.Location.Y - bryozoaActivator.RadiusAct,
                                     2 * bryozoaActivator.RadiusAct,
                                     2 * bryozoaActivator.RadiusAct);
                graphics.DrawEllipse(userBlack,
                                     bryozoaActivator.Location.X - bryozoaActivator.RadiusAct,
                                     bryozoaActivator.Location.Y - bryozoaActivator.RadiusAct,
                                     2 * bryozoaActivator.RadiusAct,
                                     2 * bryozoaActivator.RadiusAct);
            }
        }
    }
}