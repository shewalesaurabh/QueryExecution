using System.Data;
using Microsoft.Data.SqlClient;


namespace LabExam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DisplayAll();

        }

        //static void Connect()
        //{
        //    SqlConnection cn = new SqlConnection();
        //    cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=KTjune23;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        //    cn.Open();
        //    Console.WriteLine("Open");
        //    cn.Close();
        //}

        static void DisplayAll()
        {
            //1. DATA Source
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=KTjune23;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            cn.Open();

            try
            {
                //2.Query
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from Employees " +
                    "where Basic >= 40000";

                SqlDataReader dr = cmd.ExecuteReader();
                //3.Query Execution
                while (dr.Read())
                {
                    Console.WriteLine(dr["EmpNo"] + " " + dr["Name"] + " " + dr["Basic"] + " " + dr["DeptNo"]);
                }

                dr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                cn.Close();
            }
        }
    }
}