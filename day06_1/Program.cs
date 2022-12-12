string input = File.ReadAllText("input.txt");
string marker = "";

for (int i = 0; i < input.Count() - 4; i++)
{
    string sequence = input.Substring(i, 4);
    int uniqueLetters = 0;
    foreach (var letter in sequence)
    {
        if (sequence.Count(l => l == letter) == 1)
            uniqueLetters++;

    }
    if (uniqueLetters == 4)
    {
        marker = sequence;
        Console.WriteLine(marker);
        break;
    }
}
int pos = input.IndexOf(marker) + 4;
Console.WriteLine(pos);
