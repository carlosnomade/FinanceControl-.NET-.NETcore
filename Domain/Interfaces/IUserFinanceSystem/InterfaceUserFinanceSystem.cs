using Domain.Interfaces.Generics;
using Finance.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IUserFinanceSystem
{
   public interface InterfaceUserFinanceSystem : InterfaceGeneric<UserFinanceSystem>
    {
        Task<IList<UserFinanceSystem>> ListUserFinanceSystem(int SystemId);

        Task RemoveUser (List<UserFinanceSystem> users);

        Task<UserFinanceSystem> ObtainUserEmail(string userEmail);
    }
}
