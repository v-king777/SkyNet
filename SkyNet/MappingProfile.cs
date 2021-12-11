using AutoMapper;
using SkyNet.Models.Users;
using SkyNet.ViewModels.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                    expression.MapFrom(model => model.EmailReg));
            CreateMap<LoginViewModel, User>();
        }
    }
}