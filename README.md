# C# Single File Quick Start

This repository contains 17 concise examples demonstrating modern and foundational features of the C# programming language, all written in a single `Program.cs` file. It's an excellent quick reference for learners and professionals alike.

## Examples

### 1. Hello World
```csharp
Console.WriteLine("Hello, World!");
```
📚 [Docs: Hello World](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/tutorials/hello-world)

### 2. Local Function with Lambda Expression
```csharp
string Hello(string name) => $"Hello, {name}!";
Console.WriteLine(Hello("Samir"));
```
📚 [Docs: Local Functions](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/local-functions)

### 3. For and Foreach Loops
```csharp
for (int i = 0; i < 5; i++) Console.Write($"For:{i} ");

foreach (var i in Enumerable.Range(0, 5)) Console.Write($"Foreach:{i} ");
```
📚 [Docs: Iteration Statements](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/iteration-statements)

### 4. While and Do-While Loops
```csharp
int j = 0;
while (j < 5) Console.Write($"While:{j++} ");

int k = 0;
do Console.Write($"Do:{k++} "); while (k < 5);
```

### 5. Tuples
```csharp
var (a, b) = (51, 50);
Console.WriteLine($"{a + b}");
```
📚 [Docs: Tuples](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/value-tuples)

### 6. Ranges and Indexes
```csharp
var numbers = Enumerable.Range(1, 10).ToArray();
Console.WriteLine(string.Join(", ", numbers[2..^2]));
Console.WriteLine($"Last item is: {numbers[^1]}");
```
📚 [Docs: Ranges](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-8.0/ranges)

### 7. Switch Expression with Patterns
```csharp
string Sign(int number) => number switch
{
    < 0 => "Negative",
    0 => "Zero",
    > 0 => "Positive"
};
```
📚 [Docs: Pattern Matching](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/pattern-matching)

### 8. Null-Safe Operations
```csharp
string? name = null;
Console.WriteLine(name?.ToUpper() ?? "<null>");
```
📚 [Docs: Null-Conditional Operators](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/null-conditional-operators)

### 9. Records and With Expressions
```csharp
record Person(string Name, int Age);

var person = new Person("Samir", 40);
var person2 = person with { Age = 41 };
Console.WriteLine($"Person 1: {person},  Person 2: {person2}");
```
📚 [Docs: Records](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/record)

### 10. Property Pattern Matching
```csharp
public record Point(int X, int Y);
var p1 = new Point(3, 4);

bool IsUnit(Point p) =>
    p is { X: var a, Y: var b }
    && Math.Abs(Math.Sqrt(a * a + b * b) - 1) < 0.01;
Console.WriteLine($"Is p1 unit? {IsUnit(p1)}");
```
📚 [Docs: Property Patterns](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/patterns#property-pattern)

### 11. Local function and recursion
```csharp
int Factorial(int n)
{
    if (n == 0) return 1;
    return n * Factorial(n - 1);
}
Console.WriteLine($"{Factorial(10)}");
```
📚 [Docs: Recursive Functions](https://learn.microsoft.com/en-us/cpp/c-language/recursive-functions)

### 12. List Patterns
```csharp
var arr = Enumerable.Range(1, 6).ToArray();
if (arr is [1, 2, 3, .. var rest, 6])
    Console.WriteLine($"Matched head and tail, middle length: {rest.Length}");
```
📚 [Docs: List Patterns](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-11.0/list-patterns)

### 13. LINQ
```csharp
public record Issue(int Id, string Component, Severty Level, DateTime OpenedOn);
public enum Severity { Low, Medium, High, Critical }

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
    Console.WriteLine($"{row.Name,-8} | {row.OpenCount,2} open | worst: {row.Worst,-8} | avg age: {row.AvgAge:N1} d");
```
📚 [Docs: LINQ](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/)

### 14. OOP
```csharp
public abstract class Animal
{
    public string Name { get; set; }
    public abstract void Speak();
}
public class Dog : Animal
{
    public override void Speak() => Console.WriteLine("Woof!");
}
public class Cat : Animal
{
    public override void Speak() => Console.WriteLine("Meow!");
}

Animal pet = new Dog { Name = "Buddy" };
pet.Speak();

pet = new Cat { Name = "Spike" };
pet.Speak();
```
📚 [Docs: OOP](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/tutorials/oop)

### 15. Generics
```csharp
public class Box<T>
{
    public T Value { get; }
    public Box(T value) => Value = value;
}

Box<int> box = new Box<int>(42);
var number = box.Value;

Box<string> boxString = new Box<string>("Hi");
var text = boxString.Value;

T Echo<T>(T input) => input;
Console.WriteLine($"{Echo<double>(3.14)}");
```
📚 [Docs: Generics](https://learn.microsoft.com/en-us/dotnet/standard/generics/)

### 16. Lambda
```csharp
var even = Enumerable.Range(0, 100)
    .Where(i => i % 2 == 0)
    .ToArray();

foreach (var i in even)
    Console.Write($"{i} ");
```
📚 [Docs: Lambda Expressions](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/lambda-expressions)

### 17. Async Programming
```csharp
async Task<int> GetDataAsync(string url)
{
    using HttpClient client = new HttpClient();
    var content = await client.GetStringAsync(url);
    return content.Length;
}
var length = await GetDataAsync("https://www.uol.com.br");
Console.WriteLine($"Downloaded page of length {length}\n");
```
📚 [Docs: Async Programming](https://learn.microsoft.com/en-us/dotnet/csharp/asynchronous-programming/)

---

## 📁 Repository

Explore the full project on GitHub:  
[github.com/samir-mourad/c-sharp-single-file-quick-start](https://github.com/samir-mourad/c-sharp-single-file-quick-start)