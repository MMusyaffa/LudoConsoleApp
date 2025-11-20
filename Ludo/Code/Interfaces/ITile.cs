using LudoGames.Types.Coordinates;
using LudoGames.Enums.TileTypes;
using LudoGames.Interface.Pawns;

namespace LudoGames.Interface.Tiles
{
    interface ITile
    {
        TileTypesEnum TileTypes { get; }
        Coordinate Coordinate { get; }
        List<IPawn> PawnList { get; }
    }
}