using day9_2;

string[] inputLines = File.ReadAllText("input.txt").Split('\n');
int[,] array2D = new int[2000, 2000];

Rope rope = new Rope(1000, 1000);
array2D[1000, 1000] = 1; // Tail starting pos.
int sqaresTochedByTail = 1;

////////////////////////////////////////////////////////////////////////////////////////

foreach (var move in inputLines)
{
    string direction = move.Split(" ")[0];
    int steps = int.Parse(move.Split(" ")[1]);

    for (int i = 0; i < steps; i++)
    {
        // System.Console.WriteLine("\nStep nr: " + direction + (i + 1));
        MoveHead(direction, 1);
        foreach (var knot in rope.Knots)
        {
            if (knot.Name != "head") MoveKnot(knot, knot.Nr - 1, direction);
            if (knot.Name == "last tail") UpdateSquare(knot);
        }
    }
}

Console.WriteLine(sqaresTochedByTail);

////////////////////////////////////////////////////////////////////////////////////////

void MoveHead(string direction, int steps)
{
    if (direction == "U") rope.Knots[0].Row -= steps;
    else if (direction == "D") rope.Knots[0].Row += steps;
    else if (direction == "L") rope.Knots[0].Col -= steps;
    else if (direction == "R") rope.Knots[0].Col += steps;
}

void MoveKnot(Knot knot, int parentNr, string direction)
{
    if (!TailTouchingHead(knot, parentNr))
    {
        int latitude = rope.Knots[parentNr].Row - knot.Row; // Verti. (över/under)
        int longditude = rope.Knots[parentNr].Col - knot.Col; // Horiz. (sida)

        // →
        if (longditude > 1 && latitude == 0) knot.Col += 1;
        // ←
        if (longditude < -1 && latitude == 0) knot.Col -= 1;
        // ↑
        if (latitude < -1 && longditude == 0) knot.Row -= 1;
        // ↓
        if (latitude > 1 && longditude == 0) knot.Row += 1;
        // ↗
        if ((latitude <= -1 && longditude >= 1))
        {
            knot.Row -= 1;
            knot.Col += 1;
        }
        // ↘
        if ((latitude >= 1 && longditude >= 1))
        {
            knot.Row += 1;
            knot.Col += 1;
        }
        // ↙ 
        if ((latitude >= 1 && longditude <= -1))
        {
            knot.Row += 1;
            knot.Col -= 1;
        }
        // ↖
        if ((latitude <= -1 && longditude <= -1))
        {
            knot.Row -= 1;
            knot.Col -= 1;
        }
    }
}

////////////////////////////////////////////////////////////////////////////////////////

bool TailTouchingHead(Knot knot, int parentNr)
{
    int latitude = Math.Abs(rope.Knots[parentNr].Row - knot.Row); // Verti. (över/under)
    int longditude = Math.Abs(rope.Knots[parentNr].Col - knot.Col); // Horiz. (sida)
    if (longditude > 1 || latitude > 1) return false;
    else return true;
}

void UpdateSquare(Knot knot)
{
    if (array2D[knot.Row, knot.Col] == 1) return;
    else
    {
        array2D[knot.Row, knot.Col] = 1;
        sqaresTochedByTail += 1;
    }
}