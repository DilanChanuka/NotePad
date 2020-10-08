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

namespace NotePad
{
    public partial class Notepad : Form
    {
        public Notepad()
        {
            InitializeComponent();
        }

        string SavePath = "";
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
           if( saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                SavePath = saveFileDialog1.FileName;
                File.WriteAllText(SavePath,richTextBox1.Text);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                SavePath = openFileDialog1.FileName;
                richTextBox1.Text = File.ReadAllText(SavePath);
                this.Text = openFileDialog1.SafeFileName+" - NotePad";
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SavePath.Length > 0)
            {
                File.WriteAllText(SavePath, richTextBox1.Text);
            }
            else
            {
                saveAsToolStripMenuItem_Click(null, null);
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = richTextBox1.Font;
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Font = fontDialog1.Font;
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Clipboard.SetText(richTextBox1.SelectedText);
            if (richTextBox1.SelectedText.Length == 0)
                Clipboard.SetText(richTextBox1.Text);
            else
                Clipboard.SetText(richTextBox1.SelectedText);
        }

        private void pastToolStripMenuItem_Click(object sender, EventArgs e)
        {           
            richTextBox1.SelectedText = Clipboard.GetText();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectedText.Length > 0)
            {
                richTextBox1.Cut();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedText = "";
        }

        private void zoomInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Font f = new Font(richTextBox1.Font.Name, richTextBox1.Font.Size + 5, richTextBox1.Font.Style);
            richTextBox1.Font = f;                 
        }

        private void zoomOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Font f = new Font(richTextBox1.Font.Name, richTextBox1.Font.Size - 5, richTextBox1.Font.Style);
            richTextBox1.Font = f;
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            string msg = "Do you want to save. ?";

            switch(MessageBox.Show(msg,"Note Pad", MessageBoxButtons.YesNoCancel,MessageBoxIcon.Warning))
            {
                case DialogResult.Yes:
                    saveToolStripMenuItem_Click(null, null);break;

                case DialogResult.Cancel:
                    e.Cancel = true;break;                    
            }
        }
    }
}
