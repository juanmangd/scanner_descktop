using System;
using System.Windows.Input;
using System.Windows;
namespace InvoiceViewModel
{

    public class AddItemCommand : ICommand
    {
        #region Fields

        // Member variables
        private readonly ViewModel m_ViewModel;

        #endregion

        #region Constructor

        public AddItemCommand(ViewModel viewModel)
        {
            m_ViewModel = viewModel;
        }

        #endregion

        #region ICommand Members

/// <summary>
/// Whether this command can be executed.
/// </summary>
public bool CanExecute(object parameter)
{
    return true;
}

        /// <summary>
        /// Fires when the CanExecute status of this command changes.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// Invokes this command to perform its intended task.
        /// </summary>
        public void Execute(object parameter)
        {
            if (null != m_ViewModel.ScannedItemBarcode)
            {
                int quantity = 1;

                if (null != m_ViewModel.ScannedQuantity)
                {
                    quantity = int.Parse(m_ViewModel.ScannedQuantity);
                }

                Product productFromDB = m_ViewModel.CheckIfProductExist(m_ViewModel.ScannedItemBarcode);
                if (null != productFromDB)
                {
                    productFromDB.Quantity = productFromDB.Quantity + quantity;
                    return;
                }

                DBProduct p = m_ViewModel.GetProductForBarcode(m_ViewModel.ScannedItemBarcode);
                if (null != p)
                {
                    Product modelp = new Product(m_ViewModel, p.Partner, quantity, p.Code, long.Parse(p.Barcode), p.Creator, p.Description, double.Parse(p.UnitPrice), m_ViewModel.ItemCount);

                    m_ViewModel.OBProductList.Add(modelp);
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show("Scanned barcode does not exist in database", "Database Error", MessageBoxButton.OK);
                }
            }
           
        }

        #endregion
    }
}
