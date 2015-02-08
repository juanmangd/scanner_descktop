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

namespace InvoicePrintingView
{
    public class AdminMenuVM : ViewModelBase
    {
        public String SaveProductCode { get; set; }
    }
}
