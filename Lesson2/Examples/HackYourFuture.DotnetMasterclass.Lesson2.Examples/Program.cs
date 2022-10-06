// Array = fixed length list of things
var fibonacci = new int[5];
fibonacci[0] = 1;
fibonacci[1] = 1;
fibonacci[2] = 2;
fibonacci[3] = 3;
fibonacci[4] = 5;

var number5 = fibonacci[4];

for (int i = 0; i < fibonacci.Length; i++)
{
    var currentNumber = fibonacci[i];
    Console.WriteLine(currentNumber);
}

// We can also define 2-dimensional arrays
var coordinates = new int[3, 4];

coordinates[0, 0] = 7;

// throws exception
// coordinates[3, 3] = 8;  

// Linked lists (collections of unknown length)
var fibonacci2 = new List<int>(); // empty list

fibonacci2.Add(1);
fibonacci2.Add(1);
fibonacci2.Add(2);
fibonacci2.Add(3);
fibonacci2.Add(5);
fibonacci2.Add(7);

// Usually we don't need to get elements by index
var element5 = fibonacci2.ElementAt(5);

// Usually we use a foreach
foreach (var fibonacciNumber in fibonacci2)
{
    Console.WriteLine(fibonacciNumber);
}

// Dictionary - map keys to values
Dictionary<string, int> ages = new();

// Write a value for a certain key
ages["Hannes"] = 40;
ages["Stijn"] = 25;
ages["Joren"] = 26;

// Keys are unique, values are overwritten
ages["Stijn"] = 26;

var ageOfStijn = ages["Stijn"]; // 25

foreach (var name in ages.Keys)
{
    var age = ages[name];
    Console.WriteLine($"{name} is {age} years old.");
}
