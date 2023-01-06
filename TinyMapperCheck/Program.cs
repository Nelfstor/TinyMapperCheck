using Nelibur.ObjectMapper;

public class MyClass
{
    public DateTimeOffset SomeDate { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}

public class MyClassDto
{
    public string Name { get; set; }
    public int Age { get; set; }
    public DateTime SomeDate { get; set; }
}


class Program
{
    static async Task Main(string[] args)
    {
        var obj1 = new MyClass()
        {
            Age = 1,
            Name = "Tom",
            SomeDate = DateTime.Now
        };

        TinyMapper.Bind<MyClass, MyClassDto>(config =>
        {
            //  config.Ignore(x => x.SomeDate);
            config.Bind(s => s.SomeDate.ToLocalTime().DateTime, t => t.SomeDate);
        }
        );

        var myClassDto = TinyMapper.Map<MyClassDto>(obj1);
        //   myClassDto.SomeDate = obj1.SomeDate.DateTime;

        Console.WriteLine(myClassDto.Name);
        Console.ReadKey();

    }
}