using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using InvoiceViewModel;
using System.Windows.Controls.Primitives;
using System.ComponentModel;

namespace InvoicePrintingView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            base.DataContext = new Product();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            /*
            var dpd = DependencyPropertyDescriptor.FromProperty(ItemsControl.ItemsSourceProperty, typeof(DataGrid));
            if (dpd != null)
            {
                dpd.AddValueChanged(MainGrid, ThisIsCalledWhenPropertyIsChanged);
            }*/
        }

        private void ThisIsCalledWhenPropertyIsChanged(object sender, EventArgs e)
        {
        }
    }
}
