StreamReader reader = new StreamReader("..\\..\\..\\data.txt");

int sum = 0;

while(!reader.EndOfStream)
{
    string line = reader.ReadLine();
    string nums = string.Concat(line.Where(Char.IsDigit));
    string num = Convert.ToString(nums[0]) + Convert.ToString(nums[nums.Length-1]);
    sum += Convert.ToInt32(num);
}

Console.WriteLine(sum);
reader.Close();