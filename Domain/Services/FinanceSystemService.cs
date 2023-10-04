using Domain.Interfaces.IFinanceSystem;
using Domain.Interfaces.InterfaceServices;
using Finance.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class FinanceSystemService : IFinanceSystemService
    {
        private readonly InterfaceFinanceSystem _interfaceFinanceSystem;

        public FinanceSystemService(InterfaceFinanceSystem interfaceFinanceSystem)
        {
            _interfaceFinanceSystem = interfaceFinanceSystem;
        }

        public async Task AddFinanceSystem(FinanceSystem financeSystem)
        {
            var valid = financeSystem.ValidateStringProperties(financeSystem.Name, "Name");

            if (valid)
            {
                var date = DateTime.Now;

                financeSystem.DayClosure = 1;
                financeSystem.Years = date.Year;
                financeSystem.Month = date.Month;
                financeSystem.CopyYears = date.Year;
                financeSystem.CopyMonth = date.Month;
                financeSystem.GenerateExpensesCopy = true;

                await _interfaceFinanceSystem.Add(financeSystem);
            }
        }

        public async Task UpdateFinanceSystem(FinanceSystem financeSystem)
        {
            var valid = financeSystem.ValidateStringProperties(financeSystem.Name, "Name");
            if (valid)
            {
                financeSystem.DayClosure = 1;
                await _interfaceFinanceSystem.Update(financeSystem);
            }
        }
    }
}
