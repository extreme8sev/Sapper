#region Usings

using System.Drawing;

#endregion

namespace SapperApplication.Components
{
    internal class Bryozoa
    {
        #region Public Members

        public int Radius = 25;
        public int RadiusAct = 10;

        #endregion

        #region Private Members

        private readonly Point _myCoordinate;

        #endregion

        #region  .ctor

        public Bryozoa(Point myCoordinateCon)
        {
            _myCoordinate = myCoordinateCon;
        }

        #endregion

        #region  Public Methods

        public void DrawMyself(Graphics grField)
        {
            var userBlack = new Pen(Color.Black,
                                    2);
            grField.FillEllipse(Brushes.DarkOliveGreen,
                                _myCoordinate.X - Radius,
                                _myCoordinate.Y - Radius,
                                2 * Radius,
                                2 * Radius);
            grField.DrawEllipse(userBlack,
                                _myCoordinate.X - Radius,
                                _myCoordinate.Y - Radius,
                                2 * Radius,
                                2 * Radius);
        }

        public void Activate(Graphics grField)
        {
            var userBlack = new Pen(Color.Black,
                                    2);
            grField.FillEllipse(Brushes.Crimson,
                                _myCoordinate.X - RadiusAct,
                                _myCoordinate.Y - RadiusAct,
                                2 * RadiusAct,
                                2 * RadiusAct);
            grField.DrawEllipse(userBlack,
                                _myCoordinate.X - RadiusAct,
                                _myCoordinate.Y - RadiusAct,
                                2 * RadiusAct,
                                2 * RadiusAct);
        }

        #endregion
    }
}