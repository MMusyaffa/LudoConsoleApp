using LudoGames.Interface.Pawns;
using LudoGames.Games.GameController;

GameController game = new GameController();

while (true)
{
    Console.Write("Tambah pemain? (y/n): ");
    string input = Console.ReadLine()!;

    if (input.ToLower() != "y") { break; }

    game.AddPlayer();
}

Console.WriteLine("Daftar pemain:");
foreach (var player in game.Players)
{
    Console.WriteLine($"Name: {player.Name}: {player.ColorEnum}, Pawn: {string.Join(", ", game.PlayerPawns[player])}");
}

int num = game.RollDice();
IPawn pawn = game.SelectPawn(game.Players[0]);
game.MovePawn(game.Players[0], pawn, num);

int num1 = game.RollDice();
IPawn pawn1 = game.SelectPawn(game.Players[0]);
game.MovePawn(game.Players[0], pawn1, num1);

int num2 = game.RollDice();
IPawn pawn2 = game.SelectPawn(game.Players[0]);
game.MovePawn(game.Players[0], pawn2, num2);