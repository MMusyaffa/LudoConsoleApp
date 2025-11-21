using LudoGames.Types.Coordinates;
using LudoGames.Enums.PawnStates;

namespace LudoGames.Interface.Pawns
{
    interface IPawn
    {
        Coordinate Coordinate { get; set; }
        PawnStatesEnum PawnStatesEnum { get; }
        int PositionIndex { get; set; }
    }
}