using System;
using Library.Infrastructure.DTO;

namespace Library.Infrastructure.Services
{
    public interface IJwtHandler
    {
        JwtDto CreateToken(Guid userId, string role);
    }
}