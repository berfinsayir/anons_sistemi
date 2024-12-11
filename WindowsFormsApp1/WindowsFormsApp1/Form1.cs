using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofile = new OpenFileDialog();
            //file.ShowDialog();
            ofile.Multiselect = true;
            ofile.Filter = "Auto Files (*.mp3;*.wav;*.ogg|*.mp3;*.vaw;*.ogg";

            if (ofile.ShowDialog() == DialogResult.OK)
            {
                //string[] selectedFile = ofile.FileNames;
                //textBox1.Clear();
                //foreach (var file in selectedFile)
                //{
                //    textBox1.AppendText(file + Environment.NewLine);

                //}

                //textBox1.Text = ofile.FileName;

                string[] selectedfiles = ofile.FileNames;
                textBox1.Text = string.Join(Environment.NewLine, selectedfiles);
                

            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            string inputtext =textBox1.Text;
            string[] filePaths=inputtext.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string filepath in filePaths)
            {
                if (!checkedListBox2.Items.Contains(filepath))
                {
                    checkedListBox2.Items.Add(filepath);
                }
            }

        }

        private void button17_Click(object sender, EventArgs e)
        {
            checkedListBox2.Items.Clear();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            for (int i = checkedListBox2.SelectedIndices.Count - 1; i >= 0; i--)
            {
                int selectedIndex = checkedListBox2.SelectedIndices[i];
                checkedListBox2.Items.RemoveAt(selectedIndex);
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            foreach (var item in checkedListBox2.Items)
            {
                if (!checkedListBox1.Items.Contains(item))
                {
                    checkedListBox1.Items.Add(item);
                }
                //if (!checkedListBox3.Items.Contains(item))
                //{
                //    checkedListBox3.Items.Add(item);
                //}

            }
        }
        private void PlayMediaFilesInOrder(System.Windows.Forms.CheckedListBox.CheckedItemCollection checkedItems)
        {
            foreach (var item in checkedItems)
            {
                string mediaFilepath = item.ToString();
                axWindowsMediaPlayer1.URL = mediaFilepath;
                axWindowsMediaPlayer1.Ctlcontrols.play();
                while (axWindowsMediaPlayer1.playState != WMPLib.WMPPlayState.wmppsStopped)
                {
                    Application.DoEvents();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

        }

        private void button20_Click(object sender, EventArgs e)
        {
            var checkedıtems = checkedListBox1.CheckedItems;
            PlayMediaFilesInOrder(checkedıtems);
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            //if(checkedListBox1.Items.Count == 0)  return; 
            //string currentItem = checkedListBox1.Items[currentIndex].ToString();
            //PlayMediaFilesInOrder(currentItem);

            //currentIndex++;
            //if (currentIndex >= checkedListBox1.Items.Count)
            //{
            //    currentIndex = 0;
            //}
        }
    }
}
