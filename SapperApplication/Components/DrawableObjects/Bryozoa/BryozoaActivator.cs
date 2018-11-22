using System.Drawing;

namespace SapperApplication.Components.DrawableObjects.Bryozoa
{
    internal class BryozoaActivator : DrawableObject
    {
        public int RadiusAct { get; }

        public BryozoaActivator(Point location)
            : base(location)
        {
            RadiusAct = 10;
        }
    }
}