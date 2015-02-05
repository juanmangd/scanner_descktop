using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Data;

namespace InvoiceViewModel
{
    public class Product : ObservableObject, ISequencedObject
    {
        private int p_SequenceNumber;
        private double _tax;
        private string _creator;
        private int _invoiceID;
        private double _subTotal;
        private long _barcodeNumber;
        private string _productName;
        private int _quantity;
        private double _unitPrice;
        private int p_ItemCount;
        private ObservableCollection<Product> p_ProductList;
        private double _totalPrice;
        private string _code;
        private string _description;
        private string _partner;
        static List<Product> produtListFromDB; 
        
        static void GetProductDetails()
        {
            if (null == produtListFromDB)
            {
                produtListFromDB = new List<Product>();

                DataSet dataSet = MySqlHelper.GetAllProducts();
                var table = dataSet.Tables[0];

                foreach (DataRow row in table.Rows)
                {
                    string productCode = row["code"].ToString();
                    string description = row["description"].ToString();
                    string barcode = row["barcode"].ToString();
                    string price = row["price"].ToString();
                    string partner = row["partner"].ToString();
                    string created_by = row["created_by"].ToString();
                    Product pd = new Product();
                    pd.Code = productCode;
                    pd.Description = description;
                    pd.Barcode = long.Parse(barcode);
                    pd.UnitPrice = double.Parse(price);
                    pd.Partner = partner;
                    pd.Creator = created_by;
                    produtListFromDB.Add(pd);
                }
            }
        }
        public string Creator
        {
            get { return this._creator; }
            set
            {
                this._creator = value;
                base.RaisePropertyChangedEvent("Creator");
            }

        }

        public string Partner
        {
            get { return this._partner; }
            set
            {
                this._partner = value;
                base.RaisePropertyChangedEvent("Partner");
            }

        }

        public string Code
        {
            get { return this._code; }
            set
            {
                this._code = value;
                base.RaisePropertyChangedEvent("Code");
            }

        }

        public string Description
        {
            get { return this._description; }
            set
            {
                this._description = value;
                base.RaisePropertyChangedEvent("Description");
            }

        }

        public Product()
        {
            this._totalPrice = 0;
            this._productName = "";
            this._quantity = 1;
            this._unitPrice = 0f;
            this._barcodeNumber = 0;
            //productList = new List<Product>();

            // Create grocery list
            p_ProductList = new ObservableCollection<Product>();

            // Subscribe to CollectionChanged event
            p_ProductList.CollectionChanged += OnProductListChanged;
            // Initialize list index
            this.OBProductList = SequencingService.SetCollectionSequence(this.OBProductList);

            // Update bindings
            base.RaisePropertyChangedEvent("OBProductList");

        }

        public Product GetProduct( long barcode)
        {
            
            foreach(Product pd in produtListFromDB)
            {
                if (pd.Barcode == barcode)
                    return pd;
            }
            return null;
        }

        void OnProductListChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            GetProductDetails();
            // Update item count
            this.ItemCount = this.p_ProductList.Count;

            // Resequence list
            SequencingService.SetCollectionSequence(this.p_ProductList);

            double totalPrice = 0;
            ObservableCollection<Product> obsColl = p_ProductList;
            foreach (Product data in obsColl)
            {
               Product pd = GetProduct(data.Barcode);
               if (null != pd)
               {
                   this.UnitPrice = pd.UnitPrice;
                   this.Description = pd.Description;
               }

                double subtotal = data.UnitPrice * data.Quantity;
                totalPrice = totalPrice + subtotal;
            }

            this._totalPrice = totalPrice;
            base.RaisePropertyChangedEvent("Description");
            base.RaisePropertyChangedEvent("UnitPrice");
            base.RaisePropertyChangedEvent("TotalPrice");
        }

        public double TotalPrice
        {
            get
            {

                return (this._totalPrice);
            }
            
        }


        public ObservableCollection<Product> OBProductList
        {
            get { return p_ProductList; }

            set
            {
                p_ProductList = value;
                base.RaisePropertyChangedEvent("OBProductList");
            }
        }

       
        
        public int ItemCount
        {
            get { return p_ItemCount; }

            set
            {
                p_ItemCount = value;
                base.RaisePropertyChangedEvent("ItemCount");
            }
        }

        public double SubTotal
        {
            get {

                return (this._quantity * this._unitPrice); 
            }
            set 
            {
                this._subTotal =  _quantity * _unitPrice;
                base.RaisePropertyChangedEvent("SubTotal"); 
            }
        }

       
        public string ProductName
        {
            get { return this._productName; }
            set { 
                    this._productName = value;
                    base.RaisePropertyChangedEvent("ProductName");
                }
                
        }

        public int Quantity
        {
            get { return this._quantity; }
            set { this._quantity = value; 
                
                base.RaisePropertyChangedEvent("Quantity");
                base.RaisePropertyChangedEvent("SubTotal"); 
            }
        }

        public double UnitPrice
        {
            get { return this._unitPrice; }
            set { this._unitPrice = value; 
                
                base.RaisePropertyChangedEvent("UnitPrice");
                base.RaisePropertyChangedEvent("SubTotal"); 
            }
        }

        public long Barcode
        {
            get { return _barcodeNumber; }
            set { 
                
                    this._barcodeNumber = value;
                    base.RaisePropertyChangedEvent("Barcode");
               }
        }

        public void InvoiceItem(string name, double price, int quantity, int barCode, int itemIndex)
        {
            this.ProductName = name;
            this.UnitPrice = price;
            this.Quantity = quantity;
            _barcodeNumber = barCode;
            p_SequenceNumber = itemIndex;
        }

        public Product(string name, double price, int quantity, int barCode)
        {
            this.ProductName = name;
            this.UnitPrice = price;
            this.Quantity = quantity;
            this._barcodeNumber = barCode;
           
        }

        
        public int InvoiceID
        {
            get { return _invoiceID; }
            set { this._invoiceID = value; }
        }

        public double Tax
        {
            get { return _tax; }
            set { 
                this._tax = value;
                base.RaisePropertyChangedEvent("Tax");
            }
        }

        public int SequenceNumber
        {
            get { return this.p_SequenceNumber; }

            set
            {
                this.p_SequenceNumber = value;
                base.RaisePropertyChangedEvent("SequenceNumber");
            }
        }

        public override string ToString()
        {
            return Barcode.ToString();
        }

    }
}
