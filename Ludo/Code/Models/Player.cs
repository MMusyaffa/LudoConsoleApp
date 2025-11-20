using LudoGames.Enums.Colors;
using LudoGames.Interface.Players;

namespace LudoGames.Models.Player
{
    class Player : IPlayer
    {
        public string Name { get; }
        public ColorsEnum ColorEnum { get; }

        public Player(string name, ColorsEnum color)
        {
            Name = name;
            ColorEnum = color;
        }
    }
}