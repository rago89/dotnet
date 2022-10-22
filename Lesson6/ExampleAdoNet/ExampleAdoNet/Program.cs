using System.Data;
using System.Data.SqlClient;
using System.Linq;
using static System.Int32;

#region Classes explanation

/*
    The ADO.NET SqlConnection class belongs to System.Data.SqlClient namespace and is used to establish an open connection to the SQL Server database. 
    The most important point that you need to remember is the connection does not close implicitly even it goes out of scope.
    Therefore, it is always recommended and always a good programming practice to close the connection object explicitly by calling the Close() method of the connection object.

    The ADO.NET SqlCommand class in C# is used to store and execute the SQL statement against the SQL Server database.
    As you can see in the below image, the SqlCommand class is a sealed class and is inherited from the DbCommand class and implement the ICloneable interface.
    As a sealed class, it cannot be inherited.

    The ADO.NET SqlDataReader class in C# is used to read data from the SQL Server database in the most efficient manner.
    It reads data in the forward-only direction.
    It means, once it read a record, it will then read the next record, there is no way to go back and read the previous record.

    The ADO.NET SqlDataAdapter in C# works as a bridge between a DataSet and a data source (SQL Server Database) to retrieve data.
    The SqlDataAdapter is a class that represents a set of SQL commands and a database connection.
    It can be used to fill the DataSet and update the data source.

    The DataTable in C# is similar to the Tables in SQL.
    That means the DataTable is also going to represent the relational data in tabular form i.e. rows and columns and this data is going to be store in memory.
    When you create an instance of DataTable, by default, it does not have table schema i.e. it does not have any columns or constraints by default.
    You can create a table schema by adding columns and constraints to the table.
    Once you define the schema (i.e. columns and constraints) for the DataTable, then only you can add rows to the data table.
    In order to use DataTable, you must have to include the System.Data namespace.

    The DataSet represents a subset of the database in memory.
    That means the ADO.NET DataSet is a collection of data tables that contains the relational data in memory in tabular format.
    It does not require a continuous open or active connection to the database.
    The DataSet is based on the disconnected architecture.
    This is the reason why it is used to fetch the data without interacting with any data source.
    We will discuss the disconnected architecture of the data set in our upcoming articles.

    DataSet to use:
        When you want to caches the data locally in your application so that you can manipulate the data.
        When you want to interact with the data dynamically i.e. binding the data to windows form control.
        When you want to work with disconnected architecture.

    DataReader to use:
        If you require some other functionality mentioned above, then you need to use DataReader which will improve the performance of your application.
        DataReader works on connected-oriented architecture i.e. it requires an open connection to the database.

    A Transaction is a set of operations (multiple DML Operations) that ensures either all of the database operations succeed or all of them failed to ensure data consistency.
    This means the job is never half done, either all of it is done or nothing is done.

    
*/

#endregion

string connectionString = "Server=localhost;Database=RestaurantDb;Trusted_Connection=True;";

RemoveFromDataSourceWithAdapter();

void ReadPersonRecords()
{
    // Provide the query string with a parameter placeholder.
    string queryString = "SELECT id, name, age from Persons";

    // Create and open the connection in a using block. This
    // ensures that all resources will be closed and disposed
    // when the code exits.
    using SqlConnection connection = new SqlConnection(connectionString);

    // Create the Command and Parameter objects.
    SqlCommand command = new SqlCommand(queryString, connection);
    //command.Parameters.AddWithValue("@pricePoint", paramValue);

    // Open the connection in a try/catch block.
    // Create and execute the DataReader, writing the result
    // set to the console window.
    try
    {
        connection.Open();
        SqlDataReader reader = command.ExecuteReader();
        Console.WriteLine("Reading from database");
        while (reader.Read())
        {
            Console.WriteLine("\t{0}\t{1}\t{2}",
                reader[0], reader[1], reader[2]);
        }
        reader.Close();
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }

    Console.WriteLine();
}

void ReadOrderRecords()
{
    // Provide the query string with a parameter placeholder.
    string queryString = "SELECT Id, OrderNumber, Description, PersonID from Orders";

    // Create and open the connection in a using block. This
    // ensures that all resources will be closed and disposed
    // when the code exits.
    using SqlConnection connection = new SqlConnection(connectionString);

    // Create the Command and Parameter objects.
    SqlCommand command = new SqlCommand(queryString, connection);
    //command.Parameters.AddWithValue("@pricePoint", paramValue);

    // Open the connection in a try/catch block.
    // Create and execute the DataReader, writing the result
    // set to the console window.
    try
    {
        connection.Open();
        SqlDataReader reader = command.ExecuteReader();
        Console.WriteLine("Reading from database");
        while (reader.Read())
        {
            Console.WriteLine("\t{0}\t{1}\t{2}",
                reader[0], reader[1], reader[2], reader[3]);
        }
        reader.Close();
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }

    Console.WriteLine();
}

void InsertPersonRecord()
{
    SqlConnection con = null;
    try
    {
        // Creating Connection  
        con = new SqlConnection(connectionString);
        // writing sql query  
        SqlCommand cm = new SqlCommand("insert into Persons (name, age) values ('Jack Morrison', 35)", con);

        // Opening Connection  
        con.Open();
        // Executing the SQL query  
        cm.ExecuteNonQuery();
        // Displaying a message  
        Console.WriteLine("Record Inserted Successfully");
    }
    catch (Exception e)
    {
        Console.WriteLine("OOPs, something went wrong." + e);
    }
    // Closing the connection  
    finally
    {
        con?.Close();
    }
    Console.WriteLine();
}

void InsertOrderRecord()
{
    SqlConnection con = null;
    try
    {
        // Creating Connection  
        con = new SqlConnection(connectionString);
        // writing sql query  
        SqlCommand cm = new SqlCommand("insert into Orders (OrderNumber, PersonID) values (66, 1)", con);

        // Opening Connection  
        con.Open();
        // Executing the SQL query  
        cm.ExecuteNonQuery();
        // Displaying a message  
        Console.WriteLine("Record Inserted Successfully");
    }
    catch (Exception e)
    {
        Console.WriteLine("OOPs, something went wrong." + e);
    }
    // Closing the connection  
    finally
    {
        con?.Close();
    }
    Console.WriteLine();
}

void DeleteData()
{
    SqlConnection con = null;
    try
    {
        // Creating Connection  
        con = new SqlConnection(connectionString);
        // writing sql query  
        SqlCommand cm = new SqlCommand("DELETE FROM Persons WHERE name LIKE '%Jack%'", con);
        // Opening Connection  
        con.Open();
        // Executing the SQL query  
        cm.ExecuteNonQuery();
        Console.WriteLine("Record Deleted Successfully");
    }
    catch (Exception e)
    {
        Console.WriteLine("OOPs, something went wrong." + e);
    }
    // Closing the connection  
    finally
    {
        con.Close();
    }
    Console.WriteLine();
}

void UseDataAdapterNormal()
{
    SqlConnection con = null;
    try
    {
        // Creating Connection  
        con = new SqlConnection(connectionString);
        // Creating SqlDataAdapter
        SqlDataAdapter da = new SqlDataAdapter("SELECT TOP (10) Id, Name, Age FROM Persons", con);

        //Using Data Table
        DataTable dt = new DataTable();
        da.Fill(dt);
        Console.WriteLine("Using Data Table");
        foreach (DataRow row in dt.Rows)
        {
            Console.WriteLine(row["Name"] + ",  " + row["Age"]);
        }
        Console.WriteLine("---------------");
        //Using DataSet
        DataSet ds = new DataSet();
        da.Fill(ds, "Persons");
        Console.WriteLine("Using Data Set");
        foreach (DataRow row in ds.Tables["Persons"].Rows)
        {
            Console.WriteLine(row["Name"] + ",  " + row["Age"]);
        }
    }
    catch (Exception e)
    {
        Console.WriteLine("OOPs, something went wrong." + e);
    }
    // Closing the connection  
    finally
    {
        con.Close();
    }
    Console.WriteLine();
}

void UseDataAdapterStoredProcedure()
{
    SqlConnection con = null;
    try
    {
        // Creating Connection  
        con = new SqlConnection(connectionString);
        // Creating SqlDataAdapter
        SqlDataAdapter da = new SqlDataAdapter("spGetPersons", con);
        da.SelectCommand.CommandType = CommandType.StoredProcedure;

        //Using Data Table
        DataTable dt = new DataTable();
        da.Fill(dt);
        foreach (DataRow row in dt.Rows)
        {
            Console.WriteLine(row["id"] + ", " + row["name"] + ",  " + row["age"]);
        }
    }
    catch (Exception e)
    {
        Console.WriteLine("OOPs, something went wrong." + e);
    }
    // Closing the connection  
    finally
    {
        con.Close();
    }
    Console.WriteLine();
}

void UseOfDataTable()
{
    try
    {
        //Creating data table instance
        DataTable dataTable = new DataTable("Persons");
        //Add the DataColumn using all properties
        DataColumn Id = new DataColumn("id");
        Id.DataType = typeof(int);
        Id.Unique = true;
        Id.AllowDBNull = false;
        Id.Caption = "Person ID";
        dataTable.Columns.Add(Id);

        //Add the DataColumn few properties
        DataColumn Name = new DataColumn("name");
        Name.MaxLength = 50;
        Name.AllowDBNull = false;
        dataTable.Columns.Add(Name);

        //Add the DataColumn using defaults
        DataColumn age = new DataColumn("age");
        dataTable.Columns.Add(age);

        //Setting the Primary Key
        dataTable.PrimaryKey = new DataColumn[] { Id };

        //Add New DataRow by creating the DataRow object
        DataRow row1 = dataTable.NewRow();
        row1["id"] = 101;
        row1["name"] = "Jack";
        row1["age"] = "25";
        dataTable.Rows.Add(row1);
        //Adding new DataRow by simply adding the values
        dataTable.Rows.Add(102, "Jack", "25");
        foreach (DataRow row in dataTable.Rows)
        {
            Console.WriteLine(row["Id"] + ",  " + row["Name"] + ",  " + row["age"]);
        }
    }
    catch (Exception e)
    {
        Console.WriteLine("OOPs, something went wrong.\n" + e);
    }
    Console.ReadKey();
}

void UseOfDataTableAutoIncrement()
{
    try
    {
        //Creating data table instance
        DataTable dataTable = new DataTable("Student");

        DataColumn Id = new DataColumn
        {
            ColumnName = "id",
            DataType = System.Type.GetType("System.Int32"),
            AutoIncrement = true,
            AutoIncrementSeed = 1000,
            AutoIncrementStep = 10
        };
        dataTable.Columns.Add(Id);

        //Add the DataColumn few properties
        DataColumn Name = new DataColumn("name");
        Name.MaxLength = 50;
        Name.AllowDBNull = false;
        dataTable.Columns.Add(Name);

        //Add the DataColumn using defaults
        DataColumn Age = new DataColumn("age");
        dataTable.Columns.Add(Age);

        //Add New DataRow by creating the DataRow object
        DataRow row1 = dataTable.NewRow();

        row1["name"] = "John";
        row1["age"] = "40";
        dataTable.Rows.Add(row1);

        //Adding new DataRow by simply adding the values
        //Supply null for auto increment column
        dataTable.Rows.Add(null, "Musk", "50");
        foreach (DataRow row in dataTable.Rows)
        {
            Console.WriteLine(row["id"] + ",  " + row["name"] + ",  " + row["age"]);
        }
    }
    catch (Exception e)
    {
        Console.WriteLine("OOPs, something went wrong.\n" + e);
    }
    Console.ReadKey();
}

void UseDataSet()
{
    try
    {
        // Craeting Customer table
        DataTable Persons = new DataTable("Persons");
        //Creating column and schema
        DataColumn PersonId = new DataColumn("Id", typeof(int));
        Persons.Columns.Add(PersonId);
        DataColumn PersonName = new DataColumn("Name", typeof(string));
        Persons.Columns.Add(PersonName);
        DataColumn PersonAge = new DataColumn("Age", typeof(int));
        Persons.Columns.Add(PersonAge);
        //Adding Data Rows into Customer table
        Persons.Rows.Add(101, "Jessica", "22");
        Persons.Rows.Add(202, "Vincent", "34");

        // Craeting Orders table
        DataTable Orders = new DataTable("Orders");
        //Creating column and schema
        DataColumn OrderId = new DataColumn("Id", typeof(int));
        Orders.Columns.Add(OrderId);
        DataColumn OrderNumber = new DataColumn("OrderNumber", typeof(int));
        Orders.Columns.Add(OrderNumber);
        DataColumn PersonIdOfOrder = new DataColumn("PersonId", typeof(int));
        Orders.Columns.Add(PersonIdOfOrder);

        //Adding Data Rows into Orders table
        Orders.Rows.Add(10001, 1, 101);
        Orders.Rows.Add(10002, 2, 202);

        //Creating DataSet object
        DataSet dataSet = new DataSet();
        //Adding DataTables into DataSet
        dataSet.Tables.Add(Persons);
        dataSet.Tables.Add(Orders);
        //Customer Table
        Console.WriteLine("Persons Table Data: ");
        //Fetching DataTable from dataset using the Index position
        foreach (DataRow row in dataSet.Tables[0].Rows)
        {
            Console.WriteLine(row["Id"] + ",  " + row["Name"] + ",  " + row["Age"]);
        }
        Console.WriteLine();
        //Orders Table
        Console.WriteLine("Orders Table Data: ");
        //Fetching DataTable from the DataSet using the table name
        foreach (DataRow row in dataSet.Tables["Orders"].Rows)
        {
            Console.WriteLine(row["Id"] + ",  " + row["OrderNumber"] + ",  " + row["PersonId"]);
        }
    }
    catch (Exception e)
    {
        Console.WriteLine("OOPs, something went wrong.\n" + e);
    }
    Console.ReadKey();
}

void UseDataSetWithSql()
{
    try
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("select * from Persons", connection);
            //Creating DataSet Object
            DataSet dataSet = new DataSet();
            //Filling the DataSet
            dataAdapter.Fill(dataSet);
            //Iterating through the DataSet 
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                Console.WriteLine(row["Id"] + ",  " + row["Name"] + ",  " + row["Age"]);
            }
        }
        Console.ReadKey();
    }
    catch (Exception e)
    {
        Console.WriteLine("OOPs, something went wrong.\n" + e);
    }
    Console.ReadKey();
}

void UseDatasetWithSqlMultipleTables()
{
    try
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            //Sql Command return data from customers and orders table
            SqlDataAdapter dataAdapter = new SqlDataAdapter("select * from persons; select * from orders", connection);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            // First Table
            Console.WriteLine("Table 1 Data");
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                Console.WriteLine(row["Id"] + ",  " + row["Name"] + ",  " + row["Age"]);
            }
            Console.WriteLine();
            // Second Table
            Console.WriteLine("Table 2 Data");
            foreach (DataRow row in dataSet.Tables[1].Rows)
            {
                Console.WriteLine(row["Id"] + ",  " + row["OrderNumber"] + ",  " + row["PersonID"]);
            }
        }

        Console.ReadKey();
    }
    catch (Exception e)
    {
        Console.WriteLine("OOPs, something went wrong.\n" + e);
    }
    Console.ReadKey();
}

void UseDatasetWithSqlMultipleTablesNames()
{
    try
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            //Sql Command return data from customers and orders table
            SqlDataAdapter dataAdapter = new SqlDataAdapter("select * from persons; select * from orders", connection);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);

            dataSet.Tables[0].TableName = "Persons";
            dataSet.Tables[1].TableName = "Orders";

            // First Table
            Console.WriteLine("Table 1 Data");
            foreach (DataRow row in dataSet.Tables["Persons"].Rows)
            {
                Console.WriteLine(row["Id"] + ",  " + row["Name"] + ",  " + row["Age"]);
            }
            Console.WriteLine();
            // Second Table
            Console.WriteLine("Table 2 Data");
            foreach (DataRow row in dataSet.Tables["Orders"].Rows)
            {
                Console.WriteLine(row["Id"] + ",  " + row["OrderNumber"] + ",  " + row["PersonID"]);
            }
        }

        Console.ReadKey();
    }
    catch (Exception e)
    {
        Console.WriteLine("OOPs, something went wrong.\n" + e);
    }
    Console.ReadKey();
}

void DatasetUseLinq1()
{
    var ds = new DataSet();
    LoadingDataIntoDataSet(ds);

    DataTable persons = ds.Tables["Persons"];

    IEnumerable<DataRow> query =
        from person in persons.AsEnumerable()
        select person;

    Console.WriteLine("Person Names:");
    foreach (DataRow p in query)
    {
        Console.WriteLine(p.Field<string>("Name"));
    }
}

void DatasetUseLinq2()
{
    var ds = new DataSet();
    LoadingDataIntoDataSet(ds);

    DataTable persons = ds.Tables["Persons"];

    var personNames = persons.AsEnumerable()
        .Select(p => p.Field<string>("Name"));

    Console.WriteLine("Person Names:");
    foreach (var personName in personNames)
    {
        Console.WriteLine(personName);
    }
}

void LoadingDataIntoDataSet(DataSet ds)
{
    try
    {
        // Create a new adapter and give it a query to fetch sales order, contact,
        // address, and product information for sales in the year 2002. Point connection
        // information to the configuration setting "AdventureWorks".
        SqlDataAdapter da = new SqlDataAdapter("SELECT Id, Name, Age FROM Persons;" + 
            "SELECT Id, OrderNumber, PersonID FROM Orders;",
        connectionString);

        // Add table mappings.
        da.TableMappings.Add("Table", "Persons");
        da.TableMappings.Add("Table1", "Orders");
        
        // Fill the DataSet.
        da.Fill(ds);

        // Add data relations.
        DataTable personsTable = ds.Tables["Persons"];
        DataTable ordersTable = ds.Tables["Orders"];
        DataRelation order = new DataRelation("PersonOrder",
            ordersTable.Columns["PersonID"],
            personsTable.Columns["Id"], true);
        ds.Relations.Add(order);
    }
    catch (SqlException ex)
    {
        Console.WriteLine("SQL exception occurred: " + ex.Message);
    }
}

void UseTransactions()
{
    try
    {
        Console.WriteLine("Before Transaction");
        ReadOrderRecords();
        OrdersUpdate();
        Console.WriteLine("After Transaction");
        ReadOrderRecords();
    }
    catch (Exception e)
    {
        Console.WriteLine("OOPs, something went wrong" + e.Message);
    }
    Console.ReadKey();
}

void OrdersUpdate()
{
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        // The connection needs to be open before we begin a transaction
        connection.Open();
        // Create the transaction object by calling the BeginTransaction method on connection object
        SqlTransaction transaction = connection.BeginTransaction();
        try
        {
            // Associate the first update command with the transaction
            SqlCommand cmd = new SqlCommand("UPDATE Orders SET Description = 'Updated description' WHERE OrderNumber = 25", connection, transaction);
            cmd.ExecuteNonQuery();
            // Associate the second update command with the transaction
            cmd = new SqlCommand("UPDATE Orders SET Description = 'New description' WHERE OrderNumber = 26", connection, transaction);
            cmd.ExecuteNonQuery();
            // If everythinhg goes well then commit the transaction
            transaction.Commit();
            Console.WriteLine("Transaction Committed");
        }
        catch
        {
            // If anything goes wrong, rollback the transaction
            transaction.Rollback();
            Console.WriteLine("Transaction Rollback");
        }
    }
}

void VerifyingDataConsistencyWithTransaction()
{
    try
    {
        Console.WriteLine("Before Transaction");
        ReadOrderRecords();
        OrdersUpdateGoneWrong();
        Console.WriteLine("After Transaction");
        ReadOrderRecords();
    }
    catch (Exception e)
    {
        Console.WriteLine("OOPs, something went wrong" + e.Message);
    }
    Console.ReadKey();
}

void OrdersUpdateGoneWrong()
{
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        // The connection needs to be open before we begin a transaction
        connection.Open();
        // Create the transaction object by calling the BeginTransaction method on connection object
        SqlTransaction transaction = connection.BeginTransaction();
        try
        {
            // Associate the first update command with the transaction
            SqlCommand cmd = new SqlCommand("UPDATE Orders SET Description = 'Hello there' WHERE OrderNumber = 25", connection, transaction);
            cmd.ExecuteNonQuery();
            // Associate the second update command with the transaction
            cmd = new SqlCommand("UPDATE MyOrders SET Description = 'Ah General Kenobi' WHERE OrderNumber = 26", connection, transaction);
            cmd.ExecuteNonQuery();
            // If everythinhg goes well then commit the transaction
            transaction.Commit();
            Console.WriteLine("Transaction Committed");
        }
        catch
        {
            // If anything goes wrong, rollback the transaction
            transaction.Rollback();
            Console.WriteLine("Transaction Rollback");
        }
    }
}

void UpdateDataSourceWithAdapter()
{
    try
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter(
                "SELECT Id, Name FROM Customers",
                connection);
            
            dataAdapter.UpdateCommand = new SqlCommand(
                "UPDATE Customers SET Name = @Name " +
                "WHERE Id = @Id", connection);

            dataAdapter.UpdateCommand.Parameters.Add(
                "@Name", SqlDbType.Text, 100, "Name");

            SqlParameter parameter = dataAdapter.UpdateCommand.Parameters.Add(
                "@Id", SqlDbType.Int);

            parameter.SourceColumn = "Id";
            parameter.SourceVersion = DataRowVersion.Original;

            DataTable customerTable = new DataTable();
            dataAdapter.Fill(customerTable);

            DataRow customerRow = customerTable.Rows[0];
            customerRow["Name"] = "Joren Vandekerckhove";

            dataAdapter.Update(customerTable);

            Console.WriteLine("Rows after update.");
            foreach (DataRow row in customerTable.Rows)
            {
                {
                    Console.WriteLine("{0}: {1}", row[0], row[1]);
                }
            }
        }
    }
    catch (Exception e)
    {
        Console.WriteLine("OOPs, something went wrong.\n" + e);
    }
    Console.ReadKey();
}

void InsertInDataSourceWithAdapter()
{
    try
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter(
                "SELECT Name, Age FROM Customers",
                connection);

            var insertString = @"Insert into Customers ([Name],[Age])
                values (@Name,@Age)";
            SqlCommand insertCommand = new SqlCommand(insertString, connection);
            insertCommand.Parameters.Add("@Name", SqlDbType.Text, 100, "Name");
            insertCommand.Parameters.Add("@Age", SqlDbType.Int, 10, "Age");

            dataAdapter.InsertCommand = insertCommand;

            DataTable customerTable = new DataTable();
            dataAdapter.Fill(customerTable);

            DataRow customerRow = customerTable.NewRow();
            customerRow["Name"] = "General Kenobi";
            customerRow["Age"] = "40";
            customerTable.Rows.Add(customerRow);

            dataAdapter.Update(customerTable);

            Console.WriteLine("Rows after update.");
            foreach (DataRow row in customerTable.Rows)
            {
                {
                    Console.WriteLine("{0}: {1}", row[0], row[1]);
                }
            }
        }
    }
    catch (Exception e)
    {
        Console.WriteLine("OOPs, something went wrong.\n" + e);
    }
    Console.ReadKey();
}

void RemoveFromDataSourceWithAdapter()
{
    try
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter(
                "SELECT Name, Age FROM Customers",
                connection);

            var deleteString = @"DELETE FROM Customers WHERE Name=@Name";
            SqlCommand deleteCommand = new SqlCommand(deleteString, connection);
            deleteCommand.Parameters.Add("@Name", SqlDbType.NVarChar, 200, "Name");

            dataAdapter.DeleteCommand = deleteCommand;

            DataTable customerTable = new DataTable();
            dataAdapter.Fill(customerTable);

            //customerTable.Rows[0].Delete();
            //customerTable.RejectChanges();

            var foundRow = customerTable
                .AsEnumerable()
                .ToList()
                .FirstOrDefault(r => r["Name"].ToString() == "General Kenobi");
            foundRow?.Delete();

            dataAdapter.Update(customerTable);

            Console.WriteLine("Rows after update.");
            foreach (DataRow row in customerTable.Rows)
            {
                {
                    Console.WriteLine("{0}: {1}", row[0], row[1]);
                }
            }
        }
    }
    catch (Exception e)
    {
        Console.WriteLine("OOPs, something went wrong.\n" + e);
    }
    Console.ReadKey();
}