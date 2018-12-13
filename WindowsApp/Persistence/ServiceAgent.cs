using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsApp.Persistence;
using WindowsApp.Core.Models;
using WindowsApp.Core.ViewModels;

namespace WindowsApp.Persistence
{
    public interface IServiceAgent
    {
        void GetCustomers(Action<ObservableCollection<Customer>, Exception> completed);
        void Flush(ObservableCollection<Customer> list, Action<Exception> completed);
    }

    public class ServiceAgent : IServiceAgent
    {
        public void GetCustomers(Action<ObservableCollection<Customer>, Exception> completed)
        {
            try
            {
                ObservableCollection<Customer> customers = Core_DAL.FetchCustomers();
                completed(customers, null);
            }
            catch (Exception e)
            {
                completed(null, e);
            }
        }

        public void Flush(ObservableCollection<Customer> list, Action<Exception> completed)
        {
            try
            {
                Core_DAL.Flush(list);
                completed(null);
            }
            catch (Exception e)
            {
                completed(e);
            }
        }
    }
}
