using System.Text;

List<string> inputLines = File.ReadAllText("input.txt").Split("\n").ToList();

(int, List<string>) GetRemovablePaperRollAmount(List<string> paperRollGrid)
{
    //creating padding
    for (int i = 0; i < paperRollGrid.Count; i++) paperRollGrid[i] = $".{paperRollGrid[i]}.";
    paperRollGrid.Insert(0, new string('.', paperRollGrid[0].Length));
    paperRollGrid.Insert(paperRollGrid.Count, new string('.', paperRollGrid[0].Length));

    int removablePaperRollCount = 0;
    List<string> paperRollGridAfterRemoval = [];
    for (int y = 1; y < paperRollGrid.Count-1; y++)
    {
        StringBuilder tempLine = new(paperRollGrid[y]);
        for (int x = 1; x < paperRollGrid[y].Length-1; x++)
        {
            if (paperRollGrid[y][x] == '.') continue;

            int paperRollCount = 0;
            if (paperRollGrid[y-1][x-1] == '@') paperRollCount++;
            if (paperRollGrid[y-1][x] == '@') paperRollCount++;
            if (paperRollGrid[y-1][x+1] == '@') paperRollCount++;
            if (paperRollGrid[y][x-1] == '@') paperRollCount++;
            if (paperRollGrid[y][x+1] == '@') paperRollCount++;
            if (paperRollGrid[y+1][x-1] == '@') paperRollCount++;
            if (paperRollGrid[y+1][x] == '@') paperRollCount++;
            if (paperRollGrid[y+1][x+1] == '@') paperRollCount++;

            if (paperRollCount < 4)
            {
                removablePaperRollCount++;
                tempLine[x] = '.';
            }
        }
        paperRollGridAfterRemoval.Add(tempLine.ToString()[1..(tempLine.Length-1)]);
    }

    return (removablePaperRollCount, paperRollGridAfterRemoval);
}

(int part1Result, List<string> removalIteration) = GetRemovablePaperRollAmount(inputLines);
int part2Result = part1Result;
int removalAmount = -1;
while (removalAmount != 0)
{
    (removalAmount, removalIteration) = GetRemovablePaperRollAmount(removalIteration);
    part2Result += removalAmount;
}

Console.WriteLine($"Day4 Part1 result: {part1Result}");
Console.WriteLine($"Day4 Part2 result: {part2Result}");
