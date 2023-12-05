
//PartOne();
PartTwo();

void PartOne()
{
    StreamReader reader = new StreamReader("..//..//..//data.txt");

    int sum = 0;

    List<int> winNums = new List<int>();
    List<int> myNums = new List<int>();

    while (!reader.EndOfStream)
    {
        string line = reader.ReadLine();
        line = line.Remove(0, line.IndexOf(':') + 2);

        string win = line.Substring(0, line.IndexOf("|"));
        string my = line.Substring(line.IndexOf("|") + 2);

        string[] tokens = win.Split(' ');
        tokens = tokens.Where(s => !string.IsNullOrEmpty(s)).ToArray();

        foreach (string token in tokens)
            winNums.Add(int.Parse(token));

        tokens = my.Split(' ');
        tokens = tokens.Where(s => !string.IsNullOrEmpty(s)).ToArray();

        foreach (string token in tokens)
            myNums.Add(int.Parse(token));

        int matching = 0;

        foreach (var winning in winNums)
            foreach (var num in myNums)
                if (num == winning) matching++;

        winNums.Clear();
        myNums.Clear();

        sum += getCardValue(matching);
    }
    reader.Close();
    Console.WriteLine($"PartOne: {sum}");
}

void PartTwo()
{
    StreamReader reader = new StreamReader("..//..//..//data.txt");

    List<string> cards = new List<string>();

    int offset = 0;
    while (!reader.EndOfStream)
    {
        cards.Add(reader.ReadLine());
    }

    int[] cardCount = new int[cards.Count];
    for (int i = 0; i < cardCount.Length; i++)
    {
        cardCount[i] = 1;
    }

    for (int cardId = 0; cardId < cardCount.Length; cardId++)
    {
        string? line = cards[cardId];
        var parts = line.Split(':');
        var numbers = parts[1].Split('|');
        var pickedNumbers = numbers[0]
            .Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
            .Select(int.Parse)
            .ToArray();
        var ourNumbers = numbers[1]
            .Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
            .Select(int.Parse)
            .ToArray();

        var matchCount = pickedNumbers.Intersect(ourNumbers).Count();

        for (int i = 0; i < matchCount; i++)
        {
            cardCount[cardId + 1 + i] += cardCount[cardId];
        }
    }

    Console.WriteLine($"PartTwo: {cardCount.Sum()}");
}

int getCardValue(int matching)
{
    if (matching == 0)
        return 0;

    return Convert.ToInt32(Math.Pow(2, matching - 1));
}