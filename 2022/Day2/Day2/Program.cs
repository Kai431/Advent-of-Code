// See https://aka.ms/new-console-template for more information
using System.Runtime.InteropServices;

StreamReader reader = new StreamReader("..\\..\\..\\data.txt");

int points = 0;

while(!reader.EndOfStream)
{
    string data = reader.ReadLine();
    string[] tokens = data.Split(' ');
    string e = getSign(tokens[0]);
    string me = getSign(tokens[1]);

    points += getSignPoints(me);
    points += getOutPoints(e, me);
}

Console.WriteLine(points);

string getSign(string sign)
{
    switch (sign)
    {
        case "A":
        case "X":
            return "Rock";
        case "B":
        case "Y":
            return "Paper";
        case "C":
        case "Z":
            return "Scissors";
        default:
            return null;
    }
}

int getSignPoints(string me)
{
    switch(me)
    {
        case "Rock":
            return 1;
        case "Paper":
            return 2;
        case "Scissors":
            return 3;
        default:
            return 0;
    }
}

int getOutPoints(string enemy, string me)
{
    if (enemy == me)
        return 3;
    else if (enemy == "Rock" && me == "Scissors" || enemy == "Paper" && me == "Rock" || enemy == "Scissors" && me == "Paper")
        return 0;
    else
        return 6;
}
