using Domain.Interfaces.Generics;
using Finance.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.ICategories
{
    public interface InterfaceCategories : InterfaceGeneric<Categories>
    {
        Task<IList<Categories>> ListUserCategories(string userEmail);
    }
}
