using SimpleMvvmToolkit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsApp.Core.Models
{
    public static class Customers
    {
        public static ObservableCollection<Customer> GetCustomers()
        {
            List<Customer> result = new List<Customer>();

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ToString()))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("select * from Customers", conn))
                {
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            Customer prod = new Customer();
                            prod.Id = Convert.ToInt32(rdr["id"]);
                            prod.Name = rdr["Name"].ToString();
                            prod.Email = rdr["Email"].ToString();
                            prod.Phone = rdr["Phone"].ToString();
                            prod.Address = rdr["Address"].ToString();
                            prod.Mode = emMode.none;
                            result.Add(prod);
                        }
                    }
                }
                conn.Close();
            }

            var oc = new ObservableCollection<Customer>();
            result.ForEach(x => oc.Add(x));
            return oc;
        }

        internal static void Flush(ObservableCollection<Customer> Customers)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ToString()))
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    //ObservableCollection<Customer> list = Customers.Distinct(x => x.Mode != emMode.none);
                    foreach (Customer Customer in Customers)
                    {
                        if (Customer.Mode == emMode.none)
                            continue;
                        else
                            if (Customer.Mode == emMode.add)
                                Insert(Customer, conn, tran);
                            else
                                if (Customer.Mode == emMode.update)
                                    Update(Customer, conn, tran);
                                else if (Customer.Mode == emMode.delete)
                                    Delete(Customer.Id, conn, tran);
                    }
                    tran.Commit();
                }
                catch (Exception e)
                {
                    tran.Rollback();
                    throw e;
                }
                conn.Close();
            }
        }

        private static void Delete(int id, SqlConnection conn, SqlTransaction tran)
        {
            using (SqlCommand cmd = new SqlCommand("delete from Customers where Customerid = @id", conn, tran))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        private static void Update(Customer Customer, SqlConnection conn, SqlTransaction tran)
        {
            using (SqlCommand cmd = new SqlCommand("update Customers set Name = @Name, Email = @Email, Phone = @Phone, Address = @Address where id = @id", conn, tran))
            {
                cmd.Parameters.AddWithValue("@id", Customer.Id);
                cmd.Parameters.AddWithValue("@Name", Customer.Name);
                cmd.Parameters.AddWithValue("@Email", Customer.Email);
                cmd.Parameters.AddWithValue("@Phone", Customer.Phone);
                cmd.Parameters.AddWithValue("@Address", Customer.Address);
                cmd.ExecuteNonQuery();
            }
        }

        private static void Insert(Customer Customer, SqlConnection conn, SqlTransaction tran)
        {
            using (SqlCommand cmd = new SqlCommand("insert into Customers(Name, Email, Phone, Address) values (@Name, @Email, @Phone, @Address)", conn, tran))
            {
                cmd.Parameters.AddWithValue("@Name", Customer.Name);
                cmd.Parameters.AddWithValue("@Email", Customer.Email);
                cmd.Parameters.AddWithValue("@Phone", Customer.Phone);
                cmd.Parameters.AddWithValue("@Address", Customer.Address);
                cmd.ExecuteNonQuery();
            }
        }
    }

    public class Customer : ModelBase<Customer>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public emMode Mode { get; set; }
    }
    public enum emMode { add, update, delete, none };
}
