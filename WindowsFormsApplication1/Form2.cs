#region Usings

using System;
using System.Windows.Forms;

#endregion

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        private readonly Form1 _form1;

        public Form2()
        {
            InitializeComponent();
        }

        public Form2(Form1 f)
        {
            InitializeComponent();
            _form1 = f;
            _form1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _form1.Enabled = true;
            Close();
        }
    }
}