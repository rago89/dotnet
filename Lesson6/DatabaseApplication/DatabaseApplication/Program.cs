using System.Data;
using System.Data.SqlClient;
using System.Linq;

string connectionString = "Server=localhost;Database=TestDb;Trusted_Connection=True;";

ReadStudentRecords();
DataAdapterUpdateStudent();
DataAdapterGetStudents();

void ReadStudentRecords()
{
    using SqlConnection connection = new SqlConnection(connectionString);

    try
    {
        connection.Open();

        var queryString = "SELECT Id, FirstName, LastName, Age FROM Students";
        SqlCommand command = new SqlCommand(queryString, connection);
        SqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            Console.WriteLine($"\t{reader[0]}\t{reader[1]}\t{reader[2]}\t{reader[3]}");
        }
        reader.Close();
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    finally
    {
        connection.Close();
    }
    Console.WriteLine();
}

void InsertStudentRecord()
{
    using SqlConnection connection = new SqlConnection(connectionString);

    try
    {
        var command = new SqlCommand("INSERT INTO Students (FirstName, LastName, Age) VALUES ('Veronica', 'Hurbert', 55)",
            connection);

        connection.Open();

        command.ExecuteNonQuery();

        Console.WriteLine("Insert successfully");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    finally
    {
        connection.Close();
    }
}

void DataAdapterGetStudents()
{
    using var connection = new SqlConnection(connectionString);
    try
    {
        var dataAdapter = new SqlDataAdapter("SELECT * FROM Students; SELECT * FROM Classes", connection);

        var dataSet = new DataSet();

        dataAdapter.Fill(dataSet);
        dataSet.Tables[0].TableName = "Students";
        dataSet.Tables[1].TableName = "Classes";

        var firstNames = dataSet.Tables["Students"].AsEnumerable()
            .Select(r => r["FirstName"].ToString());
        
        var studentsWhoHaveAClass = dataSet.Tables["Students"].AsEnumerable()
            .Where(s => !string.IsNullOrEmpty(s["ClassID"].ToString()))
            .Select(s => s["FirstName"] + " " + s["LastName"]);

        foreach (var studentWithClass in studentsWhoHaveAClass)
        {
            Console.WriteLine(studentWithClass);
        }

        //foreach (DataTable table in dataSet.Tables)
        //{
        //    Console.WriteLine(table.TableName);
        //    foreach (DataRow row in table.Rows)
        //    {
        //        if (table.TableName == "Students")
        //            Console.WriteLine($"\t{row[0]}\t{row["f"]}\t{row[2]}\t{row[3]}\t{row[4]}");
        //        else
        //            Console.WriteLine($"\t{row[0]}\t{row[1]}\t{row[2]}");
        //    }
        //}
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

void DataAdapterUpdateStudent()
{
    using var connection = new SqlConnection(connectionString);
    try
    {
        var dataAdapter = new SqlDataAdapter("SELECT * FROM Students", connection);

        dataAdapter.UpdateCommand = new SqlCommand(
            "UPDATE Students SET FirstName = @FirstName, LastName = @LastName, Age = @Age " +
            "WHERE Id = @Id;", connection);

        dataAdapter.UpdateCommand.Parameters.Add(
            "@FirstName", SqlDbType.NVarChar, 20, "FirstName");

        dataAdapter.UpdateCommand.Parameters.Add(
            "@LastName", SqlDbType.NVarChar, 30, "LastName");

        dataAdapter.UpdateCommand.Parameters.Add(
            "@Age", SqlDbType.Int, 2, "Age");

        SqlParameter parameter = dataAdapter.UpdateCommand.Parameters.Add(
            "@Id", SqlDbType.Int);
        parameter.SourceColumn = "Id";
        parameter.SourceVersion = DataRowVersion.Original;

        var dataSet = new DataSet();

        dataAdapter.Fill(dataSet);

        var rowNeedToUpdate = dataSet.Tables[0].AsEnumerable()
            .FirstOrDefault(s => s["FirstName"].ToString() == "General");

        if (rowNeedToUpdate != null)
        {
            rowNeedToUpdate["FirstName"] = "General";
            rowNeedToUpdate["LastName"] = "Kenobi";
            rowNeedToUpdate["Age"] = "30";
            dataAdapter.Update(dataSet);
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}