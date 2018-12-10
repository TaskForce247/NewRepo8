using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using System.Windows.Shapes;

namespace ControlsLibrary
{
    /// <summary>
    /// Interaction logic for Customer.xaml
    /// </summary>
    public partial class Customer : Window
    {

        SqlConnection con = new SqlConnection(@"Server=(LocalDb)\MSSQLLocalDB;Initial Catalog=test;Integrated Security=True;");
        public Customer()
        {
            this.setConnection();
            InitializeComponent();
        }
        private void updateDataGrid()
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT Customer_ID, Name, Email, Phone, Address FROM cus";
            cmd.CommandType = CommandType.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            myDataGrid.ItemsSource = dt.DefaultView;
            dr.Close();
        }
        private void setConnection()
        {
            myDataGrid = new DataGrid();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from cus";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            myDataGrid.ItemsSource = dt.DefaultView;
            con.Close();
           /* try
            {
                SqlConnection thisConnection = new SqlConnection(@"Server=(LocalDb)\MSSQLLocalDB;Initial Catalog=test;Integrated Security=True;");
                thisConnection.Open();

                string Get_Data = "SELECT * FROM cus";

                SqlCommand cmd = thisConnection.CreateCommand();
                cmd.CommandText = Get_Data;

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("cus");
                sda.Fill(dt);

                myDataGrid.ItemsSource = dt.DefaultView;
            }
            catch
            {
                MessageBox.Show("db error");
            }*/
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.updateDataGrid();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            con.Close();
        }

        private void add_btn_Click(object sender, RoutedEventArgs e)
        {
            String sql = "INSERT INTO cus(Customer_ID, Name, Email, Phone, Address) " +
                "VALUES(:Customer_ID, :Name, :Email, :Phone, :Address)";
            this.AUD(sql, 0);
            add_btn.IsEnabled = false;
            update_btn.IsEnabled = true;
            delete_btn.IsEnabled = true;
        }

        private void update_btn_Click(object sender, RoutedEventArgs e)
        {
            String sql = "UPDATE cus SET Name = :Name," +
                "Email=:Email, Phone=:Phone, Addres=:Address" +
                "WHERE Customer_ID = :Customer_ID";
            this.AUD(sql, 1);
        }

        private void delete_btn_Click(object sender, RoutedEventArgs e)
        {
            String sql = "DELETE FROM cus " +
                "WHERE Customer_ID = :Customer_ID";
            this.AUD(sql, 2);
            this.resetAll();
        }
        private void resetAll()
        {
            customer_id_txtbx.Text = "";
            email_txtbx.Text = "";
            name_txtbx.Text = "";
            phone_txtbx.Text = "";
            address_txtbx.Text = "";

            add_btn.IsEnabled = true;
            update_btn.IsEnabled = false;
            delete_btn.IsEnabled = false;
        }
        private void reset_btn_Click(object sender, RoutedEventArgs e)
        {
            this.resetAll();
        }
        private void AUD(String sql_stmt, int state)
        {
            String msg = "";
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = sql_stmt;
            cmd.CommandType = CommandType.Text;

            switch (state)
            {
                case 0:
                    msg = "Row Inserted Successfully!";
                    cmd.Parameters.Add("Customer_ID", SqlDbType.Int, 6).Value = Int32.Parse(customer_id_txtbx.Text);
                    cmd.Parameters.Add("Name", SqlDbType.NChar, 25).Value = name_txtbx.Text;
                    cmd.Parameters.Add("Email", SqlDbType.NChar, 25).Value = email_txtbx.Text;
                    cmd.Parameters.Add("Phone", SqlDbType.Int, 10).Value = phone_txtbx.Text;
                    cmd.Parameters.Add("Address", SqlDbType.NChar, 25).Value = address_txtbx.Text;

                    break;
                case 1:
                    msg = "Row Updated Successfully!";
                    cmd.Parameters.Add("Name", SqlDbType.NChar, 25).Value = name_txtbx.Text;
                    cmd.Parameters.Add("Email", SqlDbType.NChar, 25).Value = email_txtbx.Text;
                    cmd.Parameters.Add("Phone", SqlDbType.Int, 10).Value = phone_txtbx.Text;

                    cmd.Parameters.Add("Customer_ID", SqlDbType.Int, 6).Value = Int32.Parse(customer_id_txtbx.Text);

                    break;
                case 2:
                    msg = "Row Deleted Successfully!";

                    cmd.Parameters.Add("Customer_ID", SqlDbType.Int, 6).Value = Int32.Parse(customer_id_txtbx.Text);

                    break;
            }
            try
            {
                int n = cmd.ExecuteNonQuery();
                if (n > 0)
                {
                    MessageBox.Show(msg);
                    this.updateDataGrid();
                }
            }
            catch (Exception expe) { }
        }

        private void myDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            DataRowView dr = dg.SelectedItem as DataRowView;
            if (dr != null)
            {
                customer_id_txtbx.Text = dr["Customer_ID"].ToString();
                name_txtbx.Text = dr["Name"].ToString();
                phone_txtbx.Text = dr["Phone"].ToString();
                email_txtbx.Text = dr["Email"].ToString();
                address_txtbx.Text = dr["Address"].ToString();

                add_btn.IsEnabled = false;
                update_btn.IsEnabled = true;
                delete_btn.IsEnabled = true;

            }
        }
    }
}
