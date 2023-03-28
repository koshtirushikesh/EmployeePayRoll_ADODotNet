using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace EmloyeePayRoll_AdoDotNetProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            EmployeeModel empModel = new EmployeeModel()
            {
                EmpId = 1,
                EmpName = "rushi",
                PhoneNumber = 987654321,
                Address = "3/5 jay",
                Department = "HR",
                Gender = 'M',
                BasicPay = 20000,
                Deduction = 4000,
                TaxablePay = 1000,
                TAX = 200,
                NetPay = 15000,
                StartDate = DateTime.Now,
                City = "Mumbai",
                Country = "IN"
            };

            EmployeePayRollDataBase empPayRollDataBase = new EmployeePayRollDataBase();

            bool flag = true;
            while (flag)
            {
                Console.WriteLine("\n1. Add Employee" +
                    "\n2. Get All Data From Data Base");
                Console.WriteLine("3. Exit the program");

                Console.Write("\nEnter option: ");
                int option = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("");

                switch (option)
                {
                    case 1: empPayRollDataBase.AddNewInfoToDataBase(empModel); break;
                    case 2: empPayRollDataBase.GetAllDataFromDataBase(); break;
                    case 3: flag = false; break;
                }
                Console.ReadLine();
            }

        }
    }
}
