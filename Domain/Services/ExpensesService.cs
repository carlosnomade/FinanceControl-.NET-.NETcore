using Domain.Interfaces.InterfaceServices;
using DurableTask.Core.Common;
using Finance.Entities;
using Finance.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ExpensesService : IExpensesService
    {
        private readonly InterfaceExpenses _InterfaceExpenses;
        public ExpensesService(InterfaceExpenses InterfaceExpenses)
        {
            _InterfaceExpenses = InterfaceExpenses;
        }
        public async Task AddExpenses(Expenses expenses)
        {
            var date = DateTime.UtcNow;
            expenses.RegisterDate = date;
            expenses.Years = date.Year;
            expenses.Month = date.Month;

            var valid = expenses.ValidateStringProperties(expenses.Name, "Name");
            if (valid)
                await _InterfaceExpenses.Add(expenses);
        }

        public async Task UpdateExpenses(Expenses expenses)
        {
            var date = DateTime.UtcNow;
            expenses.ChangeDate = date;

            if(expenses.Paiement)
            {
                expenses.DatePay = date;
            }

            var valid = expenses.ValidateStringProperties(expenses.Name, "Name");
            if (valid)
                await _InterfaceExpenses.Update(expenses);
        }

        public async Task<object> LoadGraphics(string userEmail)
        {
            var expensesUser = await _InterfaceExpenses.ListUserExpenses(userEmail);
            var expensesPrevious = await _InterfaceExpenses.ListUnpaidExpensesPreviousMonth(userEmail);

            var expenses_UnpaidExpensesPreviousMonth = expensesPrevious.Any() ?
                expensesPrevious.ToList().Sum(x => x.Value) : 0;

            var expensesPaid = expensesUser.Where(e => e.Paiement && e.TypeExpenses == Finance.Enums.EnumTypeExpenses.Accounts)
                .Sum(x => x.Value);

            var expensesPending = expensesUser.Where(e => !e.Paiement && e.TypeExpenses == Finance.Enums.EnumTypeExpenses.Accounts)
                .Sum(x => x.Value);

            var investments = expensesUser.Where(e => e.TypeExpenses == Finance.Enums.EnumTypeExpenses.Investments)
                .Sum(x => x.Value);

            return new
            {
                sucess = "OK",
                expensesPaid = expensesPaid,
                expensesPending = expensesPending,
                expenses_UnpaidExpensesPreviousMonth = expenses_UnpaidExpensesPreviousMonth,
                investments = investments
            };
        }
    }
}
