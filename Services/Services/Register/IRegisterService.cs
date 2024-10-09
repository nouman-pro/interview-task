using Services.Services.Register.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace Services.Services.Register
{
    public interface IRegisterService
    {
        Task<object> Login(LoginRequestModel request);
        Task<object> SignUp(RegisterRequestModel request);
        Task<ApiResponseModel> GetUser(int userId);
    }
}
