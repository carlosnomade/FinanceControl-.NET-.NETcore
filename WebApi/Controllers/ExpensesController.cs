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
    public class ExpensesController : ControllerBase
    {
        private readonly InterfaceExpenses _interfaceExpenses;
        private readonly IExpensesService _IExpensesService;

        public ExpensesController(InterfaceExpenses interfaceExpenses, IExpensesService iExpensesService)
        {
            _interfaceExpenses = interfaceExpenses;
            _IExpensesService = iExpensesService;
        }


        [HttpGet("/api/ListExpenses")]
        [Produces("application/json")]
        public async Task<object> ListExpenses(string userEmail)
        {
            return await _interfaceExpenses.ListUserExpenses(userEmail);
        }


        [HttpPost("/api/AddExpenses")]
        [Produces("application/json")]
        public async Task<object> AddExpenses(Expenses expenses)
        {
            await _IExpensesService.AddExpenses(expenses);

            return expenses;
        }


        [HttpPut("/api/UpdateExpenses")]
        [Produces("application/json")]
        public async Task<object> UpdateExpenses(Expenses expenses)
        {
            await _IExpensesService.UpdateExpenses(expenses);

            return expenses;
        }


        [HttpGet("/api/ObterExpenses")]
        [Produces("application/json")]
        public async Task<object> ObterExpenses(int id)
        {
            return await _interfaceExpenses.GetEntityById(id);
        }


        [HttpDelete("/api/DeleteExpenses")]
        [Produces("application/json")]
        public async Task<object> DeleteExpenses(int id)
        {
            try
            {
                var expenses = await _interfaceExpenses.GetEntityById(id);
                await _interfaceExpenses.Delete(expenses);
            }
            catch (Exception)
            {
                return false;
            }
            return true;

        }


        [HttpGet("/api/LoadGraphics")]
        [Produces("application/json")]
        public async Task<object> LoadGraphics(string userEmail)
        {
            return await _IExpensesService.LoadGraphics(userEmail);
        }

    }
}
