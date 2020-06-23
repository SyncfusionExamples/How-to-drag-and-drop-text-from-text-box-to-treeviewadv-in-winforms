using Syncfusion.Windows.Forms;
using Syncfusion.Windows.Forms.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TreeViewAdv_DragAndDrop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            this.treeViewAdv1.AllowDrop = true;
            this.treeViewAdv1.DragEnter += TreeViewAdv1_DragEnter;
            this.treeViewAdv1.DragDrop += new DragEventHandler(treeViewAdv1_DragDrop);
            Form2 form = new Form2();
            form.Show();
        }

        private void TreeViewAdv1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void treeViewAdv1_DragDrop(object sender, DragEventArgs e)
        {
            TreeNodeAdv node = new TreeNodeAdv();
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                Point pt = ((TreeViewAdv)sender).PointToClient(new Point(e.X, e.Y));
                TreeNodeAdv dn = ((TreeViewAdv)sender).GetNodeAtPoint(pt);
                node = new TreeNodeAdv(e.Data.GetData(DataFormats.Text).ToString());
                dn.Nodes.Add(node);
                dn.Expand();
            }
        }
    }
}
