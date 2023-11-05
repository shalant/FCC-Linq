using System.Collections.Generic;
using TCPData;
using TCPExtensions;

//List<Employee> employeeList = Data.GetEmployees();
//var filteredEmployees = employeeList.Filter(emp => emp.IsManager == false);

//foreach (var employee in filteredEmployees)
//{
//    Console.WriteLine($"First Name: {employee.FirstName}");
//    Console.WriteLine($"Last Name: {employee.LastName}");
//    Console.WriteLine($"Annual Salary: {employee.AnnualSalary}");
//    Console.WriteLine($"Manager: {employee.IsManager}");
//    Console.WriteLine();
//}

//List<Department> departmentList = Data.GetDepartments();

//var filteredDepartments = departmentList.Where(dept => dept.ShortName == "TE" || dept.ShortName == "HR");

//foreach(var department in filteredDepartments)
//{
//    Console.WriteLine($"Id: {department.Id}");
//    Console.WriteLine($"Short Name: {department.ShortName}");
//    Console.WriteLine($"LongName: {department.LongName}");
//    Console.WriteLine();
//}

List<Employee> employeeList = Data.GetEmployees();
List<Department> departmentList = Data.GetDepartments();

var resultList = from emp in employeeList
                 join dept in departmentList
                 on emp.DepartmentId equals dept.Id
                 select new
                 {
                     FirstName = emp.FirstName,
                     LastName = emp.LastName,
                     AnnualSalary = emp.AnnualSalary,
                     Manager = emp.IsManager,
                     Department = dept.LongName
                 };
//IN SQL
// SELECT e.FirstName, e.LastName, e.AnnualSalary, e.IsManager, d.LongName
// FROM Employee e INNER JOIN Department d on e.DepartmentID = d.Id


var averageAnnualSalary = resultList.Average(a => a.AnnualSalary);
var highestAnnualSalary = resultList.Max(a => a.AnnualSalary);
var lowestAnnualSalary = resultList.Min(a => a.AnnualSalary);

Console.WriteLine($"Average Annual Salary: {averageAnnualSalary}");

Console.ReadKey();