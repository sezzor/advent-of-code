string input = File.ReadAllText("input.txt");
string marker = "";

for (int i = 0; i < input.Count() - 14; i++)
{
    string sequence = input.Substring(i, 14);
    int uniqueLetters = 0;
    foreach (var letter in sequence)
    {
        if (sequence.Count(l => l == letter) == 1)
            uniqueLetters++;

    }
    if (uniqueLetters == 14)
    {
        marker = sequence;
        Console.WriteLine(marker);
        break;
    }
}
int pos = input.IndexOf(marker) + 14;
Console.WriteLine(pos);
