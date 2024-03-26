using Application.Common.Model;

namespace Application.Common.Interface
{
    public interface ICurrentUserService
    {
        string UserId { get; }
    }
}
