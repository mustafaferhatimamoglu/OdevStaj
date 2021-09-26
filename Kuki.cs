using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Merpey
{
    public class Kuki
    {
        private static Kuki DB_Works;
        public static Kuki Instance
        {
            get
            {
                if (DB_Works == null)
                    DB_Works = new Kuki();
                return DB_Works;
            }
        }

        public void Yaz(string key,string val)
        {
            // Response.Cookies.Append("a1", "a2");
        }
    }
}
