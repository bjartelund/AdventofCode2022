// See https://aka.ms/new-console-template for more information

using System.Runtime.CompilerServices;

Console.WriteLine("Hello, World!");
var lines = File.ReadAllLines("input");
int score = 0;
foreach (var line in lines)
{
    var plays = line.Split(' ');
    var roundscore = plays[1] switch
    {
        "X" => CalculateWinner(plays[0], plays[1])+ 1,
        "Y" => CalculateWinner(plays[0], plays[1]) + 2,
        "Z" => CalculateWinner(plays[0], plays[1]) + 3,
    };
    score += roundscore;
}
Console.WriteLine(score);

int CalculateWinner(string player1, string player2)
{
    var score = 0;
    switch (player1)
    {
        case "A":
        {
            score = player2 switch
            {
                "X" => 3,
                "Y" => 6,
                _ => score
            };

            break;
        }
        case "B":
        {
            score = player2 switch
            {
                "Y" => 3,
                "Z" => 6,
                _ => score
            };

            break;
        }
        case "C":
        {
            if (player2.Equals("Z"))
            {
                score = 3;
            }

            if (player2.Equals("X"))
            {
                score = 6;
            }

            break;
        }
    }

    return score;
}

int CalculateScoreForOutcome(string play, string outcome)
{
    if (play.Equals("A"))
    {
        if (outcome.Equals("X")) return 0;
        if (outcome.Equals("Y")) return 2;
        if (outcome.Equals("Z")) 
    }
}