using AutoMapper;
using Azure.Core;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Repository.UnitOfWork;
using Services.Services.Register.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace Services.Services.Register
{
    public class RegisterService : IRegisterService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public RegisterService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponseModel> GetUser(int userId)
        {
            try
            {
                //userId & loginId are same bcz of 1 to 1 Relation
                var getUser = await _unitOfWork.LoginRepo.AsQueryable().Where(x => x.LoginId == userId)
                    .Select(x => new
                    {
                        x.Email,
                        x.Mobile,
                        Name = x.Users.Name,
                        IcNumber = x.Users.IcNumber,
                    }).FirstOrDefaultAsync();
                if (getUser == null)
                {
                    return await Task<ApiResponseModel>.FromResult(new ApiResponseModel()
                    {
                        Data = null,
                        Message = "Record Not Found",
                        Succeeded = false,
                        HttpStatusCode = 400,
                    });
                }

                return await Task<ApiResponseModel>.FromResult(new ApiResponseModel()
                {
                    Data = getUser,
                    Message = "Record Found",
                    Succeeded = true,
                    HttpStatusCode = 200,
                });
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public async Task<object> Login(LoginRequestModel request)
        {
            try
            {
                var loginUser = await _unitOfWork.LoginRepo.AsQueryable().FirstOrDefaultAsync(x => (x.Email.Equals(request.Email) || x.Mobile.Equals(request.Mobile)) && x.Pin.Equals(request.Pin));


                if (loginUser == null)
                {
                    return await Task<ApiResponseModel>.FromResult(new ApiResponseModel()
                    {
                        Data = null,
                        Message = "Record Not Found",
                        Succeeded = false,
                        HttpStatusCode = 400,
                    });
                }
                var getUser = await this.GetUser(loginUser.LoginId);
                return await Task<ApiResponseModel>.FromResult(new ApiResponseModel()
                {
                    Data = getUser.Data,
                    Message = "Record Found",
                    Succeeded = true,
                    HttpStatusCode = 200,
                });

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<object> SignUp(RegisterRequestModel request)
        {

            try
            {
                var userExist = await _unitOfWork.LoginRepo.AsQueryable().AnyAsync(x => x.Email.Equals(request.Email) || x.Mobile.Equals(request.Mobile));
                if (userExist)
                {
                    return await Task<ApiResponseModel>.FromResult(new ApiResponseModel()
                    {
                        Data = null,
                        Message = "User Already Exist",
                        Succeeded = true,
                        HttpStatusCode = 200,
                    });


                }


                var mapper = _mapper.Map<SYS_Users>(request);

                var login = new SYS_Logins()
                {
                    Email = request.Email,
                    Mobile = request.Mobile,
                    Pin = request.Pin,

                };
                mapper.Logins = login;

                await _unitOfWork.UserRepo.AddAsync(mapper);

                // await _unitOfWork.LoginRepo.AddAsync(loginMapper);
                await _unitOfWork.Save();
                var getUser = await this.GetUser(mapper.UserId);
                return await Task<ApiResponseModel>.FromResult(new ApiResponseModel()
                {
                    Data = getUser.Data,
                    Message = "Record Saved",
                    Succeeded = true,
                    HttpStatusCode = 200,
                });
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
