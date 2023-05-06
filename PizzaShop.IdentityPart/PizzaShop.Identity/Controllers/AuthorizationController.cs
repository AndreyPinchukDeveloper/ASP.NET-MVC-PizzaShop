namespace PizzaShop.Identity.Controllers
{
    public class AuthorizationController:Controller
    {
        private readonly SignInManager<AppUser> _signManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IIdentityServerInteractionServer _interactionService;

        public AuthorizationController(SignInManager<AppUser> signManager, UserManager<AppUser> userManager, IIdentityServerInteractionServer interactionService)
        {
            _signManager = signManager;
            _userManager = userManager;
            _interactionService = interactionService;
        }

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
        public async Task<IActionResult> Login(LoginViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var user = await _userManager.FindByNameAsync(viewModel.Usrname);
            if (user == null)
            {
                ModelState.AddModelError(string.empty, "User not found");
                return View(viewModel);
            }

            var result = await _signInManger.PasswordSignInAsync(viewModel.Usrname, viewModel.Password, false, false);
            if (result.Succeeded)
            {
                return Redirect(viewModel.ReturnUrl);
            }
            ModelState.AddModelError(string.Empty, "Login error");
            return View(viewModel);
        }
    }
}
