namespace Async_and_Thread_Practice
{
    public class TaskPractice
    {
        public List<string> prods;
        public TaskPractice()
        {
            prods = new List<string>
            {
                "hi",
                "hello",
                "foo",
                "bar",
                "lol",
                "kuu"
            };
        }
        public static void Example1()
        {
            Task task1 = new Task(() => Console.WriteLine("Task1 is executed"));
            task1.Start();

            Task task2 = Task.Factory.StartNew(() => Console.WriteLine("Task2 is executed"));

            Task task3 = Task.Run(() => Console.WriteLine("Task3 is executed"));

            task1.Wait();
            task2.Wait();
            task3.Wait();
        }

        public static void Example2()
        {
            Task task1 = new Task(() =>
            {
                Console.WriteLine("Task starts");
                Thread.Sleep(1000);
                Console.WriteLine("Task ends");
            });
            task1.Start();
            task1.Wait();
        }


        public async Task WriteSingleAsync(List<string> slice, int id)
        {
            await File.WriteAllTextAsync($"foo-{id}.txt", string.Join("\n", slice));
        }


        public async Task WriteToFiles(int records)
        {
            int cnt = (prods.Count / records);
            int start = 0;

            for (int i = 1; i <= cnt; i++)
            {
                if (records >= prods.Count)
                {
                    await WriteSingleAsync(prods, i);
                }
                else
                {
                    var slice = prods.GetRange(start, records);
                    start += records;
                    await WriteSingleAsync(slice, i);
                }
            }

            int rem = prods.Count % records;
            if (rem != 0)
            {
                await WriteSingleAsync(prods.TakeLast(rem).ToList(), cnt + 1);
            }
        }


    }
}
