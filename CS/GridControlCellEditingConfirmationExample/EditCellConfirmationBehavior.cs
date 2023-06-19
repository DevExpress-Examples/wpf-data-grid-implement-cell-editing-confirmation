using DevExpress.Mvvm.UI.Interactivity;
using DevExpress.Xpf.Grid;
using System.Windows;

namespace GridControlCellEditingConfirmationExample {
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
}
