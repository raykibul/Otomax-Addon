using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Otomax_Addon.Model
{
    public class Connection
    {
        string connstring = "Data Source=.\\SQLEXPRESS;Initial Catalog=otomax;Integrated Security=True;Min Pool Size=1;Max Pool Size=2;";
        public SqlConnection conn;

        public SqlConnection Open()
        {
            try
            {
                conn = new SqlConnection(connstring);
                conn.Open();
                Console.WriteLine("Connection Opend");
                return conn;

            }
            catch (Exception)
            {

                return null;
            }

        }
        public string LoadLastMsg()
        {
            if (conn.State.ToString() != "Open")
            {
                Open();
            }

            string output = null;
            string sql = "select TOP 1 * from inbox  order by kode desc";
            SqlCommand command;
            SqlDataReader readear;
            command = new SqlCommand(sql, conn);
            readear = command.ExecuteReader();
            while (readear.Read())
            {
                output = readear.GetValue(4) + " " + readear.GetValue(1) + " " + readear.GetValue(2) + " ";
            }

            return output;

        }



        public void Close()
        {
            conn.Close();
        }
    }


}
