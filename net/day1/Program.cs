List<string> inputLines = File.ReadAllText("input.txt").Split("\n").ToList();

Dial dial = new Dial(50, 99);
int dialPointerAtZeroCounter = 0;
int dialPointerClickedAtZeroCounter = 0;

foreach (string line in inputLines)
{
    DialDirection direction = line[0] == 'L' ? DialDirection.Left : DialDirection.Right;
    for (int i = 0; i < Int32.Parse(line[1..]); i++)
    {
        dial.MoveDial(direction);
        if (dial.DialPosition == 0) dialPointerClickedAtZeroCounter += 1;
    }
    if (dial.DialPosition == 0) dialPointerAtZeroCounter += 1;
}

Console.WriteLine($"Day1 Part1 result: {dialPointerAtZeroCounter}");
Console.WriteLine($"Day1 Part2 result: {dialPointerClickedAtZeroCounter}");
