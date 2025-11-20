using LudoGames.Types.Coordinates;
using LudoGames.Enums.PawnStates;

namespace LudoGames.Interface.Pawns
{
    interface IPawn
    {
        Coordinate Coordinate { get; }
        PawnStatesEnum PawnStatesEnum { get; }
        int PositionIndex { get; set; }
    }
}