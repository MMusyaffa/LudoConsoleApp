using LudoGames.Types.Coordinates;
using LudoGames.Enums.Colors;
using LudoGames.Enums.PawnStates;
using LudoGames.Interface.Boards;
using LudoGames.Interface.Dices;
using LudoGames.Interface.Pawns;
using LudoGames.Interface.Players;
using LudoGames.Interface.Tiles;
using LudoGames.Models.Boards;
using LudoGames.Models.Dices;
using LudoGames.Models.Pawns;
using LudoGames.Models.Player;
using LudoGames.Models.Tiles;

namespace LudoGames.Games.GameController
{
    class GameController
    {
        // public Dictionary<IPlayer, int> PlayerScores;
        public Dictionary<IPlayer, List<IPawn>> PlayerPawns;
        // public Dictionary<ColorsEnum, List<Coordinate>> ColorPaths;
        public ITile[,] Tiles;
        private IDice _dice;
        private int _pawnIndex;
        private readonly Random _random = new Random();
        public List<Coordinate> PathA { get; private set; }

        public GameController(IPlayer player1, List<IPawn> pawn)
        {
            PlayerPawns = new Dictionary<IPlayer, List<IPawn>> { {player1, pawn} };
        }

        public void Setup()
        {
            IBoard board = new Board(15,15);
            this.Tiles = board.Tiles;
            _dice = new Dice(6);

            Console.WriteLine($"Tiles size: {Tiles.GetLength(0)} x {Tiles.GetLength(1)}");

            PathA = MakeAPath();
            MakeBPath();
            MakeCPath();
            MakeDPath();

            
        }

        private List<Coordinate> MakeAPath()
        {
            List<Coordinate> pathA = new List<Coordinate>();

            for (int x = 1; x <= 5; x++) { pathA.Add(Tiles[x, 6].Coordinate); }
            for (int y = 5; y >= 0; y--) { pathA.Add(Tiles[6, y].Coordinate); }
            pathA.Add(Tiles[7,0].Coordinate);

            for (int y = 0; y <= 5; y++) { pathA.Add(Tiles[8, y].Coordinate); }
            for (int x = 9; x <= 14; x++) { pathA.Add(Tiles[x, 6].Coordinate); }
            pathA.Add(Tiles[14,7].Coordinate);

            for (int x = 14; x >=9; x--) { pathA.Add(Tiles[x, 8].Coordinate); }
            for (int y = 9; y <= 14; y++) { pathA.Add(Tiles[8, y].Coordinate); }
            pathA.Add(Tiles[7,14].Coordinate);

            for (int y = 14; y >=9; y--) { pathA.Add(Tiles[6, y].Coordinate); }
            for (int x = 5; x >=0; x--) { pathA.Add(Tiles[x, 8].Coordinate); }
            for (int x = 0; x <= 6; x++) { pathA.Add(Tiles[x, 7].Coordinate); }

            Console.WriteLine("Tiles A Complete");
            return pathA;
        }

        private List<Coordinate> MakeBPath()
        {
            List<Coordinate> pathB = new List<Coordinate>();

            for (int y = 1; y <= 5; y++) { pathB.Add(Tiles[8, y].Coordinate); }
            for (int x = 9; x <= 14; x++) { pathB.Add(Tiles[x, 6].Coordinate); }
            pathB.Add(Tiles[14,7].Coordinate);

            for (int x = 14; x >=9; x--) { pathB.Add(Tiles[x, 8].Coordinate); }
            for (int y = 9; y <= 14; y++) { pathB.Add(Tiles[8, y].Coordinate); }
            pathB.Add(Tiles[7,14].Coordinate);

            for (int y = 14; y >=9; y--) { pathB.Add(Tiles[6, y].Coordinate); }
            for (int x = 5; x >=0; x--) { pathB.Add(Tiles[x, 8].Coordinate); }
            pathB.Add(Tiles[0,7].Coordinate);

            for (int x = 0; x <= 5; x++) { pathB.Add(Tiles[x, 6].Coordinate); }
            for (int y = 5; y >= 0; y--) { pathB.Add(Tiles[6, y].Coordinate); }
            for (int y = 0; y <= 6; y++) { pathB.Add(Tiles[7, y].Coordinate); }

            Console.WriteLine("Tiles B Complete");
            return pathB;
        }

        private List<Coordinate> MakeCPath()
        {
            List<Coordinate> pathC = new List<Coordinate>();

            for (int x = 13; x >=9; x--) { pathC.Add(Tiles[x, 8].Coordinate); }
            for (int y = 9; y <= 14; y++) { pathC.Add(Tiles[8, y].Coordinate); }
            pathC.Add(Tiles[7,14].Coordinate);

            for (int y = 14; y >=9; y--) { pathC.Add(Tiles[6, y].Coordinate); }
            for (int x = 5; x >=0; x--) { pathC.Add(Tiles[x, 8].Coordinate); }
            pathC.Add(Tiles[0,7].Coordinate);

            for (int x = 0; x <= 5; x++) { pathC.Add(Tiles[x, 6].Coordinate); }
            for (int y = 5; y >= 0; y--) { pathC.Add(Tiles[6, y].Coordinate); }
            pathC.Add(Tiles[7,0].Coordinate);

            for (int y = 0; y <= 5; y++) { pathC.Add(Tiles[8, y].Coordinate); }
            for (int x = 9; x <= 14; x++) { pathC.Add(Tiles[x, 6].Coordinate); }
            for (int x = 14; x >= 8; x--) { pathC.Add(Tiles[x, 7].Coordinate); }

            Console.WriteLine("Tiles C Complete");
            return pathC;
        }

        private List<Coordinate> MakeDPath()
        {
            List<Coordinate> pathD = new List<Coordinate>();

            for (int y = 13; y >=9; y--) { pathD.Add(Tiles[6, y].Coordinate); }
            for (int x = 5; x >=0; x--) { pathD.Add(Tiles[x, 8].Coordinate); }
            pathD.Add(Tiles[0,7].Coordinate);

            for (int x = 0; x <= 5; x++) { pathD.Add(Tiles[x, 6].Coordinate); }
            for (int y = 5; y >= 0; y--) { pathD.Add(Tiles[6, y].Coordinate); }
            pathD.Add(Tiles[7,0].Coordinate);

            for (int y = 0; y <= 5; y++) { pathD.Add(Tiles[8, y].Coordinate); }
            for (int x = 9; x <= 14; x++) { pathD.Add(Tiles[x, 6].Coordinate); }
            pathD.Add(Tiles[14,7].Coordinate);

            for (int x = 14; x >=9; x--) { pathD.Add(Tiles[x, 8].Coordinate); }
            for (int y = 9; y <= 14; y++) { pathD.Add(Tiles[8, y].Coordinate); }
            for (int y = 14; y >= 8; y--) { pathD.Add(Tiles[7, y].Coordinate); }

            Console.WriteLine("Tiles D Complete");
            return pathD;
        }

        public int RollDice()
        {
            Console.Write("Lempar dadu? (y): ");
            string input = Console.ReadLine()!;

            if (input?.ToLower() != "y") 
            { 
                Console.WriteLine("Tidak lempar input salah");
                return 0;
            }
            int diceNumber = _random.Next(1, _dice.Sides + 1);

            Console.Write($"Dice Roll: {diceNumber}\n");
            return diceNumber;
        }

        public void MovePawn(IPawn pawn, int step)
        {
            int oldIndex = pawn.PositionIndex;
            int newIndex = pawn.PositionIndex + step;

            // if (newIndex >= PathA.Count)

            Coordinate currentCoordinate = pawn.Coordinate;
            Coordinate newCoordinate = PathA[newIndex];


            Console.Write($"Bidak maju sebanyak: {step}\n");
            Console.WriteLine($"Dari block {currentCoordinate} ke block {newCoordinate}");
        }
    }
}