namespace AdventOfCode_2022;
class Program
{
    static void Main(string[] args)
    {
        string text = File.ReadAllText("input.txt");
        // System.Console.WriteLine(text);
        string[] textArray = text.Split('\n');

        // int[] sums = { };
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
        System.Console.WriteLine(sums.Max());
        sums = sums.OrderByDescending(x => x).ToList();
        System.Console.WriteLine(sums[0] + sums[1] + sums[2]);

        // foreach (var val in sums)
        // {
        //     System.Console.WriteLine($"{val}");
        // }

    }
}
