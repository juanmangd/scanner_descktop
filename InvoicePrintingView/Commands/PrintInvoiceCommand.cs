using System;
using System.Windows.Input;

namespace InvoiceViewModel
{

    public class PrintInvoiceCommand : ICommand
    {
        #region Fields

        // Member variables
        private readonly ViewModel m_ViewModel;

        #endregion

        #region Constructor

        public PrintInvoiceCommand(ViewModel viewModel)
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
            m_ViewModel.PrintInvoiceFromList(); 
        }

        #endregion
    }
}
