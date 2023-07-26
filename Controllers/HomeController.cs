using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SetisUsersAdm.Models;
using SetisUsersAdm.Service;


namespace SetisUsersAdm.Controllers
{
    public class HomeController : Controller
    {
        private ICollection<Usuario> _usuarios;
        private IUserService _userService;


        public HomeController(IUserService userService)
        {
            _usuarios = new List<Usuario>();
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Usuarios()
        {
            return View(_usuarios);
        }

        [HttpPost]
        public IActionResult ImportarUsuarios(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                try
                {
                    _userService.PopularListaDeUsuarios(file, _usuarios);
                }
                catch (Exception ex)
                {
                    ViewBag.ErrorMessage = "Ocorreu um erro ao processar o arquivo XML: " + ex.Message;
                }
            }
            return View("Usuarios", _usuarios);
        }
    }
}