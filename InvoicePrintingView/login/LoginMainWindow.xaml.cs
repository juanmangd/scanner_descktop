﻿using System;
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
namespace LoginForm
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
       

		public MainWindow()
		{
			this.InitializeComponent();
            this.DataContext = new DBUserVM(this);
		}

		private void Rectangle_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			DragMove();
		}

		private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			this.Close();
		}

        
		private void loginbutton_Click(object sender, System.Windows.RoutedEventArgs e)
		{

		}

		private void exitbutton_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			this.Close();
		}

		private void Window_Loaded(object sender, System.Windows.RoutedEventArgs e)
		{
            username.Focus();            
		}
	}
}