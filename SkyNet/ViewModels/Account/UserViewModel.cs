using System.Collections.Generic;
using SkyNet.Models.Users;

namespace SkyNet.ViewModels.Account;

public class UserViewModel
{
    public UserViewModel(User user)
    {
        User = user;
    }
    
    public User User { get; set; }

    public List<User> Friends { get; set; }
}