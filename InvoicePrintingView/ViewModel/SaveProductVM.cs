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
using InvoicePrintingView;

namespace InvoicePrintingView
{
    public class SaveProductVM : ViewModelBase
    {
        public String SaveProductCode { get; set; }
        public String SaveProductDescription { get; set; }
        public String SaveProductBarcode { get; set; }
        public String SaveProductPrice { get; set; }
        public String SaveProductPartner { get; set; }
        public String SaveProductCreatedBy { get; set; }

        AddProductWindow addProductWindow;

        public ICommand SaveCommandProduct { get; set; }

        public SaveProductVM(AddProductWindow addproductwindow)
        {
            SaveProductCreatedBy = App.Current.Properties["LoginUsername"].ToString();
            this.addProductWindow = addproductwindow;
            SaveCommandProduct = new SaveProductCommand(this);
        }

        public bool CreateProduct(string code, string description, string barcode, string price, string sourceParner, string createdBy)
        {
            return MySqlHelper.CreateProduct( code,  description,  barcode,  price,  sourceParner,  createdBy);
        }
    }
}
