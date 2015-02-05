using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceViewModel
{
    public class ScannedProduc
    {
        public string barcode;
        public string amount;
        public string description;
        public string tax;
        public string product_id;
        public string created_by;
        public string invoiceID;

        public void save()
        {
            MySqlHelper.CreateScannedProduct(this);
        }
    }
}
