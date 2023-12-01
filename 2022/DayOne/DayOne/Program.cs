using DayOne;
using System.Runtime.InteropServices;

List<Elf> elves = new List<Elf>();

StreamReader reader = new StreamReader("..\\..\\..\\data.txt");

elves.Add(new Elf("1"));
int i = 1;
while (!reader.EndOfStream)
{
    string d = reader.ReadLine();
    if (d != "")
    {
        elves[i-1].add(Convert.ToInt32(d));
    }
    else
    {
        i++;
        elves.Add(new Elf(i.ToString()));
    }
}

elves.Sort((p, q) => p.Calories.CompareTo(q.Calories));

int sum = 0;
for(int j = 1;  j <= 3; j++)
{
    sum += elves[elves.Count - j].Calories;
}

Console.Write(sum.ToString());
reader.Close();
