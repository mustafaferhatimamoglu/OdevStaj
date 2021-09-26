using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Merpey.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
        public IActionResult OnGetGiris(string ID, string Pass)
        {
            //return new JsonResult("Founded user");
            //string a1 = "2.1";
            //string a2 = "2,1";
            //Double b1 = Convert.ToDouble(a1);
            //Double b2 = Convert.ToDouble(a2);

            // int zero = 0;
            //// int result = 100 / zero;
            // var ID = Request.Form["ID"];
            // var Pass = Request.Form["Pass"];

            //throw new DivideByZeroException();
            //return Content("<xml>This is poorly formatted xml.</xml>", "text/xml");
            string Role = DB_op.Instance.selectToTekil("select ID from USERS where ID = '" + ID + "' and Pass = '" + Pass + "'", "boş");
            string RoleLink = "/";
            switch (Role)
            {
                case "1":
                    //öğrenci
                    RoleLink = "/Student";
                    break;
                case "2":
                    //öğrenci
                    RoleLink = "/StajKomiyonUyesi";
                    break;
                case "3":
                    //öğrenci
                    RoleLink = "/StajDegerlendirici";
                    break;
                default:
                    //case 2:
                    // hatalı birşey
                    //Response.Redirect("Login");
                    throw new Exception("Kullanıcı adı veya şifre yanlış.!");
                    break;
            }
            Response.Cookies.Append("ID", ID);
            Response.Cookies.Append("Role", Role);
            return Content(RoleLink);
        }

    }
}
