using System;
using System.Windows.Input;

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
                if (m_ViewModel.checkAuthenication(m_ViewModel.LoginUsername, m_ViewModel.LoginPassword))
                {
                    m_ViewModel.CloseLoginWindow();
                }

            }
        }

        #endregion
    }
}
