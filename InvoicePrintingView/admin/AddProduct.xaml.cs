using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using InvoiceViewModel;
using System.Data;
using InvoicePrintingView;

namespace LoginForm
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class AddProductWindow : Window
	{
        public AddProductWindow()
		{
			this.InitializeComponent();
            this.DataContext = new SaveProductVM(this);
		}

		private void Rectangle_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			DragMove();
		}

		private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			this.Close();
		}

	}
}