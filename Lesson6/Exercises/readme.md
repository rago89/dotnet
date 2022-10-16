# Exercises lesson 5

## SQL part

## Exercise 1
Create a database with the name 'RestaurantDb'

## Exercise 2
Create a table with the name 'Customers'.<br>
This table contains the next columns:
- Id (int)
- Name (varchar)
- Age (int)

## Exercise 3
Add 3 customers to the table 'Customers'.
You can choose their names and ages.

## Exercise 4
Change the table Customers where the next things changes:
- Id is a primary key
- Auto increment on Id is active
- Name is now of the type TEXT

Hint: Drop the id column first, than create the new changes

## Exercise 5
Create a table 'Orders'.<br>
This table contains next colums:
- Id (int)
- OrderNumber (int)
- Description (varchar(200))
- CustomerId (int)

Id here is a primary key and has also an auto increment.<br>
CustomerId is a foreign key to the column Id of the table Customers.

## ADO.NET part

## Exercise 1
Read the records of both tables with the use of the 'SqlDataReader' class.<br>
Show them in the console.

## Exercise 2
Insert a record in the customers table and in the orders table.

## Exercise 3
Remove a record from both tables.

## Exercise 4
Get the data of both tables with the use of the class SqlDataAdapter.<br>
Show the records in the console.

## Exercise 5
Get the data of the table customers, and update the name of one customer.<br>
Use then the SqlDataAdapter class to update the database.

## LINQ part

## Exercise 1
Get the data of the table Persons, and show all persons with a specifc name.<br>
Create a method of that where you give a name as parameter.

## Exercise 2
Get the data of the tables Persons and orders, and show if someone has ordered anything.

## Exercise 3
Get the data of the tables Persons and orders, and show all the persons who have ordered something.

## Questions? Ask right away!
