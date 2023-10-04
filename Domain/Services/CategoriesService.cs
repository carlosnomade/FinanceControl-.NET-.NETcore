using Domain.Interfaces.ICategories;
using Domain.Interfaces.InterfaceServices;
using Finance.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly InterfaceCategories _interfaceCategories;
        public CategoriesService(InterfaceCategories interfaceCategories)
        {
            _interfaceCategories = interfaceCategories;
        }
        public async Task AddCategories(Categories categories)
        {
            var valid = categories.ValidateStringProperties(categories.Name, "Name");
            if (valid)
                await _interfaceCategories.Add(categories);
        }

        public async Task UpdateCategories(Categories categories)
        {
            var valid = categories.ValidateStringProperties(categories.Name, "Name");
            if (valid)
                await _interfaceCategories.Update(categories);
        }
    }
}
