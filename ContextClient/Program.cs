using ContextClient;
using Entities;
using Microsoft.EntityFrameworkCore;
using Bogus;

string conStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HobbyDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

// CreateDataBase();
// CreateData(); 
LinqTest();

void LinqTest()
{
    DbContextOptionsBuilder bld = new DbContextOptionsBuilder();
    bld.UseSqlServer(conStr);
    // bld.LogTo(m => System.Console.WriteLine(m));
    HobbyContext context = new HobbyContext(bld.Options);

    IQueryable<Entities.Person> query = context.People;
    // query = query.Skip(100).Take(10);
    // query = query.OrderBy(p => p.FirstName);
    // query = query.Where(p => p.LastName!.StartsWith("A"));

    var query2 = query.Select(p => new { p.FirstName, p.LastName });

    var query3 = context.People
        .OrderBy(p => p.FirstName)
        .Where(p => p.LastName!.StartsWith("A"))
        .Select(p => new { p.FirstName, p.LastName });

    var query4 = from p in context.People
        orderby p.FirstName
        where p.LastName!.StartsWith("A")
        select new { p.FirstName, p.LastName };

    // foreach(var p in query3) {
    //     System.Console.WriteLine($"{p.FirstName} {p.LastName}");
    // }

    // foreach(Entities.Person p in query) {
    //     System.Console.WriteLine($"[{p.Id}] {p.FirstName} {p.LastName} ({p.Age})");
    // }

    var query5 = context.People
        .Include(p => p.Hobbies)
            .ThenInclude(ph => ph.Hobby)
        .Take(10);

    foreach(Entities.Person p in query5) {
        System.Console.WriteLine($"[{p.Id}] {p.FirstName} {p.LastName} ({p.Age})");

        foreach(var ph in p.Hobbies) {
            System.Console.WriteLine($"\t{ph?.Hobby?.Description}");
        }
    }
}

void CreateData()
{
    DbContextOptionsBuilder bld = new DbContextOptionsBuilder();
    bld.UseSqlServer(conStr);
    HobbyContext context = new HobbyContext(bld.Options);

    // Hobby h1 = new Hobby { Description = "Zeilen" };
    // Hobby h2 = new Hobby { Description = "Sigarenbandjes" };
    // Hobby h3 = new Hobby { Description = "Kapok plukken" };

    // context.Hobbies.AddRange(h1, h2, h3);
    // context.SaveChanges();

    var hobbies = context.Hobbies.ToList();
    // foreach(var hobby in hobbies) {
    //     System.Console.WriteLine(hobby.Description);
    // }

    var fakes = new Faker<Entities.Person>();
    fakes.RuleFor(p => p.FirstName, fk => fk.Name.FirstName());
    fakes.RuleFor(p => p.LastName, fk => fk.Name.LastName());
    fakes.RuleFor(p => p.Age, fk => fk.Random.Int(0, 123));
    var people = fakes.Generate(1000).ToList();

    var rnd = new Random();

    people.ForEach(p => {
        var ph = new PersonHobby {
            Person = p,
            Hobby = hobbies[rnd.Next(0, hobbies.Count)],
        };

        p.Hobbies.Add(ph);
    });

    context.AddRange(people);
    context.SaveChanges();

    System.Console.WriteLine("Gelukt!");
}

void CreateDataBase()
{
    DbContextOptionsBuilder bld = new DbContextOptionsBuilder();
    bld.UseSqlServer(conStr);
    HobbyContext context = new HobbyContext(bld.Options);

    context.Database.EnsureCreated();
    System.Console.WriteLine("Gelukt!");
}
