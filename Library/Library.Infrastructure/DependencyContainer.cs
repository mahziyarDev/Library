using Library.Service.IServices;
using Library.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Library.IOC;

public class DependencyContainer
{
    public static void RegisterService(IServiceCollection service)
    {
        service.AddScoped<IUserService, UserService>();
        
    }

}