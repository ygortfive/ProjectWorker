using System;
using System.Globalization;
using Composicao_Exercicio_Resolvido.Entities.Enums;
using Composicao_Exercicio_Resolvido.Entities;

namespace Composicao_Exercicio_Resolvido
{
    class Program
    {
        static void Main(string[] args)
        { /* Ler os dados de um trabalhdor com N contratos. Depois, solicitar 
             do usuário um mês e mostrar qual foi o salário do funcionário nesse mês,
             conforme exemplo em pdf da atividade */

            string deptName, name, monthAndYear;
            WorkerLevel level;
            double baseSalary, valuePerHour;
            int n, hours, month, year;
            DateTime date;


            Console.Write("Enter department's name: ");
            deptName = Console.ReadLine();
            Console.WriteLine("Enter worker data: ");
            Console.Write("Name: ");
            name = Console.ReadLine();
            Console.Write("Level (Junior/MidLevel/Senior): ");
            level = Enum.Parse<WorkerLevel>(Console.ReadLine());
            Console.Write("Base Salary: ");
            baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Department dept = new Department(deptName);
            Worker worker = new Worker(name, level, baseSalary, dept);

            Console.Write("How many contracts to this worker? ");
            n = int.Parse(Console.ReadLine());

            for(int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Enter #{i} contract data: ");
                Console.Write("Dara (DD/MM/YYYY): ");
                date = DateTime.Parse(Console.ReadLine());
                Console.Write("Value per hour: ");
                valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duration (Hours): ");
                hours = int.Parse(Console.ReadLine());

                HourContract contract = new HourContract(date, valuePerHour, hours);
                worker.AddContract(contract);
            }

            Console.WriteLine();
            Console.Write("Enter month and year to calculate income (MM/YYYY): ");
            monthAndYear = Console.ReadLine();
            month = int.Parse(monthAndYear.Substring(0, 2));
            year = int.Parse(monthAndYear.Substring(3));
            Console.WriteLine($"Name: {worker.Name}");
            Console.WriteLine($"Department: {worker.Department.Name}");
            Console.WriteLine($"Income for {monthAndYear}: {worker.Income(year,month).ToString("F2",CultureInfo.InvariantCulture)}");
            

        }
    }
}
