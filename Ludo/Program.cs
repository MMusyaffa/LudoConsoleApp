using LudoGames.Enums.Colors;
using LudoGames.Enums.PawnStates;
using LudoGames.Games.GameController;
using LudoGames.Interface.Dices;
using LudoGames.Interface.Pawns;
using LudoGames.Interface.Players;
using LudoGames.Models.Dices;
using LudoGames.Models.Pawns;
using LudoGames.Models.Player;
using LudoGames.Types.Coordinates;

// IDice dice = new Dice(6);
// IPawn pawn = new Pawn(new Coordinate(0, 0), PawnStatesEnum.OnBoard);

IPlayer player = new Player("Affa", ColorsEnum.Blue);
List<IPawn> pawnsPlayer1 = new List<IPawn>();
GameController game = new GameController(player, pawnsPlayer1);

game.Setup();

var path = game.PathA;
Coordinate[] PawnCoordinate = [ path[0], path[0], path[0], path[0] ];
Console.WriteLine($"Spawn Pawn: {string.Join(", ", PawnCoordinate)}");

foreach (var spawn in PawnCoordinate)
{
    pawnsPlayer1.Add(new Pawn(spawn, PawnStatesEnum.OnBoard));
}

Console.WriteLine($"Name: {player.Name}, Pawn: {string.Join(", ", pawnsPlayer1)}");

int num = game.RollDice();
game.MovePawn(pawnsPlayer1[0], num);