Imports DevExpress.Mvvm.UI.Interactivity
Imports DevExpress.Xpf.Grid
Imports System.Windows

Namespace GridControlCellEditingConfirmationExample

    Public Class EditCellConfirmationBehavior
        Inherits Behavior(Of TableView)

        Protected Overrides Sub OnAttached()
            MyBase.OnAttached()
            AddHandler AssociatedObject.ValidateCell, AddressOf AssociatedObject_ValidateCell
        End Sub

        Private Sub AssociatedObject_ValidateCell(ByVal sender As Object, ByVal e As GridCellValidationEventArgs)
            If Equals(e.Column.FieldName, NameOf(Item.Growth)) AndAlso MessageBox.Show("Do you wish to update the value?", "Confirmation", MessageBoxButton.YesNo) = MessageBoxResult.No Then
                AssociatedObject.HideEditor()
            End If
        End Sub

        Protected Overrides Sub OnDetaching()
            RemoveHandler AssociatedObject.ValidateCell, AddressOf AssociatedObject_ValidateCell
            MyBase.OnDetaching()
        End Sub
    End Class
End Namespace
