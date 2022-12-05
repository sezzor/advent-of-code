string text = File.ReadAllText("input.txt");
string[] textArray = text.Split('\n');

List<List<string>> stacks = new List<List<string>>();
stacks.Add(new List<string> { "T", "P", "Z", "C", "S", "L", "Q", "N" });
stacks.Add(new List<string> { "L", "P", "T", "V", "H", "C", "G" });
stacks.Add(new List<string> { "D", "C", "Z", "F" });
stacks.Add(new List<string> { "G", "W", "T", "D", "L", "M", "V", "C" });
stacks.Add(new List<string> { "P", "W", "C" });
stacks.Add(new List<string> { "P", "F", "J", "D", "C", "T", "S", "Z" });
stacks.Add(new List<string> { "V", "W", "G", "B", "D" });
stacks.Add(new List<string> { "N", "J", "S", "Q", "H", "W" });
stacks.Add(new List<string> { "R", "C", "Q", "F", "S", "L", "V" });

foreach (var task in textArray)
{
    string[] split = task.Split(" ");
    int moves = int.Parse(split[1]);
    int fromStack = int.Parse(split[3]);
    int toStack = int.Parse(split[5]);

    List<string> items = stacks[fromStack - 1].TakeLast(moves).ToList();
    stacks[fromStack - 1].RemoveRange(stacks[fromStack - 1].Count() - moves, moves);

    foreach (var item in items)
    {
        stacks[toStack - 1].Add(item);
    }
}

for (int i = 1; i <= 9; i++)
{
    Console.Write($"{stacks[i - 1][stacks[i - 1].Count() - 1]}");
}
Console.WriteLine("\n123456789");