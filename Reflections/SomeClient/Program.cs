
// using SomeLib;

// Person p = new Person { Name = "Kees", Age = 52 };
// p.Introduce();

using System.Reflection;

Assembly asm = Assembly.LoadFrom(@"E:\Projects\Reflections\SomeLib.dll");
System.Console.WriteLine(asm.FullName);

Type? type = asm.GetType("SomeLib.Person");

dynamic? p1 = Activator.CreateInstance(type!);
if (p1 != null) {
    p1.Name = "Marieke";
    p1.Age = 23;
    p1.Introduce(); 
}


object? p = Activator.CreateInstance(type!);

PropertyInfo? nameProp = type!.GetProperty("Name");
nameProp!.SetValue(p, "Kees");

PropertyInfo? ageProp = type!.GetProperty("Age");
ageProp!.SetValue(p, 50);

FieldInfo? ageField = type!.GetField("age", BindingFlags.NonPublic | BindingFlags.Instance);
ageField!.SetValue(p, 500);

MethodInfo? intro = type!.GetMethod("Introduce");
intro!.Invoke(p, new object[] { });


foreach (TypeInfo tp in asm.GetTypes())
{
    // System.Console.WriteLine(tp.FullName);

    foreach (MemberInfo mi in tp.GetMembers(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public))
    {
        // System.Console.WriteLine($"\t({mi.MemberType}) {mi.Name}");
    }
}

System.Console.WriteLine("ok");