using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax.
             *
             * HINT: Use the List of Methods defined in the Lecture Material Google Doc ***********
             *
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */
            //List the numbers in the original array
            Console.WriteLine("Here is an array of Numbers");
            foreach (var i in numbers)
            {
                Console.WriteLine(i);
            }
            
            //Done - Print the Sum and Average of numbers
            Console.WriteLine($"Sum = {numbers.Sum(x => x)} Average = {numbers.Average(x => x)}");
            Console.WriteLine();

            //DONE - Order numbers in ascending order and decsending order. Print each to console.
            //Order and Print in Ascending Order
            var sortAscending = numbers.OrderBy(x => x);
            Console.WriteLine("Here is the array sorted in Ascending Order");
            foreach (var i in sortAscending)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();
            //Order and Print in Descending Order
            var sortDescending = numbers.OrderByDescending(x => x);
            Console.WriteLine("Here is the array sorted in Descending Order");
            foreach (var i in sortDescending)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();

            //DONE - Print to the console only the numbers greater than 6 
            Console.WriteLine("This is a list of the numbers in the array > 6");          
            foreach (var i in numbers.Where(x => x > 6))
            {
                Console.WriteLine(i);
            }           
            Console.WriteLine();

            //DONE - Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only
            Console.WriteLine("Here is a list of the first 4 numbers in the list after it has been sorted.");
            foreach (var num in numbers.OrderBy(x => x).Take(4))
            {
                Console.WriteLine(num);
            }
            Console.WriteLine();

            //DONE - Change the value at index 4 to your age, then print the numbers in decsending order
            Console.WriteLine("Here is a list of the first with my age at index 4 sorted in Decsending Order");
            numbers[4] = 59;
            foreach (var num in numbers.OrderByDescending(x => x))
            {
                Console.WriteLine(num);
            }
            Console.WriteLine();

            // List of employees ***Do not remove this***
            var employees = CreateEmployees();

            //Here is the List of All Employees
            Console.WriteLine("Complete Employee List");
            foreach (var employee in employees) 
            {
                Console.WriteLine($"Name: {employee.FirstName} {employee.LastName}  Age:{employee.Age} " +
                   $"Experience: {employee.YearsOfExperience}");
            }
            Console.WriteLine();

            //DONE - Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S.
            //DONE - Order this in acesnding order by FirstName.
            Console.WriteLine("Here are the Employees with FirstNames beginning with 'C' or 'S'.");
            foreach (var employee in employees.Where(x => x.FirstName.StartsWith("C") || x.FirstName.StartsWith("S")).OrderBy(x => x.FirstName))
            {
                Console.WriteLine($"Name: {employee.FirstName} {employee.LastName}");
            }
            Console.WriteLine();

            //DONE - Print all the employees' FullName and Age who are over the age 26 to the console.
            //Order this by Age first and then by FirstName in the same result.
            Console.WriteLine("This is a List of All Employees over 26");        
            foreach (var employee in employees.Where(x => x.Age > 26).OrderBy(x => x.Age).ThenBy(x => x.FirstName))
            {
                Console.WriteLine($"Name: {employee.FirstName} {employee.LastName}  Age:{employee.Age} ");
            }
            Console.WriteLine();

            //DONE - Print the Sum and then the Average of the employees' YearsOfExperience
            //       if their YOE is less than or equal to 10 AND Age is greater than 35

            Console.WriteLine("Here are the Empolyees older than 35 with 10 or less Years of Experience");
            var subsetEmployees = employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35);
            
            foreach (var employee in subsetEmployees)         
            {
                Console.WriteLine($"Name: {employee.FirstName} {employee.LastName}  Age:{employee.Age} " +
                   $"Experience: {employee.YearsOfExperience}");
            }
            Console.WriteLine();
            Console.WriteLine($"Sum of their Years of Expericene: {subsetEmployees.Sum(x => x.YearsOfExperience)}");
            Console.WriteLine($"Average Years of Expericene:      {subsetEmployees.Average(x => x.YearsOfExperience)}");
            Console.WriteLine();

            //DONE - Add an employee to the end of the list without using employees.Add()
            Console.WriteLine("A new Employee was Appended to the List");
            employees = employees.Append(new Employee("New", "Employee", 35, 10)).ToList();

            Console.WriteLine("Here is the new list of Current Employees");
            foreach (var employee in employees.OrderBy(x => x.FullName))
            {
                Console.WriteLine($"Name: {employee.FullName}  Age:{employee.Age} " +
                  $"Experience: {employee.YearsOfExperience}");
            }



            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
