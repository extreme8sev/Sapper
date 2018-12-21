#region

using System.Drawing;

#endregion

namespace Sapper.BusinessLogic.Contract.Models.DrawableObjects.Pearlwort
{
    public class Pearlwort : DrawableObject
    {
        #region  .ctor

        public Pearlwort(Point location)
            : base(location)
        {
            Radius = 25;
            Activator = new PearlwortActivator(location);
        }

        #endregion

        #region Public Members

        public int Radius { get; }

        public PearlwortActivator Activator { get; }

        #endregion
    }
}