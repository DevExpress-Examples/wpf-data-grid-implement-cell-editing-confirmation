<!-- default badges list -->
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T1171977)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->

# WPF Data Grid - Implement an Edit Cell Confirmation

This example demonstrates how to invoke a confirmation dialog that allows users to apply or discard changes made in a cell.

![image](https://github.com/DevExpress-Examples/wpf-data-grid-implement-cell-editing-confirmation/assets/65009440/7970e6c4-c0e9-4b67-a065-a03dc407910d)

Handle the [GridViewBase.ValidateCell](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.GridViewBase.ValidateCell) event (raised before the modified value is posted to the cell) and display a `MessageBox` with a confirmation message. If a user clicks **No**, call the [DataViewBase.HideEditor](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.DataViewBase.HideEditor) method to discard changes.

## Implementation Details

You can implement a custom attached behavior to interact with events and methods of a UI element ([TableView](https://docs.devexpress.com/WPF/6294/controls-and-libraries/data-grid/views/table-view) in this example) according to the MVVM pattern:

```xaml
<dxg:GridControl.View>
    <dxg:TableView>
        <dxmvvm:Interaction.Behaviors>
            <local:EditCellConfirmationBehavior/>
        </dxmvvm:Interaction.Behaviors>
    </dxg:TableView>
</dxg:GridControl.View>
```

```cs
public class EditCellConfirmationBehavior : Behavior<TableView> {
    protected override void OnAttached() {
        base.OnAttached();
        AssociatedObject.ValidateCell += AssociatedObject_ValidateCell;
    }
    private void AssociatedObject_ValidateCell(object sender, GridCellValidationEventArgs e) {
        if (e.Column.FieldName == nameof(Item.Growth) &&
            MessageBox.Show("Do you wish to update the value?", "Confirmation", MessageBoxButton.YesNo) ==
            MessageBoxResult.No) {
            AssociatedObject.HideEditor();
        }
    }
    protected override void OnDetaching() {
        AssociatedObject.ValidateCell -= AssociatedObject_ValidateCell;
        base.OnDetaching();
    }
}
```

## Files to Review

- [MainWindow.xaml](./CS/GridControlCellEditingConfirmationExample/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/GridControlCellEditingConfirmationExample/MainWindow.xaml))
- [MainViewModel.cs](./CS/GridControlCellEditingConfirmationExample/MainViewModel.cs) (VB: [MainViewModel.vb](./VB/GridControlCellEditingConfirmationExample/MainViewModel.vb))
- [EditCellConfirmationBehavior.cs](./CS/GridControlCellEditingConfirmationExample/EditCellConfirmationBehavior.cs) (VB: [EditCellConfirmationBehavior.vb](./VB/GridControlCellEditingConfirmationExample/EditCellConfirmationBehavior.vb))

## Documentation

- [ValidateCell](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.GridViewBase.ValidateCell)
- [HideEditor()](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.DataViewBase.HideEditor)
- [Cell Validation](https://docs.devexpress.com/WPF/6113/controls-and-libraries/data-grid/data-editing-and-validation/input-validation/cell-validation)
- [Create a Custom Behavior](https://docs.devexpress.com/WPF/17442/mvvm-framework/behaviors#create-a-custom-behavior)

## More Examples

- [WPF Data Grid - Validate Cell Editors](https://github.com/DevExpress-Examples/wpf-data-grid-validate-cell-editors)
