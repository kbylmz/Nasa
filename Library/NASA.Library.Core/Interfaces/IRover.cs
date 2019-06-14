namespace NASA.Library.Core.Interfaces
{
    public interface IRover
    {
        void SetInitializePosition(Position position);
        Position GetPosition();
        void RunCommand(char command);
    }
}