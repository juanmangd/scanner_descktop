using System;
using System.Windows.Input;
using System.Windows;
using InvoicePrintingView;

namespace InvoiceViewModel
{

    public class LoginCommand : ICommand
    {
        #region Fields

        // Member variables
        private readonly DBUserVM m_ViewModel;

        #endregion

        #region Constructor

        public LoginCommand(DBUserVM viewModel)
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
            if (null != m_ViewModel.LoginPassword && null != m_ViewModel.LoginUsername)
            {
                bool isAdmin = false;

                if (m_ViewModel.checkAuthenication(m_ViewModel.LoginUsername, m_ViewModel.LoginPassword, ref isAdmin))
                {
                    if (isAdmin)
                    {
                        m_ViewModel.LaunchAdminMenuView(m_ViewModel.LoginUsername);
                        App.Current.Properties["LoginUsername"] = m_ViewModel.LoginUsername;
                    }
                    else
                    {
                        m_ViewModel.LaunchInvoiceView();
                    }
                    m_ViewModel.CloseLoginWindow();
                }
                else
                {
                   
                    MessageBoxResult result = MessageBox.Show("Invalid Username or Passwprd", "Error", MessageBoxButton.OK);
                    if (result == MessageBoxResult.Yes)
                    {
                        // Yes code here
                    }
                    else if (result == MessageBoxResult.No)
                    {
                        // No code here
                    }
                    else
                    {
                        // Cancel code here
                    } 
                }

            }
        }

        #endregion
    }
}
