using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Merpey.Pages
{
    public class StudentModel : PageModel
    {
        public void OnGet()
        {

        }
        public IActionResult OnGetSayfaYukle()
        {
            var Komisyon = DB_op.Instance.selectTo("select ID from Users where Rol = 2 ", "");
            string kom = "---";
            for (int i = 0; i < Komisyon.Rows.Count; i++)
            {
                kom += Komisyon.Rows[i][0] + "---";
            }
            return Content(kom);
        }
        public IActionResult OnGetStajIslemleriniGetir()
        {

            string UserID = Request.Cookies["ID"];
            string SQL = "SELECT [ID],[UserID],[ProjectName],[ProjectEx],[ProjectTalepEdilenHocaID],[ProjectDatetime],[KomisyonOnay],[KomisyonOnayAçýklama],[KomisyonOnaylananHoca],[KomisyonDatetime],[StajDegerlendiriciNot],[StajDegerlendiriciAcýklama],[StajDegerlendiriciDatetime] FROM Project";
            SQL += " where UserID = N'" + UserID + "' order by ID desc FOR JSON AUTO , INCLUDE_NULL_VALUES";
            string ProjelerJSON = DB_op.Instance.selectToTekil(SQL, "");
            //string kom = "---";
            //for (int i = 0; i < Komisyon.Rows.Count; i++)
            //{
            //    kom += Komisyon.Rows[i][0] + "---";
            //}
            return Content(ProjelerJSON);
        }

        public IActionResult OnGetProjeOlustur(string PN, string PE, string PT)
        {
            string UserID = Request.Cookies["ID"];
            string SQL = "INSERT INTO [dbo].[Project] ([UserID],[ProjectName],[ProjectEx],[ProjectTalepEdilenHocaID],[ProjectDatetime]) VALUES";
            SQL += " (N'" + UserID + "',N'" + PN + "',N'" + PE + "',N'" + PT + "',GETDATE())";
            DB_op.Instance.selectTo(SQL,"");
            //var Komisyon = DB_op.Instance.selectTo("select ID from Users where Rol = 2 ", "");
            //string kom = "---";
            //for (int i = 0; i < Komisyon.Rows.Count; i++)
            //{
            //    kom += Komisyon.Rows[i][0] + "---";
            //}
            //return Content(kom);
            return Content("/Student");
        }
    }
}
