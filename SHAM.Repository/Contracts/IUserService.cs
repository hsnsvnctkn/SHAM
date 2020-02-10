using System;
using System.Collections.Generic;
using System.Text;

namespace SHAM.Repository.Contracts
{
    public interface IUserService
    {
        (string username, string token)? Authenticate(string username, string password);
    }
}
