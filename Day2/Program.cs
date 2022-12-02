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
        _ => 0
    };
    score += roundscore;
}
Console.WriteLine(score);
score=0;
foreach (var line in lines)
{
    var plays = line.Split(' ');
    var roundscore = CalculateWinner2(plays[0], GetPlayForOutcome(plays[0],plays[1]));
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
            score = player2 switch {
                "Z" => 3,
                "X" => 6,
                _ => score,
            };
            
            break;
        }
        default:
        {
            break;
        }
    }

    return score;
}

int CalculateWinner2(string player1, string player2)
{
    var score = 0;
    switch (player1)
    {
        case "A":
        {
            score = player2 switch
            {
                "X" => 3+1,
                "Y" => 6+2,
                "Z" => 0+3,
                _ => score
            };

            break;
        }
        case "B":
        {
            score = player2 switch
            {
                "Y" => 3+2,
                "Z" => 6+3,
                "X" => 0+1,
                _ => score
            };

            break;
        }
        case "C":
        {
            score = player2 switch{
                "Z" => 3+3,
                "X" => 6+1,
                "Y" => 0+2,
                _ => score
            };

            break;
        }
        default:
        {
            break;
        }
    }

    return score;
}

string GetPlayForOutcome(string play, string outcome)
{

    //x lose
    //y draw
    //z win
    //a - x rock
    //b - y paper
    //c - z scissor 
    if (play.Equals("A"))
    {
        if (outcome.Equals("X")) return "Z";
        if (outcome.Equals("Y")) return "X";
        if (outcome.Equals("Z")) return "Y";
    }
        if (play.Equals("B"))
    {
        if (outcome.Equals("X")) return "X";
        if (outcome.Equals("Y")) return "Y";
        if (outcome.Equals("Z")) return "Z";
    }
            if (play.Equals("C"))
    {
        if (outcome.Equals("X")) return "Y";
        if (outcome.Equals("Y")) return "Z";
        if (outcome.Equals("Z")) return "X";
    }
    return "";
}

