using Domain.Interfaces.IUserFinanceSystem;
using Finance.Entities;
using Infra.Config;
using Infra.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repository.RepositoryUserFinanceSystem
{
    public class RepositoryUserFinanceSystem : RepositoryGenerics<UserFinanceSystem>, InterfaceUserFinanceSystem
    {
        private readonly DbContextOptions<BasicContext> _OptionsBuilder;

        public RepositoryUserFinanceSystem()
        {
            _OptionsBuilder = new DbContextOptions<BasicContext>();
        }
        public async Task<IList<UserFinanceSystem>> ListUserFinanceSystem(int SystemId)
        {
            using (var bank = new BasicContext(_OptionsBuilder))
            {
                return await
                    bank.UserFinanceSystem
                    .Where(s => s.SystemId == SystemId).AsNoTracking()
                    .ToListAsync();

            }
        }

        public async Task<UserFinanceSystem> ObtainUserEmail(string userEmail)
        {
            using (var bank = new BasicContext(_OptionsBuilder))
            {
                return await
                    bank.UserFinanceSystem.AsNoTracking().FirstOrDefaultAsync(x => x.UserEmail.Equals(userEmail));

            }
        }

        public async Task RemoveUser(List<UserFinanceSystem> users)
        {
            using (var bank = new BasicContext(_OptionsBuilder))
            {
                
                bank.UserFinanceSystem
                .RemoveRange(users);

                await bank.SaveChangesAsync();

            }
        }
    }
}
