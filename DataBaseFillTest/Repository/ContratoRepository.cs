using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Npgsql;


namespace DataBaseFillTest.Repository
{
    public class ContratoRepository
    {        
        static string serverName = "192.168.133.13";  //localhost
        static string port = "5432";//porta default
        static string userName = "sisadmin";//nome do administrador
        static string password = "s1sadm1n";//senha do administrador
        static string databaseName = "sistemas";//nome do banco de dados
        NpgsqlConnection pgsqlConnection = null;
        string connString = null;
        
        public ContratoRepository() {            

            connString = String.Format("Server={0};Port={1};User Id={2};Password={3};Database={4};SearchPath=siscec2,pmro_padrao;",
               serverName, port, userName, password, databaseName);
        }

       
        public void FillContratos(Contrato contrato)
        {
            try
            {
                PropertyInfo[] properties = contrato.GetType().GetProperties(
                        //BindingFlags.NonPublic | // Include protected and private properties
                        BindingFlags.Public | // Also include public properties
                        BindingFlags.Instance // Specify to retrieve non static properties
                );
                string sql = "Insert Into \"Contratos\" " +
                   "(" + String.Join(",", properties.Select(x => "\"" + x.Name + "\"").ToList()) + ") " +
                   "values(" + String.Join(",", properties.Select((x) => "'" + x.GetValue(contrato).ToString() + "'").ToList()) + ")";

                /*var list = properties.Select((x) => x.Name).ToList();
                System.Diagnostics.Debug.WriteLine(properties.Length.ToString());
                foreach (var z in list) {
                    System.Diagnostics.Debug.WriteLine(z);
                }*/

                System.Diagnostics.Debug.WriteLine(sql);

                using (NpgsqlConnection pgsqlConnection = new NpgsqlConnection(connString))
                {
                    //Abra a conexão com o PgSQL                  
                    pgsqlConnection.Open();
                    //String.Format(
                    //string cmdInserir = "Insert Into \"Contratos\" " +
                    //"(" + String.Join(",", contrato.fields.Select(x => x = "\""+x+"\"")) + ") " +
                    //"values(" + String.Join(",", contrato.fields.Select((x,index) => x = "'{"+index.ToString()+"}'")) + ")"
                                              

                    using (NpgsqlCommand pgsqlcommand = new NpgsqlCommand(sql, pgsqlConnection))
                    {
                        pgsqlcommand.ExecuteNonQuery();
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                pgsqlConnection?.Close();
            }
        }
    }
}
