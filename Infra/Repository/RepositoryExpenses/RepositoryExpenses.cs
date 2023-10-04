using Domain.Interfaces.InterfaceServices;
using Finance.Entities;
using Infra.Config;
using Infra.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repository.RepositoryExpenses
{
    public class RepositoryExpenses : RepositoryGenerics<Expenses>, InterfaceExpenses
    {
        private readonly DbContextOptions<BasicContext> _OptionsBuilder;

        public RepositoryExpenses()
        {
            _OptionsBuilder = new DbContextOptions<BasicContext>();
        }

        public async Task<IList<Expenses>> ListUnpaidExpensesPreviousMonth(string userEmail)
        {
            using (var bank = new BasicContext(_OptionsBuilder))
            {
                return await
                    (from s in bank.FinanceSystem
                     join c in bank.Categories on s.Id equals c.SystemId
                     join us in bank.UserFinanceSystem on s.Id equals us.SystemId
                     join d in bank.Expenses on c.Id equals d.CategorieId
                     where us.UserEmail.Equals(userEmail) && s.Month == d.Month && s.Years == d.Years
                     select d).AsNoTracking().ToListAsync();

            }
        }

        public async Task<IList<Expenses>> ListUserExpenses(string userEmail)
        {
            using (var bank = new BasicContext(_OptionsBuilder))
            {
                return await
                    (from s in bank.FinanceSystem
                     join c in bank.Categories on s.Id equals c.SystemId
                     join us in bank.UserFinanceSystem on s.Id equals us.SystemId
                     join d in bank.Expenses on c.Id equals d.CategorieId
                     where us.UserEmail.Equals(userEmail) && d.Month < DateTime.Now.Month && !d.Paiement
                     select d).AsNoTracking().ToListAsync();

            }
        }
    }
}
