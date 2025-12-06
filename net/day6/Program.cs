List<string> GetNumbersAsRightToLeftColumns(List<string> numbers)
{
    List<string> result = Enumerable.Repeat("", numbers.Count).ToList();

    for (int i = 0; i < numbers.Count; i++)
    {
        for (int j = 0; j < numbers[i].Length; j++)
        {
            result[j] = $"{result[j]}{numbers[i][j]}";
        }
    }
    for (int i = 0; i < result.Count; i++) result[i] = result[i].Replace(" ", "");
    
    result = result.Where(x => x != "").ToList();

    return result;
}

List<string> inputLines = File.ReadAllText("input.txt").Split("\n").ToList();

# region PREPARING_INPUT
Dictionary<string, List<string>> mathOperations = new Dictionary<string, List<string>>();
List<string> mathOperationKeys = [];
for (int i = inputLines.Count-1; i >= 0; i--)
{
    // creating entries with keys first => known amount of entries
    if (i == inputLines.Count - 1)
    {
        for (int j = 0; j < inputLines[i].Length; j++)
        {
            if (inputLines[i][j] == ' ') continue;
            mathOperationKeys.Add($"{j}{inputLines[i][j]}");
            mathOperations.Add($"{j}{inputLines[i][j]}", new List<string>());
        }
    }
    else
    {
        for (int j = 0; j < mathOperationKeys.Count; j++)
        {
            string operationKey = mathOperationKeys[j];
            int numberStartIndex = Int32.Parse(operationKey[..(operationKey.Length - 1)]);
            
            string resultingNumber;
            if (j == mathOperationKeys.Count - 1) resultingNumber = inputLines[i][numberStartIndex..];
            else
            {
                string nextOperationKey = mathOperationKeys[j+1];
                int numberEndIndex = Int32.Parse(nextOperationKey[..(nextOperationKey.Length - 1)]);
                resultingNumber = inputLines[i][numberStartIndex..(numberEndIndex-1)];
            }
            mathOperations[operationKey].Add(resultingNumber);
        }
    }
}
#endregion

long part1Result = 0;
long part2Result = 0;
foreach (KeyValuePair<string, List<string>> operation in mathOperations)
{
    operation.Value.Reverse();
    
    List<string> part1Numbers = operation.Value;
    List<string> part2Numbers = GetNumbersAsRightToLeftColumns(operation.Value);
    
    long part1OperationResult = 0;
    long part2OperationResult = 0;
    for (int i = 0; i < part1Numbers.Count; i++)
    {
        switch (operation.Key[(operation.Key.Length - 1)..])
        {
            case "+":
                part1OperationResult += Int32.Parse(part1Numbers[i]);
                if (i < part2Numbers.Count) part2OperationResult += Int32.Parse(part2Numbers[i]);
                break;
            case "*":
                if (part1OperationResult == 0)
                {
                    part1OperationResult = 1;
                    part2OperationResult = 1;
                }
                part1OperationResult *= Int32.Parse(part1Numbers[i]);
                if (i < part2Numbers.Count) part2OperationResult *= Int32.Parse(part2Numbers[i]);
                break;
        }
    }
    part1Result += part1OperationResult;
    part2Result += part2OperationResult;
}

Console.WriteLine($"Day6 Part1 result: {part1Result}");
Console.WriteLine($"Day6 Part2 result: {part2Result}");
