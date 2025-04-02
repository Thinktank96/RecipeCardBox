using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecipeProgram
{
    public partial class NewFolderForm : Form
    {
        public NewFolderForm()
        {
            InitializeComponent();
        }

        private void FolderNameBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void CreateFolderButton_Click(object sender, EventArgs e)
        {
            CreateDir();
        }

        private void CreateFolderButton_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void FolderNameBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                CreateDir();
                e.Handled = true;
            }
        }

        private void CreateDir()
        {
            if (FolderNameBox.Text.Trim() == "")
            {
                MessageBox.Show("You need text you idiot.");    
            }
            else
            {
                try
                {

                    Program.rootDirectory.CreateSubdirectory(FolderNameBox.Text);
                }
                catch
                {
                    MessageBox.Show("Cannot make directory: " + FolderNameBox.Text);
                }
            }

            this.Close();
        }
    }
}
