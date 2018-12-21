#region

using System.Drawing;

#endregion

namespace Sapper.BusinessLogic.Contract.Models.DrawableObjects.Pearlwort
{
    public class PearlwortActivator : DrawableObject
    {
        public PearlwortActivator(Point location)
            : base(location)
        {
            RadiusAct = 10;
        }

        public int RadiusAct { get; }
    }
}