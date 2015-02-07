using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceViewModel
{
    public class DBProduct
    {
        public String Code { get; set; }
        public String Description { get; set; }
        public String Barcode { get; set; }
        public String UnitPrice { get; set; }
        public String Partner { get; set; }
        public String Creator { get; set; }
    }
}
