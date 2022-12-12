string[] inputLines = File.ReadAllText("input.txt").Split('\n');
int[,] array2D = new int[inputLines[0].Count(), inputLines.Count()];
for (int r = 0; r < inputLines.Count(); r++)
{
    // Row
    string row = inputLines[r];
    for (int c = 0; c < row.Count(); c++)
    {
        // Column
        array2D[r, c] = (int)row[c] - '0';
    }
}

// Build 2D martix
////////////////////////////////////////////////////////////////////////////////////////
// Trees to check

int visisbleTrees = 0;
for (int row = 0; row < array2D.GetLength(0); row++)
{
    for (int col = 0; col < array2D.GetLength(1); col++)
    {
        if (IsVisible(row, col)) visisbleTrees++;
    }
}
System.Console.WriteLine(visisbleTrees);

// Trees to check
////////////////////////////////////////////////////////////////////////////////////////
// Check visibility for tree

bool IsVisible(int row, int column)
{
    int height = array2D[row, column];
    bool hiddenAbove = false;
    bool hiddenBelow = false;
    bool hiddenLeft = false;
    bool hiddenRight = false;

    // Above //////////////////
    int above = row;
    while (above > 0)
    {
        above--;
        if (array2D[above, column] >= height)
        {
            hiddenAbove = true;
            above = 0;
        }
    }
    if (!hiddenAbove) return true;

    // Below //////////////////
    int below = row;
    while (below < array2D.GetLength(0) - 1)
    {
        below++;
        if (array2D[below, column] >= height)
        {
            hiddenBelow = true;
            below = array2D.GetLength(0) - 1;
        }
    }
    if (!hiddenBelow) return true;

    // Left //////////////////
    int left = column;
    while (left > 0)
    {
        left--;
        if (array2D[row, left] >= height)
        {
            hiddenLeft = true;
            left = 0;
        }
    }
    if (!hiddenLeft) return true;

    // Right //////////////////
    int right = column;
    while (right < array2D.GetLength(1) - 1)
    {
        right++;
        if (array2D[row, right] >= height)
        {
            hiddenRight = true;
            right = array2D.GetLength(1) - 1;
        }
    }
    if (!hiddenRight) return true;
    else return false;
}