StreamReader reader = new StreamReader("..//..//..//data.txt");
//PartOne();
PartTwo();

void PartOne()
{
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
    List<string> cards = new List<string>();
    List<string> newCards = new List<string>();

    int offset = 0;

    while (!reader.EndOfStream)
    {
        string line = reader.ReadLine();
        cards.Add(line);
    }

    int count = cards.Count();

    while (true)
    {
        bool cardsAdded = false;

        for (int i = offset; i < cards.Count; i++)
        {
            List<int> winNums = new List<int>();
            List<int> myNums = new List<int>();

            string win = cards[i].Substring(cards[i].IndexOf(':') + 2, cards[i].IndexOf("|") - cards[i].IndexOf(':') - 2);
            string my = cards[i].Substring(cards[i].IndexOf("|") + 2);

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

            //Finding Original Card
            int orig = cards.IndexOf(cards[i]);
            Console.WriteLine(orig);

            for (int j = 1; j <= matching; j++)
                if (orig + j < count)
                {
                    newCards.Add(cards[i + j]);
                    cardsAdded = true;
                }   
                else
                    break;
        }
        
        if (cardsAdded)
        {
            offset = cards.Count;
            foreach (var item in newCards)
                cards.Add(item);
            newCards.Clear();
        }
        else
        {
            foreach (var item in cards)
                Console.WriteLine(item);
            Console.WriteLine($"PartTwo: {cards.Count+1}");
            break;
        }
    }
}

int getCardValue(int matching)
{
    if (matching == 0)
        return 0;

    return Convert.ToInt32(Math.Pow(2, matching - 1));
}
