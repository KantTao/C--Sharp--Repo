namespace SynchronousAndAsynchronous;

class Program
{
    static async Task Main(string[] args)
    {
        //await asyncExample();
        // DemoOne();
       // await DemoTwo();
       await DemoFour();
    }

    public static async Task asyncExample()
    {
        //Task.Run(...) throw the task  into the thread pool and continue next step (if not await)
        Task task = Task.Run(async () =>
        {
            await Task.Delay(3000); // wait 3 seconds  for async but no stuck system
            Console.WriteLine("Task1 is running");
        });
        
        await task; //waiting the task finished 
        Console.WriteLine("Main is running");
        Console.ReadLine();
    }

    public static async Task DemoOne()
    {
        Task task = new Task(() => { Console.WriteLine("Task1 is running"); });
        task.Start();
        Console.WriteLine("Task2 is running");

        //The order of task1 and task2 are unpredictable
        //Result-1: Task1 is running  Task2 is running
        //Result-2: Task2 is running  Task3 is running
        //reason:     task.Start() will add task into thread-pool and compel the next code.
        //we do not know which one will be finished firstly 
    }
    
    public static async Task DemoTwo()// Concurrency and thread scheduling
    {
        Task task = new Task(() => { Console.WriteLine("Task1 is running"); });
        task.Start();
        await task;
        Console.WriteLine("Task2 is running");

        //The result is predictable : Task1 is running , Task2 is running  
        //reason:task.Start() will add task into thread-pool , task.Wait() will wait result of  task.Start() until got result 
        //then go next code (  Console.WriteLine("Task2 is running") )
    }
    
    public static async Task DemoThree()// Concurrency and thread scheduling
    {
        Task task1 = new Task(() => { Console.WriteLine("Task1 is running"); });
        Task task2 = new Task(() => { Console.WriteLine("Task2 is running"); });
        task1.Start();
        task2.Start();
         
        //The order of task1 and task2 are unpredictable 
        //reason:task1.Start() and  task2.Start() will add into thread-pool 
        //But we cant know which thread will precess it rapidly (probably:  task1 or task2) 
        //like order  hungry panda. depend on restaurant and deliver man.
    }
    
    
    public static async Task DemoFour()// Concurrency and thread scheduling
    {
        //Task.Run(...) throw the task  into the thread pool and continue next step (if not await)
        Task task1 = Task.Run(async () =>
        {
            await Task.Delay(3000); // wait 3 seconds  for async but no block system
            Console.WriteLine("Task1 is running");
        });
        
        Task task2 = Task.Run(async () =>
        {
            Console.WriteLine("Task2 is running");
        });
        
        await Task.WhenAll(task1, task2);
        
        //The order of task1 and task2 are predictable 
        //Result: "Task2 is running"  after 3 seconds : Task1 is running
        //Task1 is running" will be delayed but current thread will not be blocked , it will compel next code (Task2)
        
    }
    
}