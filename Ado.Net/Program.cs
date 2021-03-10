using System;
using System.Data;
using System.Data.SqlClient;

namespace Ado.Net
{
    class Program
    {
        static string connectionString = @"Data Source=DESKTOP-OKP25QH;Initial Catalog=employee_Payroll";

        public static DataSet GetAllEmployeeData()
        {
            Employeetable employee = new Employeetable();
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return null;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("welcome to Employee Payroll Service");
            GetAllEmployeeData();
        }
    }
}
