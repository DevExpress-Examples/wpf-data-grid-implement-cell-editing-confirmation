Imports DevExpress.Mvvm
Imports System
Imports System.Collections.Generic

Namespace GridControlCellEditingConfirmationExample

    Public Class Item
        Inherits BindableBase

        Public Property Name As String
            Get
                Return GetValue(Of String)()
            End Get

            Set(ByVal value As String)
                SetValue(value)
            End Set
        End Property

        Public Property Growth As Decimal
            Get
                Return GetValue(Of Decimal)()
            End Get

            Set(ByVal value As Decimal)
                SetValue(value)
            End Set
        End Property

        Public Sub New(ByVal name As String, ByVal growth As Decimal)
            Me.Name = name
            Me.Growth = growth
        End Sub

        Public Shared Iterator Function GetData(ByVal quantity As Integer) As IEnumerable(Of Item)
            Dim gen = New Random(42)
            For i As Integer = 0 To quantity - 1
                Dim name = $"Name# {i}"
                Dim growth = gen.Next(1, 1000)
                Yield New Item(name, growth)
            Next
        End Function
    End Class
End Namespace
