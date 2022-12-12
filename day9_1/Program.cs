string[] inputLines = File.ReadAllText("input.txt").Split('\n');
int[,] array2D = new int[2000, 2000];

int headRow = 1000;
int headCol = 1000;
int tailRow = 1000;
int tailCol = 1000;
array2D[tailRow, tailCol] = 1; // Tail starting pos.
int sqaresTochedByTail = 1;

////////////////////////////////////////////////////////////////////////////////////////

foreach (var move in inputLines)
{
    string direction = move.Split(" ")[0];
    int steps = int.Parse(move.Split(" ")[1]);

    for (int i = 0; i < steps; i++)
    {
        Move(direction, 1);
    }
}

////////////////////////////////////////////////////////////////////////////////////////

void Move(string direction, int steps)
{
    // Move head
    if (direction == "U") headRow -= steps;
    else if (direction == "D") headRow += steps;
    else if (direction == "L") headCol -= steps;
    else if (direction == "R") headCol += steps;

    // Move tail
    if (!TailTouchingHead())
    {
        if (direction == "U")
        {
            tailCol = headCol;
            tailRow = headRow + 1;
        }
        else if (direction == "D")
        {
            tailCol = headCol;
            tailRow = headRow - 1;
        }
        else if (direction == "L")
        {
            tailCol = headCol + 1;
            tailRow = headRow;
        }
        else if (direction == "R")
        {
            tailCol = headCol - 1;
            tailRow = headRow;
        }
    }

    // Update square if tale has been there
    UpdateSquares();
}
System.Console.WriteLine(sqaresTochedByTail);

////////////////////////////////////////////////////////////////////////////////////////

bool TailTouchingHead()
{
    int latitude = Math.Abs(headRow - tailRow);
    int longditude = Math.Abs(headCol - tailCol);
    if (longditude > 1 || latitude > 1) return false;
    else return true;
}

void UpdateSquares()
{
    if (array2D[tailRow, tailCol] == 1) return;
    else
    {
        array2D[tailRow, tailCol] = 1;
        sqaresTochedByTail += 1;
    }
}