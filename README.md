<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/653981184/22.2.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T1171977)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
# WPF Data Grid - Implement Cell Editing Confirmation Dialog

This example demonstrates how to utilize the `ValidateCell` event of GridControl's view to confirm whether cell changes should be applied. Use the `HideEditor` method of GridControl's view to discard changes.

## Implementation details

This solution requires handling a UI event and calling a method of a control. To do this and comply with MVVM principles, the logic is isolated to a custom behavior for TableView.

```xaml
<dxg:GridControl.View>
    <dxg:TableView>
        <dxmvvm:Interaction.Behaviors>
            <local:EditCellConfirmationBehavior/>
        </dxmvvm:Interaction.Behaviors>
    </dxg:TableView>
</dxg:GridControl.View>
```

The following method demonstrates how to implement validation for a specific column.
```cs
private void AssociatedObject_ValidateCell(object sender, GridCellValidationEventArgs e) {
    if (e.Column.FieldName == nameof(Item.Growth) &&
        MessageBox.Show("Do you wish to update the value?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.No) {
        AssociatedObject.HideEditor();
    }
}
```

## Files to Review

- [MainWindow.xaml](./CS/GridControlCellEditingConfirmationExample/MainWindow.xaml)
- [MainViewModel.cs](./CS/GridControlCellEditingConfirmationExample/MainViewModel.cs) 
- [EditCellConfirmationBehavior.cs](./CS/GridControlCellEditingConfirmationExample/EditCellConfirmationBehavior.cs) 

## Documentation
- [ValidateCell](ValidateCell)
- [HideEditor()](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.DataViewBase.HideEditor)

