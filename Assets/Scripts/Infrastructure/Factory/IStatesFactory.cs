using Infrastructure.Services;

namespace Infrastructure.Factory
{
    public interface IStatesFactory : IService
    {
        void CreateMainStates();
        void CreateSubStates();
    }
}