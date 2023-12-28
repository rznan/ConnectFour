using Connect4.Models;
using Connect4.Services;

ConnectFour game = new ConnectFour();

game.StartGame();

bool isWon = game.CheckWin();

while(!isWon)
{
    Console.Clear();

    game.DisplayBoard();

    while(true)
    {
        Console.Write($"{game.CurrentPlayer.Name}, seu movimento: ");

        string ?input = Console.ReadLine();

        if(string.IsNullOrEmpty(input)) continue;

        if(game.MakeMove(input)) break;

        Console.WriteLine
        (
            "Por favor, Insira um valor válido\n" +
            "Ex: A2, B3, C1"
        ); 
    }

    isWon = game.CheckWin();
}

Console.Clear();

if(game.Winner != null)
{
    ConsoleColorChanger.ChangeColor(game.Winner.Color);
    Console.WriteLine(
        "■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■\n" +
        "■            VITÓRIA           ■\n" +
        "■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■\n" +
       $"{game.Winner.Name} , Venceu. Parabéns!\n" +
        "■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■"
    );
    Console.ResetColor();
}
else
{
    Console.WriteLine("EMPATE!");
}
