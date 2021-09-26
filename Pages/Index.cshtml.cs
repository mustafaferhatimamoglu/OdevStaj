using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Merpey.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
        public IActionResult OnGetGiris(string ID, string Pass)
        {
            string Role = DB_op.Instance.selectToTekil("select Rol from USERS where ID = N'" + ID + "' and Pass = N'" + Pass + "'", "boş");
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
            }
            Response.Cookies.Append("ID", ID);
            Response.Cookies.Append("Role", Role);
            return Content(RoleLink);
        }
    }
}
