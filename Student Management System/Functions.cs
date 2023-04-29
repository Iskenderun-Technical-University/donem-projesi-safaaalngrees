using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace student_managment_system
{
    public static class Functions
    {
        private static string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Safaa Alngrees\Desktop\donem-projesi-safaaalngrees\Student Management System\Database1.mdf;Integrated Security=True";
        private static SqlCommand cmd= new SqlCommand();
        private static DataTable dt;
        private static SqlDataAdapter sda;
        private static SqlConnection con = new SqlConnection(constr);
        
        public static DataTable GetData(string Query)
        {
            dt = new DataTable();
            sda = new SqlDataAdapter(Query, constr);
            sda.Fill(dt);
            return dt;
        }
        public static int SetData(string Query)
        {
            int Cnt = 0;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            cmd.Connection = con;
            cmd.CommandText = Query;
            Cnt = cmd.ExecuteNonQuery();
            con.Close();
            return Cnt; 
        }
    }
}
