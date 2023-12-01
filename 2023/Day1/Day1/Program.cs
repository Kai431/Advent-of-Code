using System.Diagnostics.CodeAnalysis;

IDictionary<string, int> numberNames = new Dictionary<string, int>();
numberNames.Add("zero", 0); //Not Needed
numberNames.Add("one", 1);
numberNames.Add("two", 2);
numberNames.Add("three", 3);
numberNames.Add("four", 4);
numberNames.Add("five", 5);
numberNames.Add("six", 6);
numberNames.Add("seven", 7);
numberNames.Add("eight", 8);
numberNames.Add("nine", 9);

PartOne();
PartTwo();

void PartOne()
{
    Console.Write("PartOne: ");

    StreamReader reader = new StreamReader("..\\..\\..\\data.txt");
    int sum = 0;

    while (!reader.EndOfStream)
    {
        string line = reader.ReadLine();
        string nums = string.Concat(line.Where(Char.IsDigit));
        string num = Convert.ToString(nums[0]) + Convert.ToString(nums[nums.Length - 1]);
        sum += Convert.ToInt32(num);
    }

    Console.WriteLine(sum);
    reader.Close();
}

void PartTwo()
{
    Console.Write("PartTwo: ");

    StreamReader reader = new StreamReader("..\\..\\..\\data.txt");

    int sum = 0;

    while (!reader.EndOfStream)
    {
        string line = reader.ReadLine();

        List<int> nums = new List<int>();
        List<int> index = new List<int>();

        for (int i = 0; i < numberNames.Count; i++)
        {
            if(line.Contains(numberNames.ElementAt(i).Key))
            {
                var first = line.IndexOf(numberNames.ElementAt(i).Key);
                var last = line.LastIndexOf(numberNames.ElementAt(i).Key);

                if(first == last)
                {
                    nums.Add(i);
                    index.Add(first);
                }
                else
                {
                    nums.Add(i);
                    index.Add(first);
                    nums.Add(i);
                    index.Add(last);
                }
            }
            
            if(line.Contains(Convert.ToString(i)))
            {
                var first = line.IndexOf(Convert.ToString(numberNames.ElementAt(i).Value));
                var last = line.LastIndexOf(Convert.ToString(numberNames.ElementAt(i).Value));

                if (first == last)
                {
                    nums.Add(i);
                    index.Add(first);
                }
                else
                {
                    nums.Add(i);
                    index.Add(first);
                    nums.Add(i);
                    index.Add(last);
                }
            }

        }

        var maxIndex = index.IndexOf(index.Max());
        var minIndex = index.IndexOf(index.Min());
        
        string result = Convert.ToString(nums[minIndex]) + Convert.ToString(nums[maxIndex]);
        sum += Convert.ToInt32(result);
    }

    Console.WriteLine(sum);
    reader.Close();
}

