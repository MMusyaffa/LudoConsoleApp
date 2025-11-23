using LudoGames.Interface.Pawns;
using LudoGames.Games.GameController;
using LudoGames.Interface.Players;
using LudoGames.Enums.PawnStates;

GameController game = new GameController();

while (true)
{
    if (game.Players.Count < 4)
    {
        Console.Write("Tambah pemain? (y/n): ");
        string input = Console.ReadLine()!;

        if (input.ToLower() == "y") { game.AddPlayer(); }
        else
        {
            if (game.Players.Count < 2)
            {
                Console.WriteLine("Minimal harus ada 2 pemain untuk memulai game!");
                continue;
            }
            break;
        }

    }
    else { Console.WriteLine("Player sudah penuh"); break;}
}

Console.WriteLine("Daftar pemain:");
foreach (var player in game.Players)
{
    Console.WriteLine($"Name: {player.Name}: {player.ColorEnum}, Pawn: {string.Join(", ", game.PlayerPawns[player])}");
}

game.AssignFirstPlayerTurn();

while(true)
{
    IPlayer currentPlayer = game.GetCurrentPlayerTurn();
    int num = game.RollDice();

    if (!game.CanPawnMove(currentPlayer, num))
    {
        game.NextTurn();
        continue;
    }   

    IPawn pawn = game.SelectPawn(currentPlayer, num);

    if (pawn.PawnStatesEnum == PawnStatesEnum.AtHome)
    {
        if(num == 6)
        {
            Console.WriteLine("Pawn keluar dari home");
            game.UpdatePawnState(pawn);
            // game.RollDice();
        }
        else{ game.NextTurn(); }
    } 
    else 
    {
        if (num == 6)
        {
            game.MovePawn(currentPlayer, pawn, num);
        }
        else
        {
            game.MovePawn(currentPlayer, pawn, num);
            game.NextTurn();
        }
    }
}