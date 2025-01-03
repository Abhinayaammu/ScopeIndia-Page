using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project1.Entity;
using Project1.Models;
using MailKit.Security;
using MimeKit.Text;
using MimeKit;
using MailKit.Net.Smtp;

namespace Project1.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, AppDbContext appDbcontext)
        {
            _logger = logger;
            _context = appDbcontext;
        }
        //public IActionResult Homee()
        //{
        //    return View();
        //}

        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Contact(string name, string toEmail, string subject, string messageBody)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("pikkapikkachu01@gmail.com"));
            email.To.Add(MailboxAddress.Parse(toEmail));
            email.Subject = subject;

            email.Body = new TextPart(TextFormat.Plain) { Text = messageBody };
            using var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("pikkapikkachu01@gmail.com", "hbjx yxuj vshh qcxz");
            smtp.Send(email);
            smtp.Disconnect(true);
            ViewBag.Message = "A mail has been successfully registered";

            return View();
           
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Registration(RegistrationViewModel model)
        {
            if (ModelState.IsValid)
            {
                UserAccount account = new UserAccount();
                account.Email = model.Email;
                account.Password = model.Password;
                account.Phonenumber = model.Phonenumber;
                account.DateofBirth = model.DateofBirth;
                account.Hobbies = model.Hobbies;
                account.Gender  = model.Gender;
                account.City = model.City;  
                account.Country = model.Country;
                account .FirstName = model.FirstName;
                account.LastName = model.LastName;
                account.State = model.State;
                account.UserName = model.UserName;
                

                try
                {

                    _context.UserAccounts.Add(account);
                    _context.SaveChanges();

                    ModelState.Clear();
                    ViewBag.Message = $"{account.FirstName} {account.LastName} registered successfully.Please Login";

                }
                catch (DbUpdateException ex)
                {
                    ModelState.AddModelError("", "Please enter unique Email or password");
                    return View(model);
                }
                //return View();
            }
            return View(model);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _context.UserAccounts.Where(x => (x.UserName == model.UserNameOrEmail || x.Email == model.UserNameOrEmail) && x.Password == model.Password).FirstOrDefault();
                if (user != null)
                {
                    //success,create cookie
                    var claims = new List<Claim>
                     {
                          new Claim(ClaimTypes.Name,user.Email),
                          new Claim("Name",user.FirstName),
                          new Claim(ClaimTypes.Role,"User"),
                     };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                    return RedirectToAction("SecurePage");

                }
                else
                {
                    ModelState.AddModelError("", "UserName/Email or Password is not correct");
                }
            }
            return View(model);
        }

        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index");
            
        }
        [Authorize]
        public IActionResult SecurePage()
        {
            
                ViewBag.Name = HttpContext.User.Identity.Name;
          
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
