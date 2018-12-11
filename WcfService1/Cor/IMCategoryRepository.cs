
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ServiceModel;
using WcfService1;
using WaterLoggic.Core.Models;

namespace WaterLoggic.Core
{
    [ServiceContract]
    public interface IMCategoryRepository
    {
        [OperationContract]
        Task<IEnumerable<MCategory>> GetCategories();
    }
}
