// string text = File.ReadAllText("input.txt");
// string[] textArray = text.Split('\n');

// List<string> teamList = new List<string> { };
// int sum = 0;

// foreach (var pair in textArray)
// {
//     string[] elfs = pair.Split(",");

//     int e1Start = int.Parse(elfs[0].Split("-")[0]);
//     int e1End = int.Parse(elfs[0].Split("-")[1]);
//     int e2Start = int.Parse(elfs[1].Split("-")[0]);
//     int e2End = int.Parse(elfs[1].Split("-")[1]);

//     string inside = CompareRages(e1Start, e1End, e2Start, e2End);
//     if (inside == "r1 in r2")
//     {
//         sum += 1;
//     }
//     else if (inside == "r2 in r1")
//     {
//         sum += 1;
//     }
// }
// Console.WriteLine(sum);

// string CompareRages(int r1s, int r1e, int r2s, int r2e)
// {
//     if (r1s >= r2s && r1e <= r2e)
//         return "r1 in r2";
//     else if (r2s >= r1s && r2e <= r1e)
//         return "r2 in r1";
//     else
//         return "";
// }


/////////////////////////////////////////////////////
// Part Two
/////////////////////////////////////////////////////

string text = File.ReadAllText("input.txt");
string[] textArray = text.Split('\n');

List<string> teamList = new List<string> { };
int sum = 0;

foreach (var pair in textArray)
{
    string[] elfs = pair.Split(",");

    int e1Start = int.Parse(elfs[0].Split("-")[0]);
    int e1End = int.Parse(elfs[0].Split("-")[1]);
    int e2Start = int.Parse(elfs[1].Split("-")[0]);
    int e2End = int.Parse(elfs[1].Split("-")[1]);

    bool overlap = CompareRages(e1Start, e1End, e2Start, e2End);
    if (overlap) sum += 1;
}
Console.WriteLine(sum);

bool CompareRages(int r1s, int r1e, int r2s, int r2e)
{
    bool overlaps = false;
    List<int> elf1 = Enumerable.Range(r1s, r1e - r1s + 1).ToList();
    List<int> elf2 = Enumerable.Range(r2s, r2e - r2s + 1).ToList();

    foreach (var num in elf1)
    {
        int x = elf2.Count(n => n == num);
        if (x > 0)
        {
            overlaps = true;
            break;
        }
    }
    return overlaps;
}