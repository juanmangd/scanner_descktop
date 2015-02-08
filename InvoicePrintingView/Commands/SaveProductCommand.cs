using System;
using System.Windows.Input;
using InvoiceViewModel;
using System.Windows;
using InvoicePrintingView;

namespace InvoicePrintingView
{
    public class SaveProductCommand : ICommand
    {
         #region Fields

        // Member variables
        private readonly SaveProductVM m_ViewModel;

        #endregion

        #region Constructor

        public SaveProductCommand(SaveProductVM viewModel)
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
            if (null != m_ViewModel.SaveProductCode &&
                null != m_ViewModel.SaveProductDescription &&
                null != m_ViewModel.SaveProductBarcode &&
                null != m_ViewModel.SaveProductPrice &&
                null != m_ViewModel.SaveProductPartner &&
                null != m_ViewModel.SaveProductCreatedBy)
            {
                if (m_ViewModel.CreateProduct(m_ViewModel.SaveProductCode,
                                                m_ViewModel.SaveProductDescription,
                                                m_ViewModel.SaveProductBarcode,
                                                 m_ViewModel.SaveProductPrice,
                                                 m_ViewModel.SaveProductPartner,
                                                 m_ViewModel.SaveProductCreatedBy
                    ))
                {
                    MessageBoxResult result = MessageBox.Show("Successfully added product", "Success", MessageBoxButton.OK);
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show("Adding product failed", "Error", MessageBoxButton.OK);
                }
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Error", "Error", MessageBoxButton.OK);
            }
        }

        #endregion
    }
}
