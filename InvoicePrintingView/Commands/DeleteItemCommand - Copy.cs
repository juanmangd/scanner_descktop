using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
//using System.Windows.Input;

namespace InvoiceViewModel
{
    public class DeleteItemCommand : ICommand
    {
        private readonly InvoiceVM m_ViewModel;

        public DeleteItemCommand(InvoiceVM viewModel)
        {
            m_ViewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return (m_ViewModel.SelectedItem != null);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            var selectedItem = m_ViewModel.SelectedItem;
            m_ViewModel.OBProductList.Remove(selectedItem);
        }
    }
}
