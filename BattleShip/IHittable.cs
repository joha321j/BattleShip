namespace BattleShip
{
    public interface IHittable
    {
        int Size { get; }
        int Width { get; }
        int HitPoints{ get; }

        int[] FirstCoordinate { get; }
        int[] LastCoordinate { get; }
        bool HitCheck(int[] hitCoordinate);
    }
}