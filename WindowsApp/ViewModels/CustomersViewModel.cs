using System;
using System.Windows;
using System.Threading;
using System.Collections.ObjectModel;
using SimpleMvvmToolkit;
using WpfData.Services;
using WpfData.Models;

namespace WpfData.ViewModels
{
    public class CustomersViewModel : ViewModelBase<CustomersViewModel>
    {
        private IServiceAgent _serviceAgent;

        public CustomersViewModel() { }

        public CustomersViewModel(IServiceAgent serviceAgent)
        {
            this._serviceAgent = serviceAgent;
        }

        #region Notifications

        public event EventHandler<NotificationEventArgs<Exception>> ErrorNotice;

        #endregion

        #region Properties

        private string customerName;
        public string CustomerName
        {
            get { return customerName; }
            set
            {
                customerName = value;
                NotifyPropertyChanged(m => m.customerName);
            }
        }

        private int units;
        public int Units
        {
            get { return units; }
            set
            {
                units = value;
                NotifyPropertyChanged(m => m.Units);
            }
        }

        private ObservableCollection<Customer> customers;
        public ObservableCollection<Customer> Customers
        {
            get { return customers; }
            set
            {
                customers = value;
                NotifyPropertyChanged(m => m.Customers);
            }
        }

        private Customer selectedCustomer;
        public Customer SelectedCustomer
        {
            get { return selectedCustomer; }
            set
            {
                selectedCustomer = value;
                this.Message = selectedCustomer.Name;
                NotifyPropertyChanged(m => m.selectedCustomer);
            }
        }

        private string message;
        public string Message
        {
            get { return message; }
            set
            {
                message = value;
                NotifyPropertyChanged(m => m.message);
            }
        }

        #endregion

        #region Methods

        public void LoadProducts()
        {
            _serviceAgent.GetCustomers((products, error) => CustomersLoaded(products, error));
        }
        private void AddProduct()
        {
            this.Customers.Insert(0, new Customer { Name = "TestProduct", Email = "asd", Phone = "asd", Address = "asd" });
            _serviceAgent.Flush(this.Customers, (error) => CustomersFlushed(error));
        }

        private void EditProduct()
        {
            this.SelectedCustomer.Name = "Edited Name";
            this.SelectedCustomer.Email = "Edited Email";
            this.SelectedCustomer.Phone = "Edited Phone";
            this.SelectedCustomer.Address = "Edited Address";
            this.SelectedCustomer.Mode = emMode.update;
            _serviceAgent.Flush(this.Customers, (error) => CustomersFlushed(error));
        }

        private void DeleteProduct()
        {
            this.SelectedCustomer.Mode = emMode.delete;
            _serviceAgent.Flush(this.Customers, (error) => CustomersFlushed(error));
        }

        private void Search()
        {
            _serviceAgent.GetCustomers((productlist, error) => CustomersLoaded(productlist, error));
        }

        #endregion

        #region Callbacks

        private void CustomersLoaded(ObservableCollection<Customer> customers, Exception error)
        {
            if (error == null)
            {
                this.Customers = customers;
                NotifyError("Loaded", null);
            }
            else
            {
                NotifyError(error.Message, error);
            }
            // isbusy = false;
        }

        private void CustomersFlushed(Exception error)
        {
            if (error == null)
                NotifyError("Flushed", null);
            else
                NotifyError(error.Message, error);
        }

        #endregion

        #region Commands

        private DelegateCommand addCommand;
        public DelegateCommand AddCommand
        {
            get
            {
                if (addCommand == null)
                    addCommand = new DelegateCommand(AddProduct);
                return addCommand;
            }
            private set
            {
                addCommand = value;
            }
        }

        private DelegateCommand editCommand;
        public DelegateCommand EditCommand
        {
            get
            {
                if (editCommand == null)
                    editCommand = new DelegateCommand(EditProduct);
                return editCommand;
            }
            private set
            {
                editCommand = value;
            }
        }

        private DelegateCommand deleteCommand;
        public DelegateCommand DeleteCommand
        {
            get
            {
                if (deleteCommand == null)
                    deleteCommand = new DelegateCommand(DeleteProduct);
                return deleteCommand;
            }
            private set
            {
                deleteCommand = value;
            }
        }

        private DelegateCommand searchCommand;
        public DelegateCommand SearchCommand
        {
            get
            {
                if (searchCommand == null) searchCommand = new DelegateCommand(Search);
                return searchCommand;
            }
            private set
            {
                searchCommand = value;
            }
        }

        #endregion 

        #region Helpers

        // Helper method to notify View of an error
        private void NotifyError(string message, Exception error)
        {
            this.Message = message;
            // Notify view of an error
            Notify(ErrorNotice, new NotificationEventArgs<Exception>(message, error));
        }

        #endregion
    }
}