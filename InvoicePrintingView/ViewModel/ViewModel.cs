using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Data;
using InvoiceViewModel;
using System.Windows.Input;

namespace InvoiceViewModel
{
    public class ViewModel : ViewModelBase
    {
        private ObservableCollection<Product> p_ProductList;
        private double _totalPrice;
        private int p_ItemCount;
        static List<DBProduct> produtListFromDB;
        public ICommand AddItem { get; set; }
        public String ScannedItemBarcode { get; set; }
        public String ScannedQuantity { get; set; }

        public void UpdateTotalPrice()
        {
            base.RaisePropertyChangedEvent("TotalPrice"); 
        }

        static void GetProductDetails()
        {
            if (null == produtListFromDB)
            {
                produtListFromDB = new List<DBProduct>();

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
                    DBProduct pd = new DBProduct();
                    pd.Code = productCode;
                    pd.Description = description;
                    pd.Barcode = barcode;
                    pd.UnitPrice = price;
                    pd.Partner = partner;
                    pd.Creator = created_by;
                    produtListFromDB.Add(pd);
                }
            }
        }


        public double TotalPrice
        {
            get
            {
                double totalPrice = 0;
                ObservableCollection<Product> obsColl = p_ProductList;
                foreach (Product data in obsColl)
                {
                    double subtotal = data.UnitPrice * data.Quantity;
                    totalPrice = totalPrice + subtotal;
                }
                this._totalPrice = totalPrice;
                return (this._totalPrice);
            }
            set
            {
                this._totalPrice = value;
                base.RaisePropertyChangedEvent("TotalPrice");
            }

        }

        public DBProduct GetProductForBarcode(string barcode)
        {
            foreach (DBProduct p in produtListFromDB)
            {
                if (barcode == p.Barcode)
                    return p;
            }
            return null;
        }

        public ViewModel()
        {
            _totalPrice =0;
            if (null == p_ProductList)
            {
                GetProductDetails();

                this.AddItem = new AddItemCommand(this);

                // Create grocery list
                p_ProductList = new ObservableCollection<Product>();

                // Subscribe to CollectionChanged event
                p_ProductList.CollectionChanged += OnProductListChanged;
                // Initialize list index
                this.OBProductList = SequencingService.SetCollectionSequence(this.OBProductList);
                // Update bindings
                base.RaisePropertyChangedEvent("OBProductList");
            }

           
        }

        public DBProduct GetProduct(long barcode)
        {

            foreach (DBProduct pd in produtListFromDB)
            {
                if (pd.Barcode == barcode.ToString())
                    return pd;
            }
            return null;
        }


        void OnProductListChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
          
            this.ItemCount = this.p_ProductList.Count;

            // Resequence list
            SequencingService.SetCollectionSequence(this.p_ProductList);
            /*
            double totalPrice = 0;
            ObservableCollection<Product> obsColl = p_ProductList;
            foreach (Product data in obsColl)
            {
                double subtotal = data.UnitPrice * data.Quantity;
                totalPrice = totalPrice + subtotal;
            }
            this._totalPrice = totalPrice;
            */
           base.RaisePropertyChangedEvent("TotalPrice");
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


       
    }
}
