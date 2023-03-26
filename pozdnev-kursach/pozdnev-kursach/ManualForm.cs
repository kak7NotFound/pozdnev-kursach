using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace pozdnev_kursach
{
    public partial class ManualForm : Form
    {
        
        public Dictionary<string, string> paths = new Dictionary<string, string>();

        public ManualForm()
        {
            InitializeComponent();
            InitializeTree();
        }

        private void InitializeTree()
        {

            string[] folder = Directory.GetDirectories("./sites/");
            
            foreach(string filePath in folder)
            {
                
                var n = treeView1.Nodes.Add(filePath.Split('/')[2]);

                foreach (var file in Directory.GetFiles(filePath))
                {
                    paths.Add(file.Split('\\')[1], file);
                    n.Nodes.Add(file.Split('\\')[1]);
                }
                
            }
            
            
            
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var value = "";
            paths.TryGetValue(treeView1.SelectedNode.Text, out value);
            try
            {
                webBrowser1.DocumentText = File.ReadAllText(value);
            }
            catch (Exception exception)
            {
                webBrowser1.DocumentText = value;
            }
        }

        private void ManualForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            new Form1().Show();
        }
    }
}