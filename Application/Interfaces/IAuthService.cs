using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Auth;

namespace Application.Interfaces
{
    public interface IAuthService
    {
        Task<string> LoginAsync(LoginDTO dto);
        Task RegisterAsync(RegisterDTO dto);
    }
}
