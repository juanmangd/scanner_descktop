using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Windows;
using InvoiceViewModel;

namespace InvoiceViewModel
{
    public class MySqlHelper
    {
        public static DataSet GetAllProducts()
        {
             MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);      
             conn.Open();

             MySqlCommand cmd = new MySqlCommand("Select code,description,barcode,price,partner,created_by from products", conn);
             MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
             DataSet ds = new DataSet();
             adp.Fill(ds, "dataGridProducts");

             return ds;
        }

        public static DataSet GetAllScannedProducts()
        {
            MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            conn.Open();

            MySqlCommand cmd = new MySqlCommand("Select barcode,amount,created_at,description from scanned_products", conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds, "dataGridProducts");

            return ds;
        }

        public static bool CreateProduct(string code, string description, string barcode, string price, string sourceParner, string createdBy)
        {
            MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            conn.Open();

            MySqlCommand comm = conn.CreateCommand();
            comm.CommandText = "INSERT INTO products(code,description,barcode,price,partner,created_by) VALUES(?code,?description,?barcode,?price,?partner,?created_by)";
            
            comm.Parameters.Add("?code",MySqlDbType.VarChar).Value = code;
            comm.Parameters.Add("?description", MySqlDbType.Text).Value = description;
            comm.Parameters.Add("?barcode", MySqlDbType.Int64).Value = barcode;
            comm.Parameters.Add("?price", MySqlDbType.Double).Value = price;
            comm.Parameters.Add("?partner", MySqlDbType.VarChar).Value = sourceParner;
            comm.Parameters.Add("?created_by", MySqlDbType.Int32).Value = createdBy;

         
            try
            {
                  comm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
              MessageBox.Show(  ex.Message);
            }

          
                return true;
      
        }

        internal static void CreateProduct(Product product)
        {
            CreateProduct(product.Code, product.Description, product.Barcode.ToString(), product.UnitPrice.ToString(), product.Partner, product.Creator);
        }


        internal static void CreateProduct(List<Product> products)
        {

            foreach (var product in products)
                CreateProduct(product.Code, product.Description, product.Barcode.ToString(), product.UnitPrice.ToString(), product.Partner, product.Creator);
        }

        /*
        bool ModifyProduct()
        {
            MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            conn.Open();

            MySqlCommand comm = conn.CreateCommand();
            comm.CommandText = "INSERT INTO products(code,description,barcode,price,partner) VALUES(?code,?description,?barcode,?price,?partner)";

            comm.Parameters.Add("?code", MySqlDbType.Double).Value = code;
            comm.Parameters.Add("?description", MySqlDbType.Text).Value = description;
            comm.Parameters.Add("?barcode", MySqlDbType.Int64).Value = barcode;
            comm.Parameters.Add("?price", MySqlDbType.Double).Value = price;
            comm.Parameters.Add("?partner", MySqlDbType.VarChar).Value = sourceParner;

            var result = comm.ExecuteNonQuery();

            if (result != 0)
                return true;
            else
                return false;
        }       */

        public bool DeleteProduct(string code)
        {
            MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            conn.Open();

            MySqlCommand comm = conn.CreateCommand();
            comm.CommandText = "DELETE  FROM products WHERE code= ?value";

            comm.Parameters.Add("?value", MySqlDbType.Double).Value = code;

            var result = comm.ExecuteNonQuery();

            if (result != 0)
                return true;
            else
                return false;
        }


        public bool CreateUser(string username, string password, string role)
        {
            MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            conn.Open();

            MySqlCommand comm = conn.CreateCommand();
            comm.CommandText = "INSERT INTO users(username,password,role) VALUES(?username,?password,?role)";

            comm.Parameters.Add("?username", MySqlDbType.VarChar).Value = username;
            comm.Parameters.Add("?password", MySqlDbType.Text).Value = password;
            comm.Parameters.Add("?role", MySqlDbType.VarChar).Value = role;
            

            var result = comm.ExecuteNonQuery();

            if (result != 0)
                return true;
            else
                return false;
        }


        

         /*
        bool ModifyUser()
        {
            MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            conn.Open();

            MySqlCommand comm = conn.CreateCommand();
            comm.CommandText = "INSERT INTO products(code,description,barcode,price,partner) VALUES(?code,?description,?barcode,?price,?partner)";

            comm.Parameters.Add("?code", MySqlDbType.Double).Value = code;
            comm.Parameters.Add("?description", MySqlDbType.Text).Value = description;
            comm.Parameters.Add("?barcode", MySqlDbType.Int64).Value = barcode;
            comm.Parameters.Add("?price", MySqlDbType.Double).Value = price;
            comm.Parameters.Add("?partner", MySqlDbType.VarChar).Value = sourceParner;

            var result = comm.ExecuteNonQuery();

            if (result != 0)
                return true;
            else
                return false;
        }       */

        public bool DeleteUser(string username)
        {
            MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            conn.Open();

            MySqlCommand comm = conn.CreateCommand();
            comm.CommandText = "DELETE  FROM users WHERE username = ?value";

            comm.Parameters.Add("?value", MySqlDbType.VarChar).Value = username;
           

            var result = comm.ExecuteNonQuery();

            if (result != 0)
                return true;
            else
                return false;
        }

        public static bool CreateScannedProduct(string barcode, string amount, string product_id, string created_by, string tax = "1")
        {
            MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            conn.Open();

            MySqlCommand comm = conn.CreateCommand();
            comm.CommandText = "INSERT INTO scanned_products(barcode,amount,product_id,created_by,tax) VALUES(?barcode,?amount,?product_id,?created_by,?tax)";

            comm.Parameters.Add("?barcode", MySqlDbType.Int64).Value = barcode;
            comm.Parameters.Add("?amount", MySqlDbType.Int32).Value = amount;
            comm.Parameters.Add("?product_id", MySqlDbType.Int64).Value = product_id;
            comm.Parameters.Add("?created_by", MySqlDbType.Double).Value = created_by;
            comm.Parameters.Add("?tax", MySqlDbType.Double).Value = tax;

            var result = comm.ExecuteNonQuery();

            if (result != 0)
                return true;
            else
                return false;
        }
              

        internal static void CreateScannedProduct(ScannedProduc scannedProduc)
        {
            CreateScannedProduct(scannedProduc.barcode, scannedProduc.amount, scannedProduc.product_id, scannedProduc.created_by, scannedProduc.tax);
        }

        internal static void CreateScannedProduct(List<ScannedProduc> scannedProducs)
        {
            foreach (var scannedProduc in scannedProducs)
            CreateScannedProduct(scannedProduc.barcode, scannedProduc.amount, scannedProduc.product_id, scannedProduc.created_by, scannedProduc.tax);
        }
         /*
        bool ModifyScannedProduct()
        {
            MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            conn.Open();

            MySqlCommand comm = conn.CreateCommand();
            comm.CommandText = "INSERT INTO products(code,description,barcode,price,partner) VALUES(?code,?description,?barcode,?price,?partner)";

            comm.Parameters.Add("?code", MySqlDbType.Double).Value = code;
            comm.Parameters.Add("?description", MySqlDbType.Text).Value = description;
            comm.Parameters.Add("?barcode", MySqlDbType.Int64).Value = barcode;
            comm.Parameters.Add("?price", MySqlDbType.Double).Value = price;
            comm.Parameters.Add("?partner", MySqlDbType.VarChar).Value = sourceParner;

            var result = comm.ExecuteNonQuery();

            if (result != 0)
                return true;
            else
                return false;
        }      

        bool DeleteScannedProduct()
        {
            MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            conn.Open();

            MySqlCommand comm = conn.CreateCommand();
            comm.CommandText = "DELETE * FROM scanned_products WHERE ";

            comm.Parameters.Add("?code", MySqlDbType.Double).Value = code;
            comm.Parameters.Add("?description", MySqlDbType.Text).Value = description;
            comm.Parameters.Add("?barcode", MySqlDbType.Int64).Value = barcode;
            comm.Parameters.Add("?price", MySqlDbType.Double).Value = price;
            comm.Parameters.Add("?partner", MySqlDbType.VarChar).Value = sourceParner;

            var result = comm.ExecuteNonQuery();

            if (result != 0)
                return true;
            else
                return false;
        }

              */




    }
}
