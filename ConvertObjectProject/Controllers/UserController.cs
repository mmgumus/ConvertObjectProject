using System.Threading.Tasks;
using ConvertObjectProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace ConvertObjectProject.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApiService _apiService;

        public UsersController(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _apiService.GetUsersAsync();
            return View(users);
        }
    }
}