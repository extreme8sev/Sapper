#region

using System;
using System.Drawing;
using SapperApplication.Components.DrawableObjects;
using SapperApplication.Components.DrawableObjects.Plants;
using SapperApplication.Interfaces;
using SapperApplication.Properties;

#endregion

namespace SapperApplication.Components.ObjectDrawers
{
    public class DrawableObjectDrawer : IDrawer
    {
        public void Draw(Graphics drawField,
                         DrawableObject objectToDraw,
                         int zoom) =>
            DrawOnCoorinate(drawField,
                            objectToDraw,
                            zoom,
                            objectToDraw.Location.X,
                            objectToDraw.Location.Y);


        public void DrawOnCoorinate(Graphics drawField,
                                    DrawableObject objectToDraw,
                                    int zoom,
                                    int x,
                                    int y)
        {
            #region Imagine draw

            float innerZoom;
            Image objectImage;

            SetImage(objectToDraw, out innerZoom, out objectImage);

            var imageHeight = (int) (objectImage.Height * innerZoom * zoom);
            var halfImageWidth = (int) (objectImage.Width * innerZoom * zoom / 2);

            var plantRectangle = new Rectangle(x - halfImageWidth,
                                               y - imageHeight,
                                               halfImageWidth * 2,
                                               imageHeight);
            drawField.DrawImage(objectImage, plantRectangle);
            //DrawCoordinate(drawField, objectToDraw);

            #endregion
        }

        /// <summary>
        ///     Рисует точку, соответствующую собственным координатам объекта
        /// </summary>
        /// <param name="drawField"></param>
        /// <param name="objectToDraw"></param>
        /// <param name="zoom"></param>
        public void DrawCoordinate(Graphics drawField,
                                   DrawableObject objectToDraw)
        {
            Brush coordinateBrush = Brushes.Red;
            drawField.FillEllipse(coordinateBrush,
                                  objectToDraw.Location.X,
                                  objectToDraw.Location.Y,
                                  5,
                                  5);
        }

        private void SetImage(DrawableObject objectToDetect,
                              out float innerZoom,
                              out Image imageToSet)
        {
            switch (objectToDetect)
            {
                case PlantBush _:
                {
                    innerZoom = 0.12F;
                    imageToSet = Resources.BushImage;
                    break;
                }
                case PlantTree _:
                {
                    innerZoom = 0.25F;
                    imageToSet = Resources.TreeImage;
                    break;
                }
                default:
                {
                    throw new NotSupportedException("This type is not supported yet!");
                }
            }
        }
    }
}