namespace AdventOfCode_2022;
class Program
{
    static void Main(string[] args)
    {
        string text = File.ReadAllText("input.txt");
        string[] textArray = text.Split('\n');

        List<int> sums = new List<int> { };
        int sum = 0;
        foreach (var row in textArray)
        {
            if (string.IsNullOrWhiteSpace(row))
            {
                sums.Add(sum);
                sum = 0;
            }
            else
            {
                int outval = 0;
                bool parsed = int.TryParse(row, out outval);
                if (parsed) sum += outval;
                else throw new Exception("Error oh no!");
            }
        }
        Console.WriteLine("Part 1: " + sums.Max());
        sums = sums.OrderByDescending(x => x).ToList();
        Console.WriteLine("Part 2: " + (sums[0] + sums[1] + sums[2]));
    }
}
