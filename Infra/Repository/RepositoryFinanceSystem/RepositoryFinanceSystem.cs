using Domain.Interfaces.IFinanceSystem;
using Finance.Entities;
using Infra.Config;
using Infra.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repository.RepositoryFinanceSystem
{
    public class RepositoryFinanceSystem : RepositoryGenerics<FinanceSystem>, InterfaceFinanceSystem
    {
        private readonly DbContextOptions<BasicContext> _OptionsBuilder;

        public RepositoryFinanceSystem()
        {
            _OptionsBuilder = new DbContextOptions<BasicContext>();
        }
        public async Task<IList<FinanceSystem>> ListUserSystem(string userEmail)
        {
            using (var bank = new BasicContext(_OptionsBuilder))
            {
                return await
                    (from s in bank.FinanceSystem
                     join us in bank.UserFinanceSystem on s.Id equals us.SystemId
                     where us.UserEmail.Equals(userEmail) 
                     select s).AsNoTracking().ToListAsync();

            }
        }
    }
}
