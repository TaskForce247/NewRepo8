using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsApp.Persistence;
using WindowsApp.Core.Models;
using WindowsApp.Core.ViewModels;

namespace WindowsApp.Persistence
{
    public static class Core_DAL
    {
        public static ObservableCollection<Customer> FetchCustomers()
        {
            return Customers.GetCustomers();
            
        }

        public static void Flush(ObservableCollection<Customer> customers)
        {
            Customers.Flush(customers);
        }
    }
}
