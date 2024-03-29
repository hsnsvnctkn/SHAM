﻿using SHAM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SHAM.Repository.Contracts
{
    public interface ITokenProvider : IGenericRepository<Employee>
    {
        public string LoginUser(string Email, string Password);
        public string EncryptString(string plainText);
        public string DecryptString(string cipherText);

    }
}
