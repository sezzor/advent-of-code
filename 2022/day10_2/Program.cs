string[] inputLines = File.ReadAllText("input.txt").Split('\n');

bool processing = false;
int cycle = 1;
int register = 1;
int nextVal = 0;
int listIndex = 0;
int crtRow = 0;

while (inputLines.Length > listIndex || processing == true)
{
    if (crtRow % 40 == 0)
    {
        Console.WriteLine(); //new row
        crtRow = 0;
    }
    if (register <= crtRow + 1 && register >= crtRow - 1) Console.Write("#");
    else Console.Write(".");
    crtRow++;

    if (processing == true)
    {
        processing = false;
        register += nextVal;
    }
    else if (inputLines.Length > listIndex)
    {
        string line = inputLines[listIndex];
        listIndex++;
        if (line != "noop")
        {
            nextVal = int.Parse(line.Split(" ")[1]);
            processing = true;
        }
    }
    cycle++; // Cycle finished
}
Console.WriteLine();
