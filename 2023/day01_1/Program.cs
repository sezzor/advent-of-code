string text = File.ReadAllText("input.txt");
string[] textArray = text.Split('\n');
List<int> calibrationValues = new();

foreach (var line in textArray)
{
    string stringNum = line.First(n => char.IsNumber(n)).ToString() + line.Last(n => char.IsNumber(n)).ToString();
    calibrationValues.Add(int.Parse(stringNum));
}

Console.WriteLine(calibrationValues.Sum());
