using Domain.Interfaces.IFinanceSystem;
using Domain.Interfaces.InterfaceServices;
using Finance.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FinanceSystemController : ControllerBase
    {
        private readonly InterfaceFinanceSystem _InterfaceFinanceSystem;
        private readonly IFinanceSystemService _IFinanceSystemService;

        public FinanceSystemController(InterfaceFinanceSystem InterfaceFinanceSystem, IFinanceSystemService IFinanceSystemService)
        {
            _InterfaceFinanceSystem = InterfaceFinanceSystem;
            _IFinanceSystemService = IFinanceSystemService;
        }


        [HttpGet("/api/ListUserSystem")]
        [Produces("application/json")]
        public async Task<object> ListUserSystem(string userEmail)
        {
            return await _InterfaceFinanceSystem.ListUserSystem(userEmail);
        }


        [HttpPost("/api/AddFinanceSystem")]
        [Produces("application/json")]
        public async Task<object> AddFinanceSystem(FinanceSystem financeSystem)
        {
            await _IFinanceSystemService.AddFinanceSystem(financeSystem);

            return Task.FromResult(financeSystem);
        }


        [HttpPut("/api/UpdateFinanceSystem")]
        [Produces("application/json")]
        public async Task<object> UpdateFinanceSystem(FinanceSystem financeSystem)
        {
            await _IFinanceSystemService.UpdateFinanceSystem(financeSystem);

            return Task.FromResult(financeSystem);
        }


        [HttpGet("/api/ObterFinanceSystem")]
        [Produces("application/json")]
        public async Task<object> ObterFinanceSystem(int id)
        {
            return await _InterfaceFinanceSystem.GetEntityById(id);
        }


        [HttpDelete("/api/DeleteFinanceSystem")]
        [Produces("application/json")]
        public async Task<object> DeleteFinanceSystem(int id)
        {
            try
            {
                var financeSystem = await _InterfaceFinanceSystem.GetEntityById(id);

                await _InterfaceFinanceSystem.Delete(financeSystem);
            }
             catch(Exception ex)
            {
                return false;
            }

            return true;
        }
    }
}
