#region

using System;
using System.Windows.Forms;

#endregion

namespace SapperApplication.Forms
{
    public partial class DifficultyForm : Form
    {
        #region Private Members

        private readonly MainForm _form1;

        #endregion

        #region  Private Methods

        private void button2_Click(object sender,
                                   EventArgs e)
        {
            _form1.Enabled = true;
            Close();
        }

        #endregion

        #region  .ctor

        public DifficultyForm()
        {
            InitializeComponent();
        }

        public DifficultyForm(MainForm f)
        {
            InitializeComponent();
            _form1 = f;
            _form1.Enabled = false;
        }

        #endregion
    }
}