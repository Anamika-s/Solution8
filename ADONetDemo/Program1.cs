using System.Data.SqlClient;
using System.Net;
using System.Xml.Linq;
namespace ADONetDemo
{

    //objects that are created in programs are managed by CLR. which means when they are created using new keyword,
    
    // memory is initilaized for them
    // at the end of the program, destructor is called that will destroy these objects from heap
    // CLR calls garbage collector to remove these objects frm heap
    // What abt objects who are pointing to something outsie dotnet
    // for eg. files , database connections
    // such objects , SqlConnection , SqlCommand objects are only closed , but the objects will be still in heap
    // they are not removed by CLR, as they come in unmanged code category
    // we have to destroy them expilictly
    // can be done in 2 ways 
    // 1. use dispose() method
    // 2.use of using block
    
    internal class Program1
    {
        static SqlConnection connection = null;
        static SqlCommand command = null;
        static int Menu()
        {
            Console.WriteLine("1. Read Record");
            Console.WriteLine("2. Add Record");
            Console.WriteLine("3. Delete Record");
            Console.WriteLine("4. Edit Record");
            Console.WriteLine("enter choice");
            int ch = byte.Parse(Console.ReadLine());
            return ch;
        }
        static string GetConnectionString()
        {
            return  @"server=ANAMIKA\SQLSERVER;database=demo;integrated security=true";
        }
        static void Main(string[] args)
        {
            string choice = "y";
            while (choice == "y")
            {
                int c = Menu();
                switch (c)
                {
                    case 1: GetRecords(); break;
                    case 2:
                        {
                            Console.WriteLine("enter name");
                            string name = Console.ReadLine();
                            Console.WriteLine("enter address");
                            string address = Console.ReadLine();
                            Console.WriteLine("enter marks");
                            int marks = byte.Parse(Console.ReadLine());
                            AddRecord(name, address, marks); break;
                        }
                    case 3:
                        {
                            Console.WriteLine("enter rn to delete record");
                            int rn = byte.Parse(Console.ReadLine());
                            DeleteRecord(rn); break;
                        }
                    case 4:
                        {
                            Console.WriteLine("enter rn to edit record");
                            int rn = byte.Parse(Console.ReadLine());
                            Console.WriteLine("enter new address");
                            string address = Console.ReadLine();
                            Console.WriteLine("enter new marks");
                            int marks = byte.Parse(Console.ReadLine());
                            EditRecord(rn, address, marks); break;
                        }
                }
                Console.WriteLine("Repeat"); choice = Console.ReadLine();
            }

        }
        static void GetRecords()
        {


            // connectionString contains details abt the database with you want to connect
            // it takes some para
           
            connection = new SqlConnection(GetConnectionString());
             
            command = new SqlCommand("select * from student", connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine(reader[0] + " " + reader[1] + " " + reader[2]);
                }
                reader.Close();
                connection.Close();

                command.Dispose();
                connection.Dispose();
            }
            else
            {
                Console.WriteLine("There are no records");
            }
        }
        static void AddRecord(string name, string address, int marks)
    {
            
            connection = new SqlConnection(GetConnectionString());
            command = new SqlCommand($"insert into student(name , address, marks) values ('{name}', '{address}', {marks})", connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            command.Dispose (); 
            connection.Dispose();
        }

        static void DeleteRecord(int rn)
        {

            using (connection = new SqlConnection(GetConnectionString()))
            {
                using (command = new SqlCommand($"delete  student where rn = {rn}", connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            }

        static void EditRecord(int rn, string address, int marks)
        {

            using (connection = new SqlConnection(GetConnectionString()))
            {
                using (command = new SqlCommand($"update  student set address={address}, marks={marks} where rn ={rn}", connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

    }
}

