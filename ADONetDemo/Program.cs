using System.Data.SqlClient;
namespace ADONetDemo
{
    internal class Program
    {
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
        static void Main(string[] args)
        {
            string choice = "y";
            while (choice == "y")
            {
                int c = Menu();
                switch (c)
                {
                    case 1: GetRecords(); break;
                    case 2: AddRecord(); break;
                    case 3: DeleteRecord(); break;
                    case 4: EditRecord(); break;    
                }
                Console.WriteLine("Repeat"); choice = Console.ReadLine();
            }

        }
        static void GetRecords()
        {


            // connectionString contains details abt the database with you want to connect
            // it takes some para
            string connectioString = @"server=ANAMIKA\SQLSERVER;database=demo;integrated security=true";
            SqlConnection connection = new SqlConnection(connectioString);

            SqlCommand command = new SqlCommand("select * from student", connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine(reader["rn"] + " " + reader["name"] + " " + reader[2]);
                }
                reader.Close();
                connection.Close();
            }
            else
            {
                Console.WriteLine("There are no records");

            }
        }
         
     static void AddRecord()
    {
            string connectioString = @"server=ANAMIKA\SQLSERVER;database=demo;integrated security=true";
            SqlConnection connection = new SqlConnection(connectioString);
            SqlCommand command = new SqlCommand("insert into student(name , address, marks) values ('deepak', 'delhi', 90)", connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        static void DeleteRecord()
        {
            string connectioString = @"server=ANAMIKA\SQLSERVER;database=demo;integrated security=true";
            SqlConnection connection = new SqlConnection(connectioString);
            SqlCommand command = new SqlCommand("delete  student where rn =1", connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        static void EditRecord()
        {
            string connectioString = @"server=ANAMIKA\SQLSERVER;database=demo;integrated security=true";
            SqlConnection connection = new SqlConnection(connectioString);
            SqlCommand command = new SqlCommand("update  student set name ='newname' where rn =1", connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
                }
    }
}

