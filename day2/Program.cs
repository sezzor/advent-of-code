// See https://aka.ms/new-console-template for more information
using System;

string text = File.ReadAllText("input.txt");
string[] textArray = text.Split('\n');

List<int> roundScores = new List<int> { };

// Need to win: Z
// Need to lose: X 
// Need draw: Y
char rockMe = 'X';
char paperMe = 'Y';
char scissorsMe = 'Z';

char rockOp = 'A';
char paperOp = 'B';
char scissorsOp = 'C';

int totalScore = 0;
foreach (var str in textArray)
{
    char opponent = str[0];
    // char me = str[2];
    char whatToDo = str[2];
    char me = 'A';

    // Win
    if (whatToDo == 'Z')
    {
        if (opponent == rockOp) me = paperMe;
        else if (opponent == paperOp) me = scissorsMe;
        else if (opponent == scissorsOp) me = rockMe;
    }
    // Lose
    else if (whatToDo == 'X')
    {
        if (opponent == rockOp) me = scissorsMe;
        else if (opponent == paperOp) me = rockMe;
        else if (opponent == scissorsOp) me = paperMe;
    }
    // Draw
    else
    {
        if (opponent == rockOp) me = rockMe;
        else if (opponent == paperOp) me = paperMe;
        else if (opponent == scissorsOp) me = scissorsMe;
    }

    totalScore += Score(opponent, me);
}
System.Console.WriteLine(totalScore);

//
// Win = 6
// Draw = 3
// Loss = 0
//
// Rock = A/Y = 1
// Paper = B/Z = 2
// Scissors = C/X = 3
//

int Score(char opponent, char me)
{
    char rockMe = 'X';
    char paperMe = 'Y';
    char scissorsMe = 'Z';

    char rockOp = 'A';
    char paperOp = 'B';
    char scissorsOp = 'C';

    int score = 0;
    // Shape sccore
    switch (me)
    {
        case 'X': score += 1; break;
        case 'Y': score += 2; break;
        default: score += 3; break;
    }
    // Win
    if (me == rockMe && opponent == scissorsOp) score += 6;
    else if (me == paperMe && opponent == rockOp) score += 6;
    else if (me == scissorsMe && opponent == paperOp) score += 6;
    // Loss
    else if (me == rockMe && opponent == paperOp) score += 0;
    else if (me == paperMe && opponent == scissorsOp) score += 0;
    else if (me == scissorsMe && opponent == rockOp) score += 0;
    // Draw
    else score += 3;

    return score;
}