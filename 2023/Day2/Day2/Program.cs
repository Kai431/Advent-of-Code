PartOne();
PartTwo();
void PartOne()
{
    var reader = new StreamReader("..//..//..//data.txt");

    int sum = 0;

    int red = 0;
    int green = 0;
    int blue = 0;

    const int rMax = 12;
    const int gMax = 13;
    const int bMax = 14;

    while (!reader.EndOfStream)
    {
        string line = reader.ReadLine();
        var tokens = line.Split(':');
        var id = string.Concat(tokens[0].Where(Char.IsDigit));

        var content = tokens[1];
        var subsets = content.Split(";");
        for (int i = 0; i < subsets.Length; i++)
        {
            if (subsets[i].Contains(','))
            {
                var cube = subsets[i].Split(",");
                for (int j = 0; j < cube.Length; j++)
                {
                    int number = int.Parse(string.Concat(cube[j].Where(Char.IsDigit)));
                    string color = string.Concat(cube[j].Where(Char.IsLetter));
                    
                    switch (color)
                    {
                        case "red":
                            if(red < number)
                                red = number;
                            break;
                        case "green":
                            if (green < number)
                                green = number;
                            break;
                        case "blue":
                            if (blue < number)
                                blue = number;
                            break;
                    }
                }
            }
            else
            {
                var cube = subsets[i];
                int number = int.Parse(string.Concat(cube.Where(Char.IsDigit)));
                string color = string.Concat(cube.Where(Char.IsLetter));

                switch (color)
                {
                    case "red":
                        if (red < number)
                            red = number;
                        break;
                    case "green":
                        if (green < number)
                            green = number;
                        break;
                    case "blue":
                        if (blue < number)
                            blue = number;
                        break;
                }
            }
        }

        if (red <= rMax && green <= gMax && blue <= bMax)
            sum += int.Parse(id);

        red = 0;
        green = 0;
        blue = 0;
    }

    Console.WriteLine($"PartOne:{sum}");
}

void PartTwo()
{
    var reader = new StreamReader("..//..//..//data.txt");

    int sum = 0;

    int red = 0;
    int green = 0;
    int blue = 0;

    const int rMax = 12;
    const int gMax = 13;
    const int bMax = 14;

    while (!reader.EndOfStream)
    {
        string line = reader.ReadLine();
        var tokens = line.Split(':');
        var id = string.Concat(tokens[0].Where(Char.IsDigit));

        var content = tokens[1];
        var subsets = content.Split(";");
        for (int i = 0; i < subsets.Length; i++)
        {
            if (subsets[i].Contains(','))
            {
                var cube = subsets[i].Split(",");
                for (int j = 0; j < cube.Length; j++)
                {
                    int number = int.Parse(string.Concat(cube[j].Where(Char.IsDigit)));
                    string color = string.Concat(cube[j].Where(Char.IsLetter));

                    switch (color)
                    {
                        case "red":
                            if (red < number)
                                red = number;
                            break;
                        case "green":
                            if (green < number)
                                green = number;
                            break;
                        case "blue":
                            if (blue < number)
                                blue = number;
                            break;
                    }
                }
            }
            else
            {
                var cube = subsets[i];
                int number = int.Parse(string.Concat(cube.Where(Char.IsDigit)));
                string color = string.Concat(cube.Where(Char.IsLetter));

                switch (color)
                {
                    case "red":
                        if (red < number)
                            red = number;
                        break;
                    case "green":
                        if (green < number)
                            green = number;
                        break;
                    case "blue":
                        if (blue < number)
                            blue = number;
                        break;
                }
            }
        }

        int power = red * green * blue;
        sum += power;

        red = 0;
        green = 0;
        blue = 0;
    }

    Console.WriteLine($"PartTwo:{sum}");
}