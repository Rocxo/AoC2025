List<long[]> FixOverlappingRanges(List<long[]> ranges)
{
    ranges = ranges.OrderBy(range => range[0]).ToList();
    List<long[]> fixedRanges = [];
    fixedRanges.Add(new long[]{ranges[0][0], ranges[0][1]});
    foreach (long[] range in ranges)
    {
        foreach (long[] fixedRange in fixedRanges)
        {
            if (range[0] >= fixedRange[0] && range[0] <= fixedRange[1]) range[0] = fixedRange[1]+1;
        }
        if (range[0] <= range[1]) fixedRanges.Add(new long[]{range[0], range[1]});
    }
    return fixedRanges;
}

List<string> inputLines = File.ReadAllText("input.txt").Split("\n").ToList();

// splitting input
bool pastRanges = false;
List<long[]> ingredientRanges = [];
List<long> ingredientIDs = [];

foreach (string line in inputLines)
{
    if (line == "")
    {
        pastRanges = true;
        continue;
    }
    
    if (pastRanges) ingredientIDs.Add(long.Parse(line));
    else
    {
        string[] splittedLine = line.Split("-");
        ingredientRanges.Add(new long[]{long.Parse(splittedLine[0]), long.Parse(splittedLine[1])});
    }
}
ingredientRanges = FixOverlappingRanges(ingredientRanges);

int part1Result = 0;
foreach (long ingredientId in ingredientIDs)
{
    foreach (long[] ingredientRange in ingredientRanges)
    {
        if (ingredientId >= ingredientRange[0] && ingredientId <= ingredientRange[1])
        {
            part1Result++;
            break;
        }
    }
}

long part2Result = 0;
foreach (long[] range in ingredientRanges)
{
    part2Result += range[1] - range[0] + 1;
}

Console.WriteLine($"Day5 Part1 result: {part1Result}");
Console.WriteLine($"Day5 Part2 result: {part2Result}");



