using Domain.Interfaces.InterfaceServices;
using Domain.Interfaces.IUserFinanceSystem;
using Finance.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserFinanceSystemController : ControllerBase
    {
        private readonly InterfaceUserFinanceSystem _InterfaceUserFinanceSystem;
        private readonly IUserFinanceSystemService _IUserFinanceSystemService;

        public UserFinanceSystemController(InterfaceUserFinanceSystem interfaceUserFinanceSystem, IUserFinanceSystemService iUserFinanceSystemService)
        {
            _InterfaceUserFinanceSystem = interfaceUserFinanceSystem;
            _IUserFinanceSystemService = iUserFinanceSystemService;
        }

        [HttpGet("/api/ListUserSystem")]
        [Produces("application/json")]
        public async Task<object> ListUserSystem(int SystemId)
        {
            return await _InterfaceUserFinanceSystem.ListUserFinanceSystem(SystemId);
        }

        [HttpPost("/api/RegisterUserFinanceSystem")]
        [Produces("application/json")]
        public async Task<object> RegisterUserFinanceSystem(int SystemId, string userEmail)
        {
            try
            {
            await _IUserFinanceSystemService.RegisterUserFinanceSystem(
                new UserFinanceSystem
                {
                    SystemId = SystemId,
                    UserEmail = userEmail,
                    Admin = false,
                    SystemCurrent = true
                });
             }
            catch (Exception)
            {
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }


        [HttpDelete("/api/DeleteUSerFinanceSystem")]
        [Produces("application/json")]
        public async Task<object> DeleteUSerFinanceSystem(int id)
        {
            try
            {
                var userFinanceSystem = await _InterfaceUserFinanceSystem.GetEntityById(id);
                await _InterfaceUserFinanceSystem.Delete(userFinanceSystem);
            }
            catch (Exception)
            {
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }
    }
}
