using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;


namespace WindowsFormsApp1
{
    public partial class csTextEditor : Form
    {
        // declare private 'globals' here
        private FolderBrowserDialog folderBrowserDialog1;
        private RichTextBox richTextBox1;
        private OpenFileDialog openFileDialog1;
        private string openFileName, folderName;
        private bool fileOpened = false;

 

        public csTextEditor()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("blah");
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            FileAttributes attr = File.GetAttributes(e.Node.Text);
            if (attr == FileAttributes.Directory)
            {
                String[] dirFiles = Directory.GetFileSystemEntries(e.Node.Text);
                for (int i = 0; i < dirFiles.Length; i++)
                {
                    TreeNode dirFileNode = new TreeNode();
                    dirFileNode.Text = dirFiles[i];
                    e.Node.Nodes.Add(dirFileNode);
                   
                }
                e.Node.Expand();
            }
            else
            {
                if (Path.GetExtension(e.Node.Text) == ".txt")
                {
                    label3.Text = e.Node.Text;
                    textBox1.Text = File.ReadAllText(e.Node.Text);
                } else
                {
                    MessageBox.Show("We don't support that file.\n Chill out bro.");
                }
            }

            // pseudocode

            // if Directory.GetFiles();d
            //  checkForNodes();
            // else
            //  openTreeNode();
            // end
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void button2_InitLayout()
        {
            button2.ForeColor = ColorTranslator.FromHtml("#000000");
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            String activePath = label3.Text;
            String[] fileLines = textBox1.Lines;
            // save the file
            File.WriteAllLines(activePath, fileLines);
            MessageBox.Show("Saved Successfully");
        }


        private void button1_Click(object sender, System.EventArgs e)
            {
                Stream myStream = null;
                FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
                DialogResult result = folderBrowserDialog1.ShowDialog();
                TreeNode treeNode = new TreeNode();
                treeNode.Tag = folderBrowserDialog1.SelectedPath;
                treeNode.Text = folderBrowserDialog1.SelectedPath;
                treeView1.Nodes.Add(treeNode);

            if (result == DialogResult.OK)
            {
                String[] filesArr = Directory.GetFileSystemEntries(folderBrowserDialog1.SelectedPath);
                for (int i = 0; i < filesArr.Length; i++)
                {
                    string s = filesArr[i];
                    if (File.GetAttributes(filesArr[i]) == FileAttributes.Directory)
                    {
                        TreeNode dirNode = new TreeNode();
                        dirNode.Text = filesArr[i];
                        treeNode.Nodes.Add(filesArr[i]);                       
                    }
                    else
                    {
                        TreeNode fileNode = new TreeNode();
                        fileNode.Text = filesArr[i];
                        if (Path.GetExtension(fileNode.Text) == ".txt")
                        {
                            fileNode.ForeColor = ColorTranslator.FromHtml("#ffffff");

                        }
                        else
                        {
                            fileNode.ForeColor = ColorTranslator.FromHtml("#ff0000");

                        }
                        treeNode.Nodes.Add(fileNode);


                    }
                }
                treeView1.ExpandAll();
            }
        }
    }
}
