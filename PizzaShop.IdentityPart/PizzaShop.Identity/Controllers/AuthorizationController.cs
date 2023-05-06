namespace PizzaShop.Identity.Controllers
{
    public class AuthorizationController:Controller
    {
        [HttpGet]//this is get method
        public IActionResult Login(string returnUrl)
        {
            var viewModel = new LoginViewModel
            {
                ReturnUrl = returnUrl
            };
            return View();
        }

        [HttpPost]//this is post method
        public IActionResult Login(LoginViewModel viewModel)
        {
            return View(viewModel);
        }
    }
}
