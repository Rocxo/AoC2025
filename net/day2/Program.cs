List<string> idRanges = File.ReadAllText("input.txt").Split(",").ToList();

List<string> FindRepeatedIDs(string idRange, bool part1 = false)
{
    List<string> result = [];
    if (idRange[0] == '0') return result;

    string[] startAndEndOfRange = idRange.Split("-");
    string id = startAndEndOfRange[0];
    while (long.Parse(id) <= long.Parse(startAndEndOfRange[1]))
    {
        int moduloAt = 2;
        int moduloLimit = part1 ? 2 : id.Length;
        while (moduloAt <= moduloLimit)
        {
            if (id.Length % moduloAt == 0)
            {
                int partSize = id.Length / moduloAt;
                List<string> parts = [];
                for (int i = 0; i < id.Length / partSize; i++)
                {
                    parts = [.. parts, String.Concat(id.Skip(i * partSize).Take(partSize))];
                }
                if (!parts.Any(x => x != parts[0]))
                {
                    result = [.. result, id];
                    break;
                }
            }
            moduloAt += 1;
        }
        id = (long.Parse(id) + 1).ToString();
    }
    return result;
}

List<string> repeatedIDs = [];
long part1Result = 0;
long part2Result = 0;
foreach (string range in idRanges)
{
    List<string> Part1FoundRepeatedIDsForRange = FindRepeatedIDs(range, part1: true);
    foreach (string id in Part1FoundRepeatedIDsForRange)
    {
        part1Result += long.Parse(id);
    }

    List<string> Part2FoundRepeatedIDsForRange = FindRepeatedIDs(range, part1: false);
    foreach (string id in Part2FoundRepeatedIDsForRange)
    {
        part2Result += long.Parse(id);
    }
}

Console.WriteLine($"Day2 Part1 result: {part1Result}");
Console.WriteLine($"Day2 Part1 result: {part2Result}");