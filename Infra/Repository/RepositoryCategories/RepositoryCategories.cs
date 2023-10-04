using Domain.Interfaces.ICategories;
using Finance.Entities;
using Infra.Config;
using Infra.Repository.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repository.RepositoryCategories
{
    public class RepositoryCategories : RepositoryGenerics<Categories>, InterfaceCategories
    {
        private readonly DbContextOptions<BasicContext> _OptionsBuilder;

        public RepositoryCategories()
        {
            _OptionsBuilder = new DbContextOptions<BasicContext>();
        }
        public async Task<IList<Categories>> ListUserCategories(string userEmail)
        {
            using (var bank = new BasicContext(_OptionsBuilder))
            {
                return await
                    (from s in bank.FinanceSystem
                    join c in bank.Categories on s.Id equals c.SystemId
                    join us in bank.UserFinanceSystem on s.Id equals us.SystemId
                    where us.UserEmail.Equals(userEmail) && us.SystemCurrent
                    select c).AsNoTracking().ToListAsync();
            }
        }
    }
}
