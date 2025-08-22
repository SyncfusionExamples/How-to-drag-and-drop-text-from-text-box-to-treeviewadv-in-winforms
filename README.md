# How to drag and drop text from text box to WinForms TreeView

This session explains about how to drag and drop text from text box to [WinForms TreeView](https://help.syncfusion.com/windowsforms/treeview/overview) (TreeViewAdv).

To drag and drop TextBox text from one form to `TreeViewAdv` control on another form, AllowDrop property should be enabled for both controls and `DragEnter` and `DragDrop` events should be used in `TreeViewAdv`.

``` csharp
this.treeViewAdv1.AllowDrop = true;
this.treeViewAdv1.DragEnter += TreeViewAdv1_DragEnter;
this.treeViewAdv1.DragDrop += new DragEventHandler(treeViewAdv1_DragDrop);

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
```

![](https://www.syncfusion.com/uploads/user/kb/wf/wf-45590/wf-45590_img1.png)