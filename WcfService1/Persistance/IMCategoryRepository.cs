using WaterLoggic.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WaterLoggic.Core
{
    public interface IMCategoryRepository
    {
        Task<IEnumerable<MCategory>> GetCategories();
    }
}
