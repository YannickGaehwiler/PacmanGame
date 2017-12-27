public interface ILogicalGhost
{
    int Column { get; set; }
    int Row { get; set; }
    void RandomDirection();
}