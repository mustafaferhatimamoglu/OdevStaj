using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Merpey
{
    public class DB_op
    {
        private static DB_op DB_Works;
        public static DB_op Instance
        {
            get
            {
                if (DB_Works == null)
                    DB_Works = new DB_op();
                return DB_Works;
            }
        }
        private DataTable selectToBtoB(string sqlSorgu)
        {
            return selectTo(sqlSorgu, "BTOB");
        }
        public DataTable selectTo(string sqlSorgu, string connectName)//Databaseden verileri datatale olarak döndürür
        {
            //using (SqlConnection connect = new SqlConnection(WebConfigurationManager.ConnectionStrings[connectName].ConnectionString))
            using (SqlConnection connect = new SqlConnection("Data Source=127.0.0.1;Initial Catalog=MERPEY;User ID=sa;Password=Ferhat_123*;Connect Timeout=60;Persist Security Info=True;MultipleActiveResultSets=true;"))// providerName = \"System.Data.SqlClient"))
            {
                DataTable dt = new DataTable();
                using (SqlDataAdapter da = new SqlDataAdapter(sqlSorgu, connect))
                {
                    try
                    {
                        da.Fill(dt);
                        return dt;
                    }
                    catch (Exception ex)
                    {
                        //Logger.Logcu(ex + "--Sorgu: " + sqlSorgu);
                        return dt;
                    }
                }
            }
        }
        public string selectToTekil(string sqlSorgu, string connectName)//Database sorgusunun sonucu kesin olarak tekil ise Kullanılır.
        {
            //using (SqlConnection connect = new SqlConnection(WebConfigurationManager.ConnectionStrings[connectName].ConnectionString))
            using (SqlConnection connect = new SqlConnection("Data Source=127.0.0.1;Initial Catalog=MERPEY;User ID=sa;Password=Ferhat_123*;Connect Timeout=60;Persist Security Info=True;MultipleActiveResultSets=true;"))// providerName = \"System.Data.SqlClient"))
            {
                using (SqlCommand cmd = new SqlCommand(sqlSorgu, connect))
                {
                    try
                    {
                        if (connect.State != ConnectionState.Open)
                            connect.Open();
                        using (SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.CloseConnection | CommandBehavior.SingleRow))
                        {
                            try
                            {
                                if (rd.HasRows)
                                {
                                    rd.Read();
                                    return rd[0].ToString();
                                }
                                else
                                    return string.Empty;
                            }
                            catch (Exception ex)
                            {
                                //Logger.Logcu(ex + "--Sorgu: " + sqlSorgu);
                                return string.Empty;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        //Logger.Logcu(ex);
                        return string.Empty;
                    }
                    finally
                    {
                        if (connect.State != ConnectionState.Closed)
                            connect.Close();
                    }
                }
            }
        }
    }
}
