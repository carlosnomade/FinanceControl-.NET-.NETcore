using Finance.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfaceServices
{
    public interface IExpensesService
    {
        Task AddExpenses(Expenses expenses);
        Task UpdateExpenses(Expenses expenses);
        Task<object> LoadGraphics(string userEmail);
    }
}
