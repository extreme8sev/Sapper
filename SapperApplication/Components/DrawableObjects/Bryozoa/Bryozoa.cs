#region

using System.Drawing;

#endregion

namespace SapperApplication.Components.DrawableObjects.Bryozoa
{
    internal class Bryozoa : DrawableObject
    {
        #region  .ctor

        public Bryozoa(Point location)
            : base(location)
        {
            Radius = 25;
            Activator = new BryozoaActivator(location);
        }

        #endregion

        #region Public Members

        public int Radius { get; }

        public BryozoaActivator Activator { get; }

        #endregion
    }
}