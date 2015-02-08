using System;
using System.Windows.Input;
using InvoiceViewModel;
using System.Windows;
namespace InvoicePrintingView.Commands
{
    public class SaveUserCommand : ICommand
    {
         #region Fields

        // Member variables
        private readonly SaveUserVM m_ViewModel;

        #endregion

        #region Constructor

        public SaveUserCommand(SaveUserVM viewModel)
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
            if (null != m_ViewModel.Username && null != m_ViewModel.Password && null != m_ViewModel.Role)
            {
                if (m_ViewModel.CreateUser(m_ViewModel.Username, m_ViewModel.Password, m_ViewModel.Role))
                {
                    MessageBoxResult result = MessageBox.Show("Successfully added user", "Success", MessageBoxButton.OK);
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show("Adding user failed", "Error", MessageBoxButton.OK);
                }
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Cannot Add User", "Error", MessageBoxButton.OK);
            }
        }

        #endregion
    }
}
