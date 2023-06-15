Imports DevExpress.Mvvm
Imports System.Collections.ObjectModel

Namespace GridControlCellEditingConfirmationExample

    Public Class MainViewModel
        Inherits ViewModelBase

        Public ReadOnly Property Source As ObservableCollection(Of Item) = New ObservableCollection(Of Item)(Item.GetData(100))
    End Class
End Namespace
