using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MenuStudent.model;

namespace MenuStudent.controller
{
    class StudentController
    {
        public static void printStudentList()
        {
            List<Student> listStudents = StudentModel.GetListStudents();
            Console.WriteLine("\tID\tRollNumber\tName\t\t\tPhone\t\tEmail\t\t\tStatus\n");
            foreach (var st in listStudents)
            {
                Console.WriteLine("\t{0, -7} {1, -15} {2, -23} {3, -15} {4, -23} {5, -5}", st.GetId(), st.GetRollNumber(), st.GetName(), st.GetPhone(), st.GetEmail(), st.GetStatus());
            }
        }

        public static void addStudent()
        {
            Student st = new Student();
            Console.WriteLine("----------Insert student----------");
            while (true)
            {
                Console.WriteLine("Please enter rollNumber(>=6 characters): ");
                String rollNumber = Console.ReadLine();
                if (rollNumber.Length >= 6)
                {
                    st.SetRollNumber(rollNumber);
                    break;
                }
                Console.WriteLine("RollNumber is shorter than 6 characters.");
            }

            while (true)
            {
                Console.WriteLine("Please enter name(>=7 characters): ");
                String name = Console.ReadLine();
                if (name.Length >= 7)
                {
                    st.SetName(name);
                    break;
                }
                Console.WriteLine("Name is shorter than 7 characters.");
            }

            while (true)
            {
                Console.WriteLine("Enter phone(10-11 characters): ");
                String phone = Console.ReadLine();
                if (phone.Length >= 10)
                {
                    st.SetPhone(phone);
                    break;
                }

                Console.WriteLine("Phone numbers must be between 10 and 11 characters.");
            }

            while (true)
            {
                Console.WriteLine("Please enter email: ");
                String email = Console.ReadLine();
                String reg =
                    "^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\])|(([a-zA-Z\\-0-9]+\\.)+[a-zA-Z]{2,}))$";

                if (Regex.IsMatch(email, reg))
                {
                    st.SetEmail(email);
                    break;
                }

                Console.WriteLine("The email you entered is not in the correct format.");
            }

            while (true)
            {
                Console.WriteLine("Enter status(0-1): ");
                int status = Convert.ToInt32(Console.ReadLine());
                if (status == 0 || status == 1)
                {
                     st.SetStatus(status);
                    break;
                }
                Console.WriteLine("Status 0 or 1");
            }

            StudentModel.insert(st);
        }

        public static void deleteStudent()
        {
            Console.WriteLine("----------Delete student---------");
            Console.WriteLine("Please enter student rollNumber: ");
            String roll = Console.ReadLine();
            Student st = StudentModel.getByRollNumber(roll);
            Console.WriteLine("\tID\tRollNumber\tName\t\t\tPhone\t\tEmail\t\t\tStatus\n");
            Console.WriteLine("\t{0, -7} {1, -15} {2, -23} {3, -15} {4, -23} {5, -5}", st.GetId(), st.GetRollNumber(), st.GetName(), st.GetPhone(), st.GetEmail(), st.GetStatus());
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("Do you want to delete student? Y/N");
            String choice = Console.ReadLine();
            if (choice.Equals("Y"))
            {
                StudentModel.delete(st);
                Console.WriteLine("Delete success!");
            }
        }
    }
}
