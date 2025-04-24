// 1. Simple Hello World in Console
Console.WriteLine("Hello, World!\n");


// 2. Example #1 with local function
string Hello(string name) => $"Hello, {name}!\n";
Console.WriteLine(Hello("Samir"));


// 3. For and foreach loops
for (int i = 0; i < 5; i++) Console.Write($"For:{i} ");
Console.WriteLine("\n");
foreach (var i in Enumerable.Range(0, 5)) Console.Write($"Foreach:{i} ");
Console.WriteLine("\n");


//4. While and do while loops
int j = 0;
while (j < 5) Console.Write($"While:{j++} ");
Console.WriteLine("\n");
int k = 0;
do Console.Write($"Do:{k++} "); while (k < 5);
Console.WriteLine("\n");


//5. Tuples
var (a, b) = (51, 50);
Console.WriteLine($"{a + b}\n");


//6. Ranges and Indexes
var numbers = Enumerable.Range(1, 10).ToArray();
Console.WriteLine("Slice 3..8: " + string.Join(", ", numbers[2..^2]));
Console.WriteLine($"Last item is: {numbers[^1]}\n");


//7. Switch expression with relational patterns
string Sign(int number) => number switch
{
    < 0 => "Negative",
    0 => "Zero",
    > 0 => "Positive"
};
Console.WriteLine($"Sign of {a - b}: {Sign(a - b)}\n");


//8. Null-conditional and null-coalescing operators
string? name = null;
Console.WriteLine($"{name?.ToUpper() ?? "<null>"}\n");


//9. Immutable record + 'with' clone
var person = new Person("Samir", 40);
var person2 = person with { Age = 41 };
Console.WriteLine($"Person 1: {person},  Person 2: {person2}\n");


//10. Property and logical patterns
var p1 = new Point(3, 4);
bool IsUnit(Point p) =>
    p is { X: var a, Y: var b }
    && Math.Abs(Math.Sqrt(a * a + b * b) - 1) < 0.01;
Console.WriteLine($"Is p1 unit? {IsUnit(p1)}\n");


//11. Local function and recursion
int Factorial(int n)
{
    if (n == 0) return 1;
    return n * Factorial(n - 1);
}
Console.WriteLine($"{Factorial(10)}\n");


//12. List patterns
var arr = Enumerable.Range(1, 6).ToArray();
if (arr is [1, 2, 3, .. var rest, 6])
    Console.WriteLine($"Matched head and tail, middle length: {rest.Length}\n");


//13. LINQ
var issues = new[]
{
    new Issue(1, "UI", Severity.Low, DateTime.Now.AddDays(-1)),
    new Issue(2, "Backend", Severity.Medium, DateTime.Now.AddDays(-2)),
    new Issue(3, "Database", Severity.High, DateTime.Now.AddDays(-3)),
    new Issue(4, "API", Severity.Critical, DateTime.Now.AddDays(-4)),
    new Issue(5, "UI", Severity.Low, DateTime.Now.AddDays(-5)),
    new Issue(6, "Backend", Severity.Medium, DateTime.Now.AddDays(-6)),
    new Issue(7, "Database", Severity.High, DateTime.Now.AddDays(-7)),
};

var dashboard = issues
    .GroupBy(i => i.Component)
    .Select(g => new
    {
        Name = g.Key,
        OpenCount = g.Count(),
        Worst = g.MinBy(i => i.Level)!.Level,
        AvgAge = g.Average(i => (DateTime.UtcNow - i.OpenedOn).TotalDays)
    })
    .OrderByDescending(g => g.OpenCount);

foreach (var row in dashboard)
    Console.WriteLine($"{row.Name,-8} | {row.OpenCount,2} open | worst: {row.Worst,-8} | avg age: {row.AvgAge:N1} d\n");


//14. OOP
Animal pet = new Dog { Name = "Buddy" };
pet.Speak();

pet = new Cat { Name = "Spike" };
pet.Speak();


//15. Generics
T Echo<T>(T input) => input;

Box<int> box = new Box<int>(42);
var number = box.Value;

Box<string> boxString = new Box<string>("Hi");
var text = boxString.Value;

Console.WriteLine($"{Echo<double>(3.14)}\n");


//16. Lambda Expressions
var even = Enumerable.Range(0, 100)
    .Where(i => i % 2 == 0)
    .ToArray();

foreach (var i in even)
    Console.Write($"{i} ");

Console.WriteLine("\n");


//17. Async Programming
async Task<int> GetDataAsync(string url)
{
    using HttpClient client = new HttpClient();
    var content = await client.GetStringAsync(url);
    return content.Length;
}
var length = await GetDataAsync("https://www.uol.com.br");
Console.WriteLine($"Downloaded page of length {length}\n");



//Records/Enum declaration
public record Person(string Name, int Age);
public record Point(int X, int Y);
public record Issue(int Id, string Component, Severity Level, DateTime OpenedOn);
public enum Severity { Low, Medium, High, Critical }


//Classes declaration
public abstract class Animal
{
    public string Name { get; set; }
    public abstract void Speak();
}
public class Dog : Animal
{
    public override void Speak() => Console.WriteLine("Woof!\n");
}
public class Cat : Animal
{
    public override void Speak() => Console.WriteLine("Meow!\n");
}

public class Box<T>
{
    public T Value { get; }
    public Box(T value) => Value = value;
}