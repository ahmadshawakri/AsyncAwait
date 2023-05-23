namespace AsyncProcessing
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            List<string> items = new List<string>()
            {
                "item#1",
                "item#2",
                "item#3",
                "item#4",
                "item#5",
                "item#6",
                "item#7",
            };

            List<Task<string>> tasks = items
                .Select(item => Task.Run(() => ProcessItemAsync(item)))
                .ToList();

            await Task.WhenAll(tasks);

            foreach (var task in tasks)
            {
                Console.WriteLine(task.Result);
            }

            Console.ReadKey();
        }

        public static async Task<string> ProcessItemAsync(string item)
        {
            char charToRemove = '#';
            int charToRemoveIndex = item.IndexOf(charToRemove);
            string processedItem = $"{item.Remove(charToRemoveIndex, 1)} Processed";

            await Task.Delay(1000);

            return processedItem;
        }
    }
}
