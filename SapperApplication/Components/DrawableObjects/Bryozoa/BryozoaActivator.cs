#region

using System.Drawing;

#endregion

namespace SapperApplication.Components.DrawableObjects.Bryozoa
{
    internal class BryozoaActivator : DrawableObject
    {
        public BryozoaActivator(Point location)
            : base(location)
        {
            RadiusAct = 10;
        }

        public int RadiusAct { get; }
    }
}