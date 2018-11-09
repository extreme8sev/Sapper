using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SapperApplication.Components
{
    public class SapperGameUIManager
    {
        private Forms.Form1 _mainForm;
        private ZooLogic _zooLogic;

        public SapperGameUIManager(Forms.Form1 form, ZooLogic zooLogic)
        {
            _mainForm = form;
            _zooLogic = zooLogic;
        }

        public void WriteNumberOfSapperPoint()
        {
            string text = "Очков на счету: " + _zooLogic.SapperPoint.ToString();
            _mainForm.SetSapperScoreLabelText(text);
        }

        public void SubscribeByCurrentSapperGameEvent(Sapper currentSapperGame)
        {
            currentSapperGame.EndingGame_Lose += SapperGameIsLoosed;
            currentSapperGame.EndingGame_Win += SapperGameIsWinned;
        }

        public void SapperGameIsWinned(int difficult)
        {
            _zooLogic.SapperPoint += difficult * 200;
            MessageBox.Show(
                "You win!",
                "Message",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
            WriteNumberOfSapperPoint();
        }

        public void SapperGameIsLoosed(int difficult)
        {
            _zooLogic.SapperPoint -= difficult * 100;
            MessageBox.Show(
                "You lose =(",
                "Message",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
            WriteNumberOfSapperPoint();
        }
    }
}
