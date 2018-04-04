using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MenuStudent.model
{
    class StudentModel
    {
        public static List<Student> GetListStudents()
        {
            try
            {
                String query = "SELECT * FROM student";
                List<Student> listStudents = new List<Student>();
                MySqlCommand cmd = new MySqlCommand(query, ConnectionHandle.GetDBConnection());
                ConnectionHandle.OpenConnection();
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    int id = (int)dataReader["id"];
                    String rollNumber = (string)dataReader["rollNumber"];
                    String name = (string)dataReader["name"];
                    String phone = (string)dataReader["phone"];
                    String email = (string)dataReader["email"];
                    int status = (int)dataReader["status"];
                    Student student = new Student(id, rollNumber, name, phone, email, status);
                    listStudents.Add(student);
                }
                ConnectionHandle.CloseConnection();
                return listStudents;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static void insert(Student st)
        {
            try
            {
                String insert =
                    $"INSERT INTO student(rollNumber, name, phone, email, status) VALUES ('{st.GetRollNumber()}', '{st.GetName()}', '{st.GetPhone()}', '{st.GetEmail()}', '{st.GetStatus()}')";
                MySqlCommand cmd = new MySqlCommand(insert, ConnectionHandle.GetDBConnection());
                ConnectionHandle.OpenConnection();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Insert success!");
                ConnectionHandle.CloseConnection();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static void delete(Student st)
        {
            try
            {
                String sqlDelete = $"UPDATE student SET status = -1 WHERE rollNumber = '{st.GetRollNumber()}'";
//                Console.WriteLine(sqlDelete);          
                MySqlCommand cmd = new MySqlCommand(sqlDelete, ConnectionHandle.GetDBConnection());
                ConnectionHandle.OpenConnection();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Delete success!");
                ConnectionHandle.CloseConnection();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static Student getByRollNumber(String roll)
        {
            Student student = null;
            try
            {
                String sqlFind = "SELECT * FROM student WHERE rollNumber = \"" + roll + "\"";
                MySqlCommand cmd = new MySqlCommand(sqlFind, ConnectionHandle.GetDBConnection());
                ConnectionHandle.OpenConnection();
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    int id = (int)dataReader["id"];
                    String rollNumber = (string)dataReader["rollNumber"];
                    String name = (string)dataReader["name"];
                    String phone = (string)dataReader["phone"];
                    String email = (string)dataReader["email"];
                    int status = (int)dataReader["status"];
                    student = new Student(id, rollNumber, name, phone, email, status);
                }
                ConnectionHandle.CloseConnection();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return student;
        }
    }
}
