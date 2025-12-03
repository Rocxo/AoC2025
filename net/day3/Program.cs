List<string> inputLines = File.ReadAllText("input.txt").Split("\n").ToList();

string FindHighestJoltage(string bank, int length, string tempResult = "")
{
    // recursion ending cases
    if (length == 0) return tempResult;
    else if (bank.Length == length) return $"{tempResult}{bank}";

    string allowedBankRange = bank[..(bank.Length-(length-1))];
    int tempHighest = Int32.Parse(bank[0].ToString());
    int tempHighestIndex = 0;
    for (int i = 0; i < allowedBankRange.Length; i++)
    {
        int lookingAt = Int32.Parse(allowedBankRange[i].ToString());
        if (lookingAt > tempHighest)
        {
            tempHighest = lookingAt;
            tempHighestIndex = i;
        }
    }
    tempResult = $"{tempResult}{tempHighest}";
    return FindHighestJoltage(bank[(tempHighestIndex+1)..], length-1, tempResult);
}

long part1Result = 0;
long part2Result = 0;
foreach (string line in inputLines)
{
    part1Result += long.Parse(FindHighestJoltage(line, 2));
    part2Result += long.Parse(FindHighestJoltage(line, 12));
}
Console.WriteLine($"Day3 Part1 result: {part1Result}");
Console.WriteLine($"Day3 Part2 result: {part2Result}");