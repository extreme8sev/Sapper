#region

using System.Windows.Forms;
using SapperApplication.Forms;

#endregion

namespace SapperApplication.Components
{
    public class SapperGameUIManager
    {
        #region  .ctor

        public SapperGameUIManager(MainForm form,
                                   ZooLogic zooLogic)
        {
            _mainForm = form;
            _zooLogic = zooLogic;
        }

        #endregion

        #region Private Members

        private readonly MainForm _mainForm;
        private readonly ZooLogic _zooLogic;

        #endregion

        #region  Public Methods

        public void WriteNumberOfSapperPoint()
        {
            string text = "Очков на счету: " + _zooLogic.SapperPoint;
            _mainForm.SetSapperScoreLabelText(text);
        }

        public void SubscribeByCurrentSapperGameEvent(Sapper currentSapperGame)
        {
            currentSapperGame.EndingGameLose += SapperGameIsLoosed;
            currentSapperGame.EndingGameWin += SapperGameIsWinned;
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

        #endregion
    }
}