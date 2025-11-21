using LudoGames.Types.Coordinates;
using LudoGames.Enums.Colors;
using LudoGames.Interface.Boards;
using LudoGames.Interface.Dices;
using LudoGames.Interface.Pawns;
using LudoGames.Interface.Players;
using LudoGames.Interface.Tiles;
using LudoGames.Models.Boards;
using LudoGames.Models.Dices;
using LudoGames.Models.Player;
using LudoGames.Models.Pawns;
using LudoGames.Enums.PawnStates;

namespace LudoGames.Games.GameController
{
    class GameController
    {
        public List<IPlayer> Players { get; private set; }
        public Dictionary<IPlayer, int> PlayerScores { get; private set; }
        public Dictionary<IPlayer, List<IPawn>> PlayerPawns { get; private set; }
        public Dictionary<IPlayer, List<Coordinate>> PlayerPaths { get; private set; }
        private ITile[,] _tiles;
        private IDice _dice;
        public List<Coordinate> PathA { get; private set; }
        public List<Coordinate> PathB { get; private set; }
        public List<Coordinate> PathC { get; private set; }
        public List<Coordinate> PathD { get; private set; }
        private readonly Random _random = new();
        private int _diceNumber = 0;

        public GameController()
        {
            Players = new List<IPlayer>();
            PlayerPawns = new Dictionary<IPlayer, List<IPawn>>();
            PlayerScores = new Dictionary<IPlayer, int>();
            PlayerPaths = new Dictionary<IPlayer, List<Coordinate>>();

            IBoard board = new Board(15,15);
            _tiles = board.Tiles;
            _dice = new Dice(6);

            Console.WriteLine($"Board size: {_tiles.GetLength(0)} x {_tiles.GetLength(1)}");

            PathA = MakeAPath();
            PathB = MakeBPath();
            PathC = MakeCPath();
            PathD = MakeDPath();
        }

        private List<Coordinate> MakeAPath()
        {
            List<Coordinate> pathA = new List<Coordinate>();

            for (int x = 1; x <= 5; x++) { pathA.Add(_tiles[x, 6].Coordinate); }
            for (int y = 5; y >= 0; y--) { pathA.Add(_tiles[6, y].Coordinate); }
            pathA.Add(_tiles[7,0].Coordinate);

            for (int y = 0; y <= 5; y++) { pathA.Add(_tiles[8, y].Coordinate); }
            for (int x = 9; x <= 14; x++) { pathA.Add(_tiles[x, 6].Coordinate); }
            pathA.Add(_tiles[14,7].Coordinate);

            for (int x = 14; x >=9; x--) { pathA.Add(_tiles[x, 8].Coordinate); }
            for (int y = 9; y <= 14; y++) { pathA.Add(_tiles[8, y].Coordinate); }
            pathA.Add(_tiles[7,14].Coordinate);

            for (int y = 14; y >=9; y--) { pathA.Add(_tiles[6, y].Coordinate); }
            for (int x = 5; x >=0; x--) { pathA.Add(_tiles[x, 8].Coordinate); }
            for (int x = 0; x <= 6; x++) { pathA.Add(_tiles[x, 7].Coordinate); }

            Console.WriteLine("Path A Complete");
            return pathA;
        }

        private List<Coordinate> MakeBPath()
        {
            List<Coordinate> pathB = new List<Coordinate>();

            for (int y = 1; y <= 5; y++) { pathB.Add(_tiles[8, y].Coordinate); }
            for (int x = 9; x <= 14; x++) { pathB.Add(_tiles[x, 6].Coordinate); }
            pathB.Add(_tiles[14,7].Coordinate);

            for (int x = 14; x >=9; x--) { pathB.Add(_tiles[x, 8].Coordinate); }
            for (int y = 9; y <= 14; y++) { pathB.Add(_tiles[8, y].Coordinate); }
            pathB.Add(_tiles[7,14].Coordinate);

            for (int y = 14; y >=9; y--) { pathB.Add(_tiles[6, y].Coordinate); }
            for (int x = 5; x >=0; x--) { pathB.Add(_tiles[x, 8].Coordinate); }
            pathB.Add(_tiles[0,7].Coordinate);

            for (int x = 0; x <= 5; x++) { pathB.Add(_tiles[x, 6].Coordinate); }
            for (int y = 5; y >= 0; y--) { pathB.Add(_tiles[6, y].Coordinate); }
            for (int y = 0; y <= 6; y++) { pathB.Add(_tiles[7, y].Coordinate); }

            Console.WriteLine("Path B Complete");
            return pathB;
        }

        private List<Coordinate> MakeCPath()
        {
            List<Coordinate> pathC = new List<Coordinate>();

            for (int x = 13; x >=9; x--) { pathC.Add(_tiles[x, 8].Coordinate); }
            for (int y = 9; y <= 14; y++) { pathC.Add(_tiles[8, y].Coordinate); }
            pathC.Add(_tiles[7,14].Coordinate);

            for (int y = 14; y >=9; y--) { pathC.Add(_tiles[6, y].Coordinate); }
            for (int x = 5; x >=0; x--) { pathC.Add(_tiles[x, 8].Coordinate); }
            pathC.Add(_tiles[0,7].Coordinate);

            for (int x = 0; x <= 5; x++) { pathC.Add(_tiles[x, 6].Coordinate); }
            for (int y = 5; y >= 0; y--) { pathC.Add(_tiles[6, y].Coordinate); }
            pathC.Add(_tiles[7,0].Coordinate);

            for (int y = 0; y <= 5; y++) { pathC.Add(_tiles[8, y].Coordinate); }
            for (int x = 9; x <= 14; x++) { pathC.Add(_tiles[x, 6].Coordinate); }
            for (int x = 14; x >= 8; x--) { pathC.Add(_tiles[x, 7].Coordinate); }

            Console.WriteLine("Path C Complete");
            return pathC;
        }

        private List<Coordinate> MakeDPath()
        {
            List<Coordinate> pathD = new List<Coordinate>();

            for (int y = 13; y >=9; y--) { pathD.Add(_tiles[6, y].Coordinate); }
            for (int x = 5; x >=0; x--) { pathD.Add(_tiles[x, 8].Coordinate); }
            pathD.Add(_tiles[0,7].Coordinate);

            for (int x = 0; x <= 5; x++) { pathD.Add(_tiles[x, 6].Coordinate); }
            for (int y = 5; y >= 0; y--) { pathD.Add(_tiles[6, y].Coordinate); }
            pathD.Add(_tiles[7,0].Coordinate);

            for (int y = 0; y <= 5; y++) { pathD.Add(_tiles[8, y].Coordinate); }
            for (int x = 9; x <= 14; x++) { pathD.Add(_tiles[x, 6].Coordinate); }
            pathD.Add(_tiles[14,7].Coordinate);

            for (int x = 14; x >=9; x--) { pathD.Add(_tiles[x, 8].Coordinate); }
            for (int y = 9; y <= 14; y++) { pathD.Add(_tiles[8, y].Coordinate); }
            for (int y = 14; y >= 8; y--) { pathD.Add(_tiles[7, y].Coordinate); }

            Console.WriteLine("Path D Complete");
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
            _diceNumber = _random.Next(1, _dice.Sides + 1);

            Console.Write($"Dice Roll: {_diceNumber}\n");
            return _diceNumber;
        }

        public void MovePawn(IPlayer player, IPawn pawn, int step)
        {
            var path = PlayerPaths[player];
            int newIndex = pawn.PositionIndex + step;

            Coordinate currentCoordinate = pawn.Coordinate;
            Coordinate newCoordinate = path[newIndex];

            // if (newIndex >= PathA.Count)

            UpdatePawnPosition(pawn, newCoordinate, newIndex);

            Console.Write($"Bidak maju sebanyak: {step}\n");
            Console.WriteLine($"Dari block {currentCoordinate} ke block {newCoordinate}");
        }

        public void UpdatePawnPosition(IPawn pawn, Coordinate coordinate, int index)
        {
            pawn.Coordinate = coordinate;
            pawn.PositionIndex = index;
        }

        public bool AddPlayer()
        {
            string name = AddPlayerName();
            IPlayer player = new Player(name);
            
            ColorsEnum color = RequestColorFromPlayer(player);
            player.ColorEnum = color;
            
            if (Players.Contains(player)) return false;

            List<Coordinate> playerPath = PathOrderPlayer();
            var pawns = CreatePawnForPlayer(playerPath);

            Players.Add(player);
            PlayerScores[player] = 0;
            PlayerPawns[player] = pawns;
            PlayerPaths[player] = playerPath;

            return true;
        }

        public string AddPlayerName()
        {
            Console.Write("Masukkan nama player: ");
            return Console.ReadLine()!;
        }

        private bool IsColorTaken(ColorsEnum color)
        {
            return Players.Any(p => p.ColorEnum == color);
        }

        public ColorsEnum RequestColorFromPlayer(IPlayer player)
        {
            while (true)
            {
                Console.WriteLine("Pilih warna untuk player " + player.Name + ":");
                Console.WriteLine("0. Red");
                Console.WriteLine("1. Blue");
                Console.WriteLine("2. Green");
                Console.WriteLine("3. Yellow");

                if (int.TryParse(Console.ReadLine(), out int selected) &&
                    Enum.IsDefined(typeof(ColorsEnum), selected))
                {
                    var chosenColor = (ColorsEnum)selected;

                    if (!IsColorTaken(chosenColor)) 
                    {
                        player.ColorEnum = chosenColor;
                        Console.WriteLine($"player: {player.Name}, color: {player.ColorEnum}");

                        return chosenColor; 
                    }
                    else { Console.WriteLine("Warna sudah dipilih pemain lain! Pilih warna lain."); }
                }
                else { Console.WriteLine("Input tidak valid! Pilih angka 0-3."); }
            }
        }

        private List<Coordinate> PathOrderPlayer()
        {
            int playerIndex = Players.Count; 
            
            return playerIndex switch
            {
                0 => PathD,
                1 => PathB,
                2 => PathA,
                3 => PathC,
                _ => throw new NotImplementedException(),
            };
        }

        private List<IPawn> CreatePawnForPlayer(List<Coordinate> coordinate)
        {
            var pawns = new List<IPawn>();

            for (int i = 0; i < 4; i++)
            {
                pawns.Add(new Pawn((coordinate[0]), PawnStatesEnum.AtHome, 0));
            }

            return pawns;
        }

        public IPawn SelectPawn(IPlayer player)
        {
            var pawns = PlayerPawns[player];

            Console.WriteLine($"{player.Name} - Pilih pawn untuk dijalankan");

            for (int i = 0; i < pawns.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Pawn {i + 1} - Posisi: {pawns[i].Coordinate}");
            }

            int selectedPawn;

            while(true)
            {
                Console.Write("Masukan nomor pawn: ");

                if (int.TryParse(Console.ReadLine(), out selectedPawn) &&
                    selectedPawn >= 0 && selectedPawn < pawns.Count)
                {
                    return pawns[selectedPawn];
                }
            }
            Console.WriteLine("Pilihan tidak valid! Coba lagi.");
        }

        public void SwitchTurn(IPlayer player)
        {
            
        }

        public void AssignFirstPlayerTurn()
        {
            
        }

    }
}