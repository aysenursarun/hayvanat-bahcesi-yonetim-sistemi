using proje1.Models;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace proje1.Controllers
{
    public class HomeController : Controller
    {
        ProjectEntities1 db = new ProjectEntities1();

        // GET: Home/Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        // POST: Home/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Users model)
        {
            if (ModelState.IsValid)
            {
                // Kullanıcı adı ve şifre doğrulama işlemi
                var user = db.Users.FirstOrDefault(u => u.Username == model.Username && u.Password == model.Password);
                if (user != null)
                {
                    // Kullanıcı doğrulandı, kullanıcıyı oturum açtırın.
                    FormsAuthentication.SetAuthCookie(user.Username, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Geçersiz kullanıcı adı veya şifre.");
                }
            }
            // Hata varsa login view'ını tekrar göster
            return View(model);
        }

        // GET: Home/Logout
        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Home");
        }

        // GET: Home/Index
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        // GET: Home/About
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        // GET: Home/Contact
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}
