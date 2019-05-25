using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Site.Models;
using Site.ViewModels;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Site.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<UserAplication> _userManager;
        public UserManager<UserAplication> UserManager
        {
            get
            {
                if(_userManager == null)
                {
                    var contextOwin = HttpContext.GetOwinContext();
                    _userManager = contextOwin.GetUserManager<UserManager<UserAplication>>();
                }
                return _userManager;
            }
            set
            {
                _userManager = value;
            }
        }

        private SignInManager<UserAplication, string> _signInManager;
        public SignInManager<UserAplication, string> SignInManager
        {
            get
            {
                if (_signInManager == null)
                {
                    var contextOwin = HttpContext.GetOwinContext();
                    _signInManager = contextOwin.GetUserManager<SignInManager<UserAplication, string>>();
                }
                return _signInManager;
            }
            set
            {
                _signInManager = value;
            }
        }

        public IAuthenticationManager AuthenticationManager
        {
            get
            {
                var contextoOwin = Request.GetOwinContext();
                return contextoOwin.Authentication;
            }
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(ContaRegistrarViewModel modelo)
        {
            if(ModelState.IsValid)
            {
                var newUser = new UserAplication
                {
                    Email = modelo.Email,
                    UserName = modelo.UserName,
                    FullName = modelo.FullName
                };

                var usuario = await UserManager.FindByEmailAsync(modelo.Email);
                var usuarioJaExiste = usuario != null;

                if (usuarioJaExiste)
                    return RedirectToAction("Home", "Home"); 

                var resultado = await UserManager.CreateAsync(newUser, modelo.Password);

                if (resultado.Succeeded)
                {
                    return RedirectToAction("Home", "Home");
                }
                else
                {
                    AdicionaErros(resultado);
                }
            }

            // Alguma coisa de errado aconteceu!
            return View(modelo);
        }
              

        public async Task<ActionResult> ConfirmacaoEmail(string usuarioId, string token)
        {
            if (usuarioId == null || token == null)
                return View("Error");

            var resultado = await UserManager.ConfirmEmailAsync(usuarioId, token);

            if (resultado.Succeeded)
                return RedirectToAction("Index", "Home");
            else
                return View("Error");
        }
        
        public async Task<ActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(AccountLoginViewModel modelo)
        {
            if (ModelState.IsValid)
            {
                var usuario = await UserManager.FindByEmailAsync(modelo.Email);

                if (usuario == null)
                    return SenhaOuUsuarioInvalidos();

                var signInResultado =
                    await SignInManager.PasswordSignInAsync(
                        usuario.UserName,
                        modelo.Password,
                        isPersistent: modelo.KeepLog,
                        shouldLockout: true);

                switch (signInResultado)
                {
                    case SignInStatus.Success:
                        return RedirectToAction("Index", "Home");
                    case SignInStatus.LockedOut:
                        var senhaCorreta = 
                            await UserManager.CheckPasswordAsync(
                                usuario,
                                modelo.Password);

                        if (senhaCorreta)
                            ModelState.AddModelError("", "Account is blocked!");
                        else
                            return SenhaOuUsuarioInvalidos();
                        break;
                    default:
                        return SenhaOuUsuarioInvalidos();
                }
            }

            // Algo de errado aconteceu
            return View(modelo);
        }

        [HttpPost]
        public ActionResult Logoff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }

        private ActionResult SenhaOuUsuarioInvalidos()
        {
            ModelState.AddModelError("", "Wrong Credencials!");
            return View("Login");
        }

        private void AdicionaErros(IdentityResult resultado)
        {
            foreach (var erro in resultado.Errors)
                ModelState.AddModelError("", erro);
        }
    }
}