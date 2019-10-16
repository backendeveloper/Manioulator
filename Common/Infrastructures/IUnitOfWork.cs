namespace Common.Infrastructures
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}