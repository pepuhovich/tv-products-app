using System;
using System.Windows.Forms;

namespace TVStoreApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void catalogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create a new instance of the Form2 class
            Form2 catalogForm = new Form2();

            // Show the settings form
            this.Hide();
            catalogForm.Show();
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 homeForm = new Form1();
            this.Hide();
            homeForm.Show();
        }
    }
}
