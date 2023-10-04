using Domain.Interfaces.Generics;
using Finance.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IFinanceSystem
{
    public interface InterfaceFinanceSystem : InterfaceGeneric<FinanceSystem>
    {
        Task<IList<FinanceSystem>> ListUserSystem(string userEmail);
    }
}
