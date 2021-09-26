using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Merpey.Pages
{
    public class StajDegerlendiriciModel : PageModel
    {
        public void OnGet()
        {
        }
        public IActionResult OnGetStajIslemleriniGetir()
        {

            string UserID = Request.Cookies["ID"];
            string SQL = "SELECT [ID],[UserID],[ProjectName],[ProjectEx],[ProjectTalepEdilenHocaID],[ProjectDatetime],[KomisyonOnay],[KomisyonOnayAçýklama],[KomisyonOnaylananHoca],[KomisyonDatetime],[StajDegerlendiriciNot],[StajDegerlendiriciAcýklama],[StajDegerlendiriciDatetime] FROM Project";
            //SQL += " where UserID = N'" + UserID;
            SQL += " where StajDegerlendiriciNot is null ";
            SQL += " order by ID desc FOR JSON AUTO , INCLUDE_NULL_VALUES";
            string ProjelerJSON = DB_op.Instance.selectToTekil(SQL, "");
            //string kom = "---";
            //for (int i = 0; i < Komisyon.Rows.Count; i++)
            //{
            //    kom += Komisyon.Rows[i][0] + "---";
            //}
            return Content(ProjelerJSON);
        }
        public IActionResult OnGetIslemeAlSKU(string ID, string StajDegerlendiriciNot, string StajDegerlendiriciAcýklama)
        {

            //string UserID = Request.Cookies["ID"];
            //string SQL = "SELECT [ID],[UserID],[ProjectName],[ProjectEx],[ProjectTalepEdilenHocaID],[ProjectDatetime],[KomisyonOnay],[KomisyonOnayAçýklama],[KomisyonOnaylananHoca],[KomisyonDatetime],[StajDegerlendiriciNot],[StajDegerlendiriciAcýklama],[StajDegerlendiriciDatetime] FROM Project";
            ////SQL += " where UserID = N'" + UserID;
            //SQL += " where KomisyonOnay is null ";
            //SQL += " order by ID desc FOR JSON AUTO , INCLUDE_NULL_VALUES";
            string SQL = "UPDATE Project " +
                "SET StajDegerlendiriciNot = " + StajDegerlendiriciNot +
                " , StajDegerlendiriciAcýklama = '" + StajDegerlendiriciAcýklama + "'" +
                //" , KomisyonOnaylananHoca = '" + KomisyonOnaylananHoca + "'" +
                " , KomisyonDatetime = GETDATE() " +
                "WHERE ID = " + ID;
            string ProjelerJSON = DB_op.Instance.selectToTekil(SQL, "");
            //string kom = "---";
            //for (int i = 0; i < Komisyon.Rows.Count; i++)
            //{
            //    kom += Komisyon.Rows[i][0] + "---";
            //}
            return Content("");
        }
    }
}
