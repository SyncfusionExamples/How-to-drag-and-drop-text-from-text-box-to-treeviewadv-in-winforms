# How to drag and drop TextBox text to WinForms TreeViewAdv control between two forms?

To drag and drop TextBox text from one form to [WinForms TreeViewAdv]() control on another form, **AllowDrop** property should be enabled for both controls and **DragEnter** and **DragDrop** events should be used in TreeViewAdv.

**C#:**
```csharp
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

**VB.Net:**
```vbnet
Me.treeViewAdv1.AllowDrop = True

' Add event handlers
AddHandler Me.treeViewAdv1.DragEnter, AddressOf TreeViewAdv1_DragEnter
AddHandler treeViewAdv1.DragDrop, AddressOf treeViewAdv1_DragDrop

Private Sub TreeViewAdv1_DragEnter(sender As Object, e As DragEventArgs)
    e.Effect = DragDropEffects.Copy
End Sub

Private Sub treeViewAdv1_DragDrop(sender As Object, e As DragEventArgs)
    Dim node As New TreeNodeAdv()

    If e.Data.GetDataPresent(DataFormats.Text) Then
        Dim pt As Point = CType(sender, TreeViewAdv).PointToClient(New Point(e.X, e.Y))
        Dim dn As TreeNodeAdv = CType(sender, TreeViewAdv).GetNodeAtPoint(pt)
        
        node = New TreeNodeAdv(e.Data.GetData(DataFormats.Text).ToString())
        dn.Nodes.Add(node)
        dn.Expand()
    End If
End Sub
```

View Sample in GitHub
