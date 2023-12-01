StreamReader reader = new StreamReader("..\\..\\..\\data.txt");

int sum = 0;

while(!reader.EndOfStream)
{
    string line = reader.ReadLine();
    string num = string.Empty;
    for(int i = 0; i < line.Length; i++)
    {
        if (char.IsNumber(line[i]))
        {
            num += line[i];
        }
    }
    sum += Convert.ToInt32(num);
}

Console.WriteLine(sum);
reader.Close();