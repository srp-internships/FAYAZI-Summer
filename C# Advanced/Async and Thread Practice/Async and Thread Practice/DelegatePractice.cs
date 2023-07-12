namespace Async_and_Thread_Practice
{
    public class DelegatePractice
    {
        // Delegate declarations
        public delegate float Operation(float a, float b);

        delegate void Print(string message);

        // Methods for Print delegate
        static void Meth1(string message) => Console.WriteLine($"Method 1: {message}");
        static void Meth2(string message) => Console.WriteLine($"Method 2: {message}");
        static void Meth3(string message) => Console.WriteLine($"Method 3: {message}");

        // Methods for Operation delegate
        static float Multiply(float a, float b) => a * b;
        public float Add(float a, float b) => a + b;

        public DelegatePractice()
        {
            RunPrinter();
            RunOperation();
        }
        public void RunPrinter()
        {
            Print printer = Meth1;
            printer += Meth2;
            printer += Meth3;

            printer("foobar");
        }

        public void RunOperation()
        {
            Operation operation = Multiply; //equivalent to => Operation operation1 = new Operation(Multiply); 
            operation += Add;

            Console.WriteLine(operation(3,6));
        }
    }  
}
