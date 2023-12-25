namespace swTask7
{
    class Program
    {
        static void Main()
        {
            try
            {
                Console.WriteLine(cntSolutions.CntSolutions(1, 1, 1));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Задача создана");
                BuildTask.Task(BuildTask.httpClient);
            }

        }
    }
}