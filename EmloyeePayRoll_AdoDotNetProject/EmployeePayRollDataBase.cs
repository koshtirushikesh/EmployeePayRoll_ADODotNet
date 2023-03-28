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

        public void GetAllDataFromDataBase()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            List<EmployeeModel> employeeModelList = new List<EmployeeModel>();

            using (sqlConnection)
            {
                try
                {
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand("SpGetAllData", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            EmployeeModel employeeModel = new EmployeeModel();

                            employeeModel.EmpId = sqlDataReader.GetInt32(0);
                            employeeModel.EmpName = sqlDataReader.GetString(1);
                            employeeModel.PhoneNumber = sqlDataReader.GetInt64(2);
                            employeeModel.Address = sqlDataReader.GetString(3);
                            employeeModel.Department = sqlDataReader.GetString(4);
                            employeeModel.Gender = sqlDataReader.GetString(5)[0];
                            employeeModel.BasicPay = (float)sqlDataReader.GetDouble(6);
                            employeeModel.Deduction = (float)sqlDataReader.GetDouble(7);
                            employeeModel.TaxablePay = (float)sqlDataReader.GetDouble(8);
                            employeeModel.TAX = (float)sqlDataReader.GetDouble(9);
                            employeeModel.NetPay = (float)sqlDataReader.GetDouble(10);
                            employeeModel.StartDate = sqlDataReader.GetDateTime(11);
                            employeeModel.City = sqlDataReader.GetString(12);
                            employeeModel.Country = sqlDataReader.GetString(13);

                            employeeModelList.Add(employeeModel);
                        }

                        foreach (EmployeeModel employee in employeeModelList)
                        {
                            Console.WriteLine(employee.EmpId + " " +
                                employee.EmpName + " " +
                                employee.PhoneNumber + " " +
                                employee.Address + " " +
                                employee.PhoneNumber + " " +
                                employee.Department + " " +
                                employee.Gender + " " +
                                employee.BasicPay + " " +
                                employee.Deduction + " " +
                                employee.TaxablePay + " " +
                                employee.TAX + " " +
                                employee.NetPay + " " +
                                employee.StartDate + " " +
                                employee.City + " " +
                                employee.Country
                                );
                        }
                    }
                    else
                        Console.WriteLine("Data not found");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        public void UpdateTheSpacificData(EmployeeModel employeeModel)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            using (sqlConnection)
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("SpUpdateDataToDataBase", sqlConnection);

                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@EmpName", employeeModel.EmpName);
                sqlCommand.Parameters.AddWithValue("@Address", employeeModel.Address);

                int result = sqlCommand.ExecuteNonQuery();

                sqlConnection.Close();

                if (result >= 1)
                    Console.WriteLine("Sucsesfully Updated data");
                else
                    Console.WriteLine("Data not found for Update");
            }
        }

        public void DeleteTheSpacificData(string empName)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            using (sqlConnection)
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("SpDeleteDataFromDataBase", sqlConnection);

                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@empName", empName);

                int result = sqlCommand.ExecuteNonQuery();

                sqlConnection.Close();

                if (result >= 1)
                    Console.WriteLine("Sucsesfully deleted data");
                else
                    Console.WriteLine("Data not found for deleat");
            }
        }
    }
}
