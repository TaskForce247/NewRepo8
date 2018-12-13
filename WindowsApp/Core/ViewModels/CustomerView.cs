using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsApp.Persistence;
using WindowsApp.Core.Models;
using WindowsApp.Core.ViewModels;

namespace MainClient
{
    class CustomerView : DataView
    {
        private static String[] TableHeaders  { get;} = { "Name", "E-mail", "Phone", "Address" };

        public CustomerView()
        {
            foreach(String head in TableHeaders)
            {
                this.Table.Columns.Add(head);
            }
        }
        
        public void PopulateTable(Customer[] customers)
        {

        }
        
    }
}
