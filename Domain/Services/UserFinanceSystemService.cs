using Domain.Interfaces.InterfaceServices;
using Domain.Interfaces.IUserFinanceSystem;
using Finance.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class UserFinanceSystemService : IUserFinanceSystemService
    {
        private readonly InterfaceUserFinanceSystem _interfaceUserFinanceSystem;
        public UserFinanceSystemService(InterfaceUserFinanceSystem interfaceUserFinanceSystem)
        {
            _interfaceUserFinanceSystem = interfaceUserFinanceSystem;
        }
        public async Task RegisterUserFinanceSystem(UserFinanceSystem userFinanceSystem)
        {
            await _interfaceUserFinanceSystem.Add(userFinanceSystem);
        }
    }
}
