#region Usings

using System.Drawing;

#endregion

namespace SapperApplication.Components.DrawableObjects.Bryozoa
{
    internal class Bryozoa: DrawableObject
    {
        #region Public Members

        public int Radius { get; }

        public BryozoaActivator Activator { get; }

        #endregion

        #region  .ctor

        public Bryozoa(Point location): base(location)
        {
            Radius = 25;
            Activator = new BryozoaActivator(location);
        }

        #endregion
    }
}