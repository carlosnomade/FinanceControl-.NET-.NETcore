using Domain.Interfaces.Generics;
using Finance.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfaceServices
{
    public interface InterfaceExpenses : InterfaceGeneric<Expenses>
    {
        Task<IList<Expenses>> ListUserExpenses(string emailUser);

        Task<IList<Expenses>> ListUnpaidExpensesPreviousMonth(string emailUser);

    }
}
