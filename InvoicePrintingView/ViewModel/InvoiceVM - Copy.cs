using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace InvoiceViewModel
{
    public class InvoiceVM : ViewModelBase
    {
       
        private ObservableCollection<Product> p_ProductList;
        private int p_ItemCount;

        public InvoiceVM()
        {
            this.Initialize();
            p_ItemCount = 0;
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

        void OnGroceryListChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            // Update item count
            this.ItemCount = this.OBProductList.Count;

            // Resequence list
            SequencingService.SetCollectionSequence(this.OBProductList);
        }

        public Product SelectedItem {
            get; 
            set; 
        }

        public ICommand DeleteItem { get; set; }

        public ObservableCollection<Product> OBProductList
        {
            get { return p_ProductList; }

            set
            {
                p_ProductList = value;
                base.RaisePropertyChangedEvent("OBProductList");
            }
        }

        private void Initialize()
        {
            // Initialize commands
            this.DeleteItem = new DeleteItemCommand(this);

            // Create grocery list
            p_ProductList = new ObservableCollection<Product>();

            // Subscribe to CollectionChanged event
            p_ProductList.CollectionChanged += OnGroceryListChanged;
            // Initialize list index
            this.OBProductList = SequencingService.SetCollectionSequence(this.OBProductList);

            // Update bindings
            base.RaisePropertyChangedEvent("OBProductList");
        }





    }
}
