string[] inputLines = File.ReadAllText("input.txt").Split('\n');

bool processing = false;
int cycle = 1;
int register = 1;
int nextVal = 0;
int listIndex = 0;
int sum = 0;

while (inputLines.Length > listIndex || processing == true)
{
    switch (cycle)
    {
        case 20:
            sum += (cycle * register);
            break;
        case 60:
            sum += (cycle * register);
            break;
        case 100:
            sum += (cycle * register);
            break;
        case 140:
            sum += (cycle * register);
            break;
        case 180:
            sum += (cycle * register);
            break;
        case 220:
            sum += (cycle * register);
            break;
    }

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

System.Console.WriteLine(sum);

