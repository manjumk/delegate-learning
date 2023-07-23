Delegate are the function pointer. (More specific delegate are type safe function pointer, because the signature of the method should match to the delegate type).
Delegates are used to pass methods as arguments to other methods. Event handlers are nothing more than methods that are invoked through delegates.
     delegate void HelloFunctionDelegate(string Message);
     static void Main(string[] args)
     {
        HelloFunctionDelegate del = new HelloFunctionDelegate(Hello);
        del("from Delegate");      
     }

     public static void Hello(string message)
     {
        Console.WriteLine("Hello {0}",message);
     }
Multicast Delegate: Multicast delegate can be used to invoke the multiple methods. The delegate instance can do multicasting (adding new method on existing delegate instance) using the + operator and – operator can be used to remove a method from a delegate instance. All methods will invoke in sequence as they are assigned.  	

HelloFunctionDelegate muldel = new HelloFunctionDelegate(sampleMethodOne);
muldel += sampleMethodThree;
muldel("Test1");  

Multicast delegate makes implementation of observer design pattern.

Generic Delegate: Generic Delegate was introduced in .NET 3.5 that don't require to define the delegate instance in order to invoke the methods.
•	Predicate - The Predicate delegate defines a method that can be called on arguments and always returns Boolean type result.
     Predicate<int> test = d => d > 5;
     Console.WriteLine($"predicate result: {test(7)}");
•	Action - The Action delegate defines a method that can be called on arguments but does not return a result.
     Action<string> actiontest = d => Console.WriteLine($"result: {d}");
     actiontest("Hello action delegate");
•	Func - delegate defines a method that can be called on arguments and returns a result
     Func<int,int,int,int> functest=(p,t,r)=> p* t *r;
     int si = functest(10, 20, 30);
     Console.WriteLine($"func result: {si}");
