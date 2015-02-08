using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvoiceViewModel;
using System.Data;
using LoginForm;
using System.Windows.Input;
using InvoicePrintingView.Commands;

namespace InvoiceViewModel
{

    public class SaveUserVM : ViewModelBase
    {
        public String Username { get; set; }
        public String Password { get; set; }
        public String Role { get; set; }

        AddUser addUserWindow;

        public ICommand SaveUserCommand { get; set; }

        public SaveUserVM(AddUser adduserwindow)
        {
            this.addUserWindow = adduserwindow;
            SaveUserCommand = new SaveUserCommand(this);
        }

        public bool CreateUser(string username, string password, string role)
        {
            return (MySqlHelper.CreateUser(username, password, role.ToLower()));
        }
    }
}
