using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Metrics;
using System.Text;


//PartOne();
PartTwo();

void PartOne()
{
    StreamReader reader = new StreamReader("..//..//..//data.txt");

    List<string> lines = new List<string>();
    List<string> nums = new List<string>();

    while (!reader.EndOfStream)
    {
        lines.Add(reader.ReadLine());
    }

    reader.Close();

    for (int row = 0; row < lines.Count; row++)
    {
        string line = lines[row];
        for (int col = 0; col < line.Length; col++)
        {
            if (!Char.IsDigit(line[col]) && line[col] != '.') //Checking for Symbol
            {
                //Checking all nine Positions
                int counter = 0;
                if (row != 0)//Line above
                {
                    string above = lines[row - 1];
                    for (int i = 0; i < 3; i++)
                    {
                        int pos = 0;
                        if (col != 0)
                            pos = i - 1;

                        if (col - pos < above.Length && char.IsDigit(above[col - pos])) //Number above Symbol
                        {
                            counter = 0;
                            nums.Add(Convert.ToString(above[col - pos]));

                            StringBuilder aboveBuilder = new StringBuilder(above);  //Replacing Chars so the Number doesnt get counted double
                            aboveBuilder[col - pos] = '.';
                            above = aboveBuilder.ToString();

                            if (col - pos == 0)
                                counter--;

                            while (true) //Check Number left side
                            {
                                counter++;

                                if (Char.IsDigit(above[col - pos - counter]))
                                {
                                    nums[nums.Count - 1] = nums[nums.Count - 1].Insert(0, Convert.ToString(above[col - pos - counter]));
                                    aboveBuilder[col - pos - counter] = '.';
                                    above = aboveBuilder.ToString();
                                }
                                else
                                    break;

                                if (col - pos - counter == 0)
                                    break;
                            }

                            counter = 0;

                            while (true) //Check Number right side
                            {
                                counter++;

                                if (col - pos + counter == above.Length)
                                    break;

                                if (Char.IsDigit(above[col - pos + counter]))
                                {
                                    nums[nums.Count - 1] += above[col - pos + counter];
                                    aboveBuilder[col - pos + counter] = '.';
                                    above = aboveBuilder.ToString();
                                }
                                else
                                    break;


                            }
                        }
                    }
                    lines[row - 1] = above; //Replacing main line
                }

                //Left side
                StringBuilder builder = new StringBuilder(line);  //Replacing Chars so the Number doesnt get counted double
                counter = 1;
                if (col - counter > -1)
                {
                    if (Char.IsDigit(line[col - counter]))
                    {
                        nums.Add(Convert.ToString(line[col - counter]));
                        builder[col - counter] = '.';
                        line = builder.ToString();
                        lines[row] = line;
                        while (true) //Check Number left side
                        {
                            counter++;

                            if (Char.IsDigit(line[col - counter]))
                            {
                                nums[nums.Count - 1] = nums[nums.Count - 1].Insert(0, Convert.ToString(line[col - counter]));
                                builder[col - counter] = '.';
                                line = builder.ToString();
                                lines[row] = line;
                            }
                            else
                                break;

                            if (col - counter == 0)
                                break;
                        }
                    }
                }


                //Right side
                counter = 1;
                if (col + counter != line.Length)
                {
                    if (Char.IsDigit(line[col + counter]))
                    {
                        nums.Add(Convert.ToString(line[col + counter]));
                        builder[col + counter] = '.';
                        line = builder.ToString();
                        lines[row] = line;
                        while (true) //Check Number left side
                        {
                            counter++;

                            if (col + counter < line.Length && Char.IsDigit(line[col + counter]))
                            {
                                nums[nums.Count - 1] += line[col + counter];
                                builder[col + counter] = '.';
                                line = builder.ToString();
                                lines[row] = line;
                            }
                            else
                                break;
                        }
                    }
                }

                counter = 0;

                if (row != lines.Count - 1)//Line below
                {
                    builder = new StringBuilder(lines[row + 1]);
                    string below = lines[row + 1];
                    for (int i = 0; i < 3; i++)
                    {
                        int pos = 0;
                        if (col != 0)
                            pos = i - 1;

                        if (col - pos < below.Length && char.IsDigit(below[col - pos])) //Number below Symbol
                        {
                            counter = 0;
                            nums.Add(Convert.ToString(below[col - pos]));

                            builder[col - pos] = '.';
                            below = builder.ToString();

                            while (true) //Check Number left side
                            {
                                counter++;

                                if (col - pos - counter == -1)
                                    break;

                                if (Char.IsDigit(below[col - pos - counter]))
                                {
                                    nums[nums.Count - 1] = nums[nums.Count - 1].Insert(0, Convert.ToString(below[col - pos - counter]));
                                    builder[col - pos - counter] = '.';
                                    below = builder.ToString();
                                }
                                else
                                    break;

                            }

                            counter = 0;

                            while (true) //Check Number right side
                            {
                                counter++;

                                if (col - pos + counter >= below.Length)
                                    break;

                                if (Char.IsDigit(below[col - pos + counter]))
                                {
                                    nums[nums.Count - 1] += below[col - pos + counter];
                                    builder[col - pos + counter] = '.';
                                    below = builder.ToString();
                                }
                                else
                                    break;

                            }
                        }
                    }
                    lines[row + 1] = below; //Replacing main line
                }

            }
        }
    }

    int sum = 0;
    foreach (var num in nums)
    {
        sum += int.Parse(num);
        Console.WriteLine(num);
    }

    foreach (var line in lines)
        Console.WriteLine(line);

    Console.WriteLine($"PartOne: {sum}");

}


void PartTwo()
{
    StreamReader reader = new StreamReader("..//..//..//data.txt");

    List<string> lines = new List<string>();
    List<string> nums = new List<string>();
    int sum = 0;

    while (!reader.EndOfStream)
    {
        lines.Add(reader.ReadLine());
    }

    reader.Close();

    for (int row = 0; row < lines.Count; row++)
    {
        string line = lines[row];
        for (int col = 0; col < line.Length; col++)
        {
            if (line[col] == '*') //Checking for Symbol
            {
                //Checking all nine Positions
                int counter = 0;
                if (row != 0)//Line above
                {
                    string above = lines[row - 1];
                    for (int i = 0; i < 3; i++)
                    {
                        int pos = 0;
                        if (col != 0)
                            pos = i - 1;

                        if (col - pos < above.Length && char.IsDigit(above[col - pos])) //Number above Symbol
                        {
                            counter = 0;
                            nums.Add(Convert.ToString(above[col - pos]));

                            StringBuilder aboveBuilder = new StringBuilder(above);  //Replacing Chars so the Number doesnt get counted double
                            aboveBuilder[col - pos] = '.';
                            above = aboveBuilder.ToString();

                            if (col - pos == 0)
                                counter--;

                            while (true) //Check Number left side
                            {
                                counter++;

                                if (Char.IsDigit(above[col - pos - counter]))
                                {
                                    nums[nums.Count - 1] = nums[nums.Count - 1].Insert(0, Convert.ToString(above[col - pos - counter]));
                                    aboveBuilder[col - pos - counter] = '.';
                                    above = aboveBuilder.ToString();
                                }
                                else
                                    break;

                                if (col - pos - counter == 0)
                                    break;
                            }

                            counter = 0;

                            while (true) //Check Number right side
                            {
                                counter++;

                                if (col - pos + counter == above.Length)
                                    break;

                                if (Char.IsDigit(above[col - pos + counter]))
                                {
                                    nums[nums.Count - 1] += above[col - pos + counter];
                                    aboveBuilder[col - pos + counter] = '.';
                                    above = aboveBuilder.ToString();
                                }
                                else
                                    break;


                            }
                        }
                    }
                    lines[row - 1] = above; //Replacing main line
                }

                //Left side
                StringBuilder builder = new StringBuilder(line);  //Replacing Chars so the Number doesnt get counted double
                counter = 1;
                if (col - counter > -1)
                {
                    if (Char.IsDigit(line[col - counter]))
                    {
                        nums.Add(Convert.ToString(line[col - counter]));
                        builder[col - counter] = '.';
                        line = builder.ToString();
                        lines[row] = line;
                        while (true) //Check Number left side
                        {
                            counter++;

                            if (Char.IsDigit(line[col - counter]))
                            {
                                nums[nums.Count - 1] = nums[nums.Count - 1].Insert(0, Convert.ToString(line[col - counter]));
                                builder[col - counter] = '.';
                                line = builder.ToString();
                                lines[row] = line;
                            }
                            else
                                break;

                            if (col - counter == 0)
                                break;
                        }
                    }
                }


                //Right side
                counter = 1;
                if (col + counter != line.Length)
                {
                    if (Char.IsDigit(line[col + counter]))
                    {
                        nums.Add(Convert.ToString(line[col + counter]));
                        builder[col + counter] = '.';
                        line = builder.ToString();
                        lines[row] = line;
                        while (true) //Check Number left side
                        {
                            counter++;

                            if (col + counter < line.Length && Char.IsDigit(line[col + counter]))
                            {
                                nums[nums.Count - 1] += line[col + counter];
                                builder[col + counter] = '.';
                                line = builder.ToString();
                                lines[row] = line;
                            }
                            else
                                break;
                        }
                    }
                }

                counter = 0;

                if (row != lines.Count - 1)//Line below
                {
                    builder = new StringBuilder(lines[row + 1]);
                    string below = lines[row + 1];
                    for (int i = 0; i < 3; i++)
                    {
                        int pos = 0;
                        if (col != 0)
                            pos = i - 1;

                        if (col - pos < below.Length && char.IsDigit(below[col - pos])) //Number below Symbol
                        {
                            counter = 0;
                            nums.Add(Convert.ToString(below[col - pos]));

                            builder[col - pos] = '.';
                            below = builder.ToString();

                            while (true) //Check Number left side
                            {
                                counter++;

                                if (col - pos - counter == -1)
                                    break;

                                if (Char.IsDigit(below[col - pos - counter]))
                                {
                                    nums[nums.Count - 1] = nums[nums.Count - 1].Insert(0, Convert.ToString(below[col - pos - counter]));
                                    builder[col - pos - counter] = '.';
                                    below = builder.ToString();
                                }
                                else
                                    break;

                            }

                            counter = 0;

                            while (true) //Check Number right side
                            {
                                counter++;

                                if (col - pos + counter >= below.Length)
                                    break;

                                if (Char.IsDigit(below[col - pos + counter]))
                                {
                                    nums[nums.Count - 1] += below[col - pos + counter];
                                    builder[col - pos + counter] = '.';
                                    below = builder.ToString();
                                }
                                else
                                    break;

                            }
                        }
                    }
                    lines[row + 1] = below; //Replacing main line
                }

            }
            if(nums.Count == 2)
                sum += int.Parse(nums[0]) * int.Parse(nums[1]);
            nums.Clear();
        }
    }

    foreach (var line in lines)
        Console.WriteLine(line);

    Console.WriteLine($"PartTwo: {sum}");
}
