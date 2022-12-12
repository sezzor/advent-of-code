// string text = File.ReadAllText("input.txt");
// string[] textArray = text.Split('\n');
// int sum = 0;

// foreach (var row in textArray)
// {
//     int beforeMid = row.Length / 2;
//     string left = row.Substring(0, beforeMid);
//     string right = row.Substring(beforeMid, row.Length - beforeMid);

//     char duplicate = FindDuplicate(left, right);

//     if (char.IsUpper(duplicate)) sum += (int)duplicate - 38;
//     else sum += (int)duplicate - 96;
// }
// // System.Console.WriteLine((int)'a' - 96);
// // System.Console.WriteLine((int)'z' - 96);
// // System.Console.WriteLine((int)'A' - 38);
// // System.Console.WriteLine((int)'Z' - 38);
// System.Console.WriteLine(sum);

// char FindDuplicate(string left, string right)
// {
//     char? duplicate = null;
//     foreach (var letter in left)
//     {
//         bool isThisIt = right.Contains(letter);
//         if (isThisIt)
//         {
//             duplicate = letter;
//             break;
//         }
//     }
//     // wtf
//     if (duplicate != null) return (char)duplicate;
//     else return ' ';
// }



/////////////////////////////////////////////////////
// Part Two
/////////////////////////////////////////////////////

string text = File.ReadAllText("input.txt");
string[] textArray = text.Split('\n');
List<string> teamList = new List<string> { };
int sum = 0;

string threeRows = "";
for (int i = 1; i < textArray.Length + 1; i++)
{
    if (i % 3 == 0)
    {
        threeRows += textArray[i - 1];
        teamList.Add(threeRows);
        threeRows = "";
    }
    else
    {
        threeRows += textArray[i - 1] + " ";
    }
}

foreach (var team in teamList)
{
    char badge = ' ';
    string[] backpacks = team.Split(" ");

    foreach (var letter in backpacks[0])
    {
        int b1 = backpacks[0].Count(l => l == letter);
        int b2 = backpacks[1].Count(l => l == letter);
        int b3 = backpacks[2].Count(l => l == letter);
        if (b1 > 0 && b2 > 0 && b3 > 0)
        {
            badge = letter;
            break;
        }
    }
    if (char.IsUpper(badge)) sum += (int)badge - 38;
    else sum += (int)badge - 96;
}
System.Console.WriteLine(sum);