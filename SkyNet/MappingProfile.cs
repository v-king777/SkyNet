using AutoMapper;
using SkyNet.Models.Users;
using SkyNet.ViewModels.Account;
using System;

namespace SkyNet
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterViewModel, User>()
                .ForMember(user => user.BirthDate, expression => 
                    expression.MapFrom(model => 
                        new DateTime((int)model.Year, (int)model.Month, (int)model.Date)))
                .ForMember(user => user.UserName, expression => 
                    expression.MapFrom(model => model.EmailReg))
                .ForMember(user => user.Email, expression => 
                    expression.MapFrom(model => model.EmailReg));
            
            CreateMap<LoginViewModel, User>();
            
            CreateMap<UserEditViewModel, User>();
            
            CreateMap<User, UserEditViewModel>()
                .ForMember(model=>model.UserId, expression => 
                    expression.MapFrom(user => user.Id));

            CreateMap<UserWithFriendExt, User>();
            
            CreateMap<User, UserWithFriendExt>();
        }
    }
}