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

int bestScore = 0;
for (int row = 0; row < array2D.GetLength(0); row++)
{
    for (int col = 0; col < array2D.GetLength(1); col++)
    {
        int score = ScenicScoreCalc(row, col);
        if (score > bestScore) bestScore = score;
    }
}
System.Console.WriteLine(bestScore);

// Trees to check
////////////////////////////////////////////////////////////////////////////////////////
// Check visibility for tree

int ScenicScoreCalc(int row, int column)
{
    int height = array2D[row, column];
    int visAbove = 0;
    int visBelow = 0;
    int visLeft = 0;
    int visRight = 0;

    // Above //////////////////
    int above = row;
    int lastH = 0;
    while (above > 0)
    {
        above--;
        if (CanSeeNextTree(array2D[above, column], height, lastH))
        {
            visAbove++;
            lastH = array2D[above, column];
        }
    }

    // Below //////////////////
    int below = row;
    lastH = 0;
    while (below < array2D.GetLength(0) - 1)
    {
        below++;
        if (CanSeeNextTree(array2D[below, column], height, lastH))
        {
            visBelow++;
            lastH = array2D[below, column];
        }
    }

    // Left //////////////////
    int left = column;
    lastH = 0;
    while (left > 0)
    {
        left--;
        if (CanSeeNextTree(array2D[row, left], height, lastH))
        {
            visLeft++;
            lastH = array2D[row, left];
        }
    }

    // Right //////////////////
    int right = column;
    lastH = 0;
    while (right < array2D.GetLength(1) - 1)
    {
        right++;
        if (CanSeeNextTree(array2D[row, right], height, lastH))
        {
            visRight++;
            lastH = array2D[row, right];
        }
    }

    return (visAbove * visRight * visBelow * visLeft);

    bool CanSeeNextTree(int tree, int maxH, int lastH)
    {
        // STUPID!!!
        if (lastH < maxH) return true;
        else return false;

        // if (lastH == 0 && tree >= lastH) return true;
        // else if (lastH < maxH && tree >= lastH) return true;
        // else return false;

        // FÖRRA lägre än MAXH
        // &&
        // TRÄD högre eller samma som FÖRRA
    }
}