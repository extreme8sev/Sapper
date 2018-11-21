using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SapperApplication.Components
{
    public class ZooLogic
    {

        public int SapperPoint { get; set; }
        public PlantBase[] PlantArray;
        public PlantList CurrentPlantList;
        

        private int GameFieldHeight { get; set; }
        private int GameFieldWidth { get; set; }


        public ZooLogic(int gameFieldWidth, int gameFieldHeight)
        {
            SapperPoint = 1000;
            GameFieldHeight = gameFieldHeight;
            GameFieldWidth = gameFieldWidth;
            CurrentPlantList = new PlantList();
            Make10Plants();
        }

        public void Make10Plants()
        {
            PlantArray = new PlantBase[10];
            Point PlantPoint = new Point();
            Random rnd = new Random();
            PlantBase plant;
            for (int i = 0; i < 10; i++)
            {
                PlantPoint.X = rnd.Next(20, GameFieldWidth-20);
                PlantPoint.Y = rnd.Next(20, GameFieldHeight-20);
                plant = new PlantBush(true, PlantPoint);
                CurrentPlantList.AddNewPlant(plant);
                PlantPoint.X = rnd.Next(20, GameFieldWidth - 20);
                PlantPoint.Y = rnd.Next(20, GameFieldHeight - 20);
                plant = new PlantTree(true, PlantPoint);
                CurrentPlantList.AddNewPlant(plant);
            }
        }
        
    }
}
