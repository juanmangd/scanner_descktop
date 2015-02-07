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
        private double _subTotal;
        private long _barcodeNumber;
        private string _productName;
        private int _quantity;
        private double _unitPrice;
        private double _totalPrice;
        private string _code;
        private string _description;
        private string _partner;
        ViewModel m_ViewModel;

        public Product(ViewModel vm, string _partner, int _quantity, string _code, long _barcodeNumber, string _creator, string _description, double _unitPrice, int itemIndex)
        {
            m_ViewModel = vm;
            this._creator = _creator;
            this._description = _description;
            p_SequenceNumber = itemIndex;
            this._barcodeNumber = _barcodeNumber;
            this._unitPrice = _unitPrice;
            this._code = _code;
            this._quantity = _quantity;
            this._partner = _partner;
        }


        public int SequenceNumber
        {
            get { return p_SequenceNumber; }

            set
            {
                p_SequenceNumber = value;
                base.RaisePropertyChangedEvent("SequenceNumber");
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
        }

        public double TotalPrice
        {
            get
            {

                return (this._totalPrice);
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
            set { 
                this._quantity = value;
                this.SubTotal = this._quantity * this.UnitPrice;
                base.RaisePropertyChangedEvent("Quantity");
                base.RaisePropertyChangedEvent("SubTotal");
                m_ViewModel.UpdateTotalPrice(); 
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

      
        public Product(string name, double price, int quantity, int barCode)
        {
            this.ProductName = name;
            this.UnitPrice = price;
            this.Quantity = quantity;
            this._barcodeNumber = barCode;
        }

        public double Tax
        {
            get { return _tax; }
            set { 
                this._tax = value;
                base.RaisePropertyChangedEvent("Tax");
            }
        }


        public override string ToString()
        {
            return Barcode.ToString();
        }

    }
}
