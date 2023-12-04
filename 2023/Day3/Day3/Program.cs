StreamReader reader = new StreamReader("..//..//..//data.txt");

List<string> lines = new List<string>();
List<int> nums = new List<int>();

while(!reader.EndOfStream)
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
            if(row != 0)//Line above
            {
                string above = lines[row-1];
                for (int i = 0; i < 3; i++)
                {
                    int pos = i-1;
                    if (char.IsDigit(above[col-pos])) //Number above Symbol
                    {
                        int start;
                        int end;
                        int counter = 0;
                        while(true)
                        {
                            counter++;

                            if(!Char.IsDigit(above[col - pos - counter]))
                            {
                                counter--;
                                break;
                            }
                            else if(col - pos - counter == 0)
                                break;
                        }
                            
                        
                        Console.WriteLine(col);
                        Console.WriteLine(pos);
                        Console.WriteLine(counter);
                        start = col - pos - counter;
                        counter = 0;
                        while (true)
                        {
                            counter++;

                           if (!Char.IsDigit(above[col + pos + counter]) || col + pos + counter == above.Length)
                            {
                                counter--;
                                break;
                            }
                        }
                        while (Char.IsDigit(above[col + pos + counter]) && col + pos + counter < above.Length)
                            counter++;
                        end = col + pos + counter;

                        Console.WriteLine(start + " " + end);
                        Console.WriteLine(above.Substring(start, end - start));

                        /*
                        nums.Add(int.Parse(above.Substring(start, end-start)));
                        above = above.Substring(0, start) +
                               new string('n', end - start) +
                               above.Substring(end);
                        lines[row - 1] = above;
                        */
                    }
                }
            }
        }
    }
}

for (int i = 0;i < nums.Count;i++)
{
    Console.WriteLine(nums[i]);
}

for(int i = 0;i < lines.Count; i++)
    Console.WriteLine(lines[i]);