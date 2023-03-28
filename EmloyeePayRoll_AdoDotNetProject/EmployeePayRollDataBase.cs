using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace EmloyeePayRoll_AdoDotNetProject
{
    public class EmployeePayRollDataBase
    {
        string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EmployeePayRoll_DB";

        public void AddNewInfoToDataBase(EmployeeModel employeeModel)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            using (sqlConnection)
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("SpAddNewData", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@EmpName", employeeModel.EmpName);
                sqlCommand.Parameters.AddWithValue("@PhoneNumber", employeeModel.PhoneNumber);
                sqlCommand.Parameters.AddWithValue("@Address", employeeModel.Address);
                sqlCommand.Parameters.AddWithValue("@Department", employeeModel.Department);
                sqlCommand.Parameters.AddWithValue("@Gender", employeeModel.Gender);
                sqlCommand.Parameters.AddWithValue("@BasicPay", employeeModel.BasicPay);
                sqlCommand.Parameters.AddWithValue("@Deduction", employeeModel.Deduction);
                sqlCommand.Parameters.AddWithValue("@TaxablePay", employeeModel.TaxablePay);
                sqlCommand.Parameters.AddWithValue("@TAX", employeeModel.TAX);
                sqlCommand.Parameters.AddWithValue("@NetPay", employeeModel.NetPay);
                sqlCommand.Parameters.AddWithValue("@StartDate", employeeModel.StartDate);
                sqlCommand.Parameters.AddWithValue("@City", employeeModel.City);
                sqlCommand.Parameters.AddWithValue("@Country", employeeModel.Country);

                int result = sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                if (result > 0)
                    Console.WriteLine("New Data Added Successfully");
                else
                    Console.WriteLine("Error While Adding data");
            }
        }
    }
}
