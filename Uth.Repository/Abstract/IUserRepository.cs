namespace Uth.Repository.Abstract
{
    public interface IUserRepository
    {
        void Register(string email, string firstname, string lastname, string password);
    }
}
