using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MenuStudent.controller;
using MenuStudent.model;

namespace MenuStudent
{
    class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {
                Console.WriteLine("----------Student Manager----------");
                Console.WriteLine("1. List student");
                Console.WriteLine("2. Add student");
                Console.WriteLine("3. Update student");
                Console.WriteLine("4. Delete Student");
                Console.WriteLine("5. Exit");
                Console.WriteLine("Please enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        StudentController.printStudentList();
                        break;
                    case 2:
                        StudentController.addStudent();
                        break;
                    case 3:
                        Console.WriteLine("ba");
                        break;
                    case 4:
                        StudentController.deleteStudent();
                        break;
                    case 5:
                        System.Environment.Exit(1);
                        break;
                    default:
                        Console.WriteLine("Please choice 1-5");
                        break;
                }
            }
        }
    }
}
