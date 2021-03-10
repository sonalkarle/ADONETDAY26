using ConnectionTest;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace EmployeePayrollService
{
    public class EmployeePayroll
    {
        static string connectionString = "data Source=DESKTOP-OKP25QH;Initial Catalog=employee_Payroll;Integrated security=SSPI";



        public List<Employee> ReturnAllRecords()
        {
            List<Employee> employees = new List<Employee>();
            Employee emp = new Employee();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = @"Select ID,Name,BasicPay,StartDate,Gender,PhoneNumber,Address,Department,Deduction,TaxablePay,IncomeTax,NetPay from  employee_Payroll";

            using (connection)
            {
                SqlCommand sqlCommand = new SqlCommand(query, connection);
               
                connection.Open();
                SqlDataReader dr = sqlCommand.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        emp.id = dr.GetInt32(0);
                        emp.name = dr.GetString(1);
                        emp.basicPay = dr.IsDBNull(7) ? 0 : dr.GetInt32(7);
                        emp.startDate = dr.GetDateTime(11);
                        emp.gender = Convert.ToChar(dr.GetString(3));
                        emp.phoneNumber = dr.IsDBNull(4) ? 0 : dr.GetInt64(4);
                        emp.address = dr.IsDBNull(5) ? "" : dr.GetString(5);
                        emp.department = dr.GetString(6);
                        emp.deduction = dr.IsDBNull(8) ? 0 : dr.GetInt32(8);
                        emp.taxablePay = dr.IsDBNull(9) ? 0 : dr.GetInt32(9);
                        emp.incomeTax = dr.IsDBNull(10) ? 0 : dr.GetInt32(10);
                        emp.netPay = dr.IsDBNull(11) ? 0: dr.GetInt32 (11);
                        employees.Add(emp);
                        Console.WriteLine(emp.id + "," + emp.name + "," + emp.phoneNumber);
                    }
                    
                }
                connection.Close();
            }
            return employees;
        }

        static void Main(string[] args)
        {
            EmployeePayroll emproll = new EmployeePayroll();
            emproll.ReturnAllRecords();
        }
    }
}

