using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvoiceViewModel;
using System.Data;
using LoginForm;
using System.Windows.Input;

namespace InvoiceViewModel
{

    public class DBUserVM : ViewModelBase
    {
        List<DBUser> userListFromDB;
        public String LoginUsername { get; set; }
        public String LoginPassword { get; set; }
        LoginForm.MainWindow mloginwindow;
        InvoicePrintingView.MainWindow productlistWindow;
        AdminMenu adminmenu;
        public ICommand LoginCommand { get; set; }

        public DBUserVM(LoginForm.MainWindow loginwindow)
        {
            LoginCommand = new LoginCommand(this);
            this.mloginwindow = loginwindow;
            GetAllusersFromDB();
        }

        public void CloseLoginWindow()
        {
            this.mloginwindow.Close();
        }

        public void LaunchInvoiceView()
        {
            productlistWindow = new InvoicePrintingView.MainWindow();
            productlistWindow.Show();
        }

        public void LaunchAdminMenuView(string  loginusername)
        {
            adminmenu = new AdminMenu();
            adminmenu.Show();
        }

        /*
            if (checkAuthenication(username.Text, "admin"))
            {
                InvoicePrintingView.MainWindow mwindow;
                mwindow = new InvoicePrintingView.MainWindow();
                mwindow.Show();
                this.Close();
            }
        */
        public void GetAllusersFromDB()
        {


            if (null == userListFromDB)
            {
                userListFromDB = new List<DBUser>();

                DataSet dataSet = MySqlHelper.GetAllUsers();
                var table = dataSet.Tables[0];

                foreach (DataRow row in table.Rows)
                {
                    string userName = row["username"].ToString();
                    string password = row["password"].ToString();
                    string role = row["role"].ToString();
                    DBUser user = new DBUser();
                    user.Username = userName;
                    user.Password = password;
                    user.Role = role;
                    userListFromDB.Add(user);
                }
            }
        }

        public bool checkAuthenication(string username, string password, ref bool isAdmin)
        {
            if (null != userListFromDB)
            {
                foreach (DBUser user in userListFromDB)
                {
                    if (username == user.Username && user.Password == password)
                    {
                        if (user.Role == "admin")
                            isAdmin = true;
                        return true;
                    }
                }
            }
            return false;
        }

    }
}
