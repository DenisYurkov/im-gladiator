namespace _Project.Core
{
    public interface IHealth
    {
        void Increase(int increaseValue);
        void Decrease(int decreaseValue);
    }
}