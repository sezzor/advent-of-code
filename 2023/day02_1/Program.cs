string text = File.ReadAllText("input.txt");
string[] textArray = text.Split('\n');
List<int> calibrationValues = new();
string[] numberNames = {
    "one",
    "two",
    "three",
    "four",
    "five",
    "six",
    "seven",
    "eight",
    "nine"
};

int nameToNum(string numName) => numName switch
{
    "one" => 1,
    "two" => 2,
    "three" => 3,
    "four" => 4,
    "five" => 5,
    "six" => 6,
    "seven" => 7,
    "eight" => 8,
    "nine" => 9,
    _ => 0
};

int index = 1;
foreach (var line in textArray)
{
    int firstWordPosition = int.MaxValue;
    string firstWordPositionName = "";
    int lastWordPosition = int.MinValue;
    string lastWordPositionName = "";
    foreach (var numName in numberNames)
    {
        if (line.Contains(numName))
        {
            var fistPos = line.IndexOf(numName);
            var lastPos = line.LastIndexOf(numName);
            if (fistPos < firstWordPosition)
            {
                firstWordPosition = fistPos;
                firstWordPositionName = numName;
            }
            if (lastPos > lastWordPosition)
            {
                lastWordPosition = lastPos;
                lastWordPositionName = numName;
            }
        }
    }

    int firstNumberPosition = line.IndexOf(line.FirstOrDefault(char.IsNumber));
    int lastNumberPosition = line.LastIndexOf(line.LastOrDefault(char.IsNumber));

    int first;
    int last;

    if (firstNumberPosition == -1 || firstWordPosition < firstNumberPosition)
        first = nameToNum(firstWordPositionName);
    else
        first = int.Parse(line[firstNumberPosition].ToString());

    if (lastNumberPosition == -1 || lastWordPosition > lastNumberPosition)
        last = nameToNum(lastWordPositionName);
    else
        last = int.Parse(line[lastNumberPosition].ToString());

    calibrationValues.Add(int.Parse(first + "" + last));

    Console.WriteLine(index + ": " + int.Parse(first + "" + last));
    index++;
}

Console.WriteLine(calibrationValues.Sum());
