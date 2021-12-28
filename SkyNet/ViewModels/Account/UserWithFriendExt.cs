using SkyNet.Models.Users;

namespace SkyNet.ViewModels.Account;

public class UserWithFriendExt : User
{
    public bool IsFriendWithCurrent { get; set; }
}