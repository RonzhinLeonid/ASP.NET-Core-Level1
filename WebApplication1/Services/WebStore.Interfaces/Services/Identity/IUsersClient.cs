﻿using DataLayer.Identity;
using Microsoft.AspNetCore.Identity;

namespace WebStore.Interfaces.Services.Identity
{
    public interface IUsersClient :
    IUserRoleStore<User>,
    IUserPasswordStore<User>,
    IUserEmailStore<User>,
    IUserPhoneNumberStore<User>,
    IUserTwoFactorStore<User>,
    IUserLoginStore<User>,
    IUserClaimStore<User>
    {

    }
}