using Domain.Interfaces.ICategories;
using Domain.Interfaces.InterfaceServices;
using Domain.Services;
using Finance.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoriesController : ControllerBase
    {
        private readonly InterfaceCategories _InterfaceCategories;
        private readonly ICategoriesService _ICategoriesService;

        public CategoriesController(InterfaceCategories interfaceCategories, ICategoriesService iCategoriesService)
        {
            _InterfaceCategories = interfaceCategories;
            _ICategoriesService = iCategoriesService;
        }


        [HttpGet("/api/ListUserCategories")]
        [Produces("application/json")]
        public async Task<object> ListUserCategories(string userEmail)
        {
            return _InterfaceCategories.ListUserCategories(userEmail);
        }


        [HttpPost("/api/AddCategories")]
        [Produces("application/json")]
        public async Task<object> AddCategories(Categories categories)
        {
            await _ICategoriesService.AddCategories(categories);

            return categories;
        }


        [HttpPut("/api/UpdateCategories")]
        [Produces("application/json")]
        public async Task<object> UpdateCategories(Categories categories)
        {
            await _ICategoriesService.UpdateCategories(categories);

            return categories;
        }


        [HttpGet("/api/ObterCategories")]
        [Produces("application/json")]
        public async Task<object> ObterCategories(int id)
        {
            return await _InterfaceCategories.GetEntityById(id);
        }


        [HttpDelete("/api/DeleteCategories")]
        [Produces("application/json")]
        public async Task<object> DeleteCategories(int id)
        {
            try
            {
                var categories = await _InterfaceCategories.GetEntityById(id);
                await _InterfaceCategories.Delete(categories);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

    }
}
