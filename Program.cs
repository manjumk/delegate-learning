namespace DelegateLearning;
class Program
{
    delegate void HelloFunctionDelegate(string Message);
    static void Main(string[] args)
    {
        //simple
        HelloFunctionDelegate del = new HelloFunctionDelegate(Hello);
        del("from Delegate");

        // real wrod passing delegate as parameter'
        List<Employee> listEmployees = new List<Employee>()
        {
            new Employee() {Id=101,Name="mary",Salary=50000,Experince=5 },
            new Employee() {Id=102,Name="John",Salary=60000,Experince=7 }
        };

        IsPromotable isPromotable = new IsPromotable(promote);

        Employee.promoteEmpolyee(listEmployees, isPromotable);

        // using lamda without explicit creation of method and delegate 
        Employee.promoteEmpolyee(listEmployees, emp => emp.Name == "mary");

        //Mutlicast Deleagate
        HelloFunctionDelegate muldel = new HelloFunctionDelegate(sampleMethodOne);
        muldel += sampleMethodThree;
        muldel("Test1");

        // Generic Delegate
        
        Predicate<int> test = d => d > 5;
        Console.WriteLine($"predicate result: {test(7)}");

        Func<int,int,int,int> functest=(p,t,r)=> p* t *r;
        int si = functest(10, 20, 30);
        Console.WriteLine($"func result: {si}");

        Action<string> actiontest = d => Console.WriteLine($"Action result: {d}");
        actiontest("Hello action delegate");

    }

    public static void Hello(string message)
    {
        Console.WriteLine("Hello {0}", message);
    }

    public static bool promote(Employee emp)
    {
        return emp.Experince > 5;
    }

    public static void sampleMethodOne(string msg)
    {
        Console.WriteLine(msg);
    }

    public static void sampleMethodTwo(string msg)
    {
        Console.WriteLine(msg);
    }

    public static void sampleMethodThree(string msg)
    {
        Console.WriteLine(msg);
    }
}

delegate bool IsPromotable(Employee emp);
class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Salary { get; set; }
    public int Experince { get; set; }

    public static void promoteEmpolyee(List<Employee> empList, IsPromotable IsEligibleToPromote)
    {
        foreach (Employee emp in empList)
        {
            if (IsEligibleToPromote(emp))
            {
                Console.WriteLine($"{emp.Name}, Promoted");
            }
        }
    }
}
