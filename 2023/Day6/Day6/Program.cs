using static System.Net.Mime.MediaTypeNames;
using System.Text.RegularExpressions;

StreamReader reader = new StreamReader("..//..//..//data.txt");

//PartOne();
PartTwo();

void PartOne()
{
    var line = reader.ReadLine();
    line = line.Remove(0, line.IndexOf(':') + 1);

    var duration = line.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
            .Select(int.Parse)
            .ToArray();

    line = reader.ReadLine();
    line = line.Remove(0, line.IndexOf(':') + 1);

    var record = line.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
            .Select(int.Parse)
            .ToArray();

    int sum = 1;

    for (int i = 0; i < duration.Length; i++)
    {
        int count = 0;
        for (int hold = 1; hold < duration[i]; hold++)
        {
            if (hold * (duration[i] - hold) > record[i])
                count++;
        }

        if (count > 0)
            sum = sum * count;
    }

    Console.WriteLine($"PartOne: {sum}");
}

void PartTwo()
{
    var line = reader.ReadLine();
    line = line.Remove(0, line.IndexOf(':') + 1);

    var duration = int.Parse(String.Concat(line.Where(c => !Char.IsWhiteSpace(c))));

    line = reader.ReadLine();
    line = line.Remove(0, line.IndexOf(':') + 1);

    var record = Convert.ToInt64(String.Concat(line.Where(c => !Char.IsWhiteSpace(c))));

    int sum = 0;

    for (System.Int64 hold = 1; hold < duration; hold++)
    {
        if (hold * (duration - hold) > record)
            sum++;
    }


    Console.WriteLine($"PartOne: {sum}");
}