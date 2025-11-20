using LudoGames.Enums.Colors;

namespace LudoGames.Models.Player
{
    interface IPlayer
    {
        string Name { get; }
        ColorEnum ColorEnum { get; }
    }

    class Player : IPlayer
    {
        public string Name { get; }
        public ColorEnum ColorEnum { get; }

        public Player(string name, ColorEnum color)
        {
            Name = name;
            ColorEnum = color;
        }
    }
}