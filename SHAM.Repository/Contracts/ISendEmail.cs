﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SHAM.Repository.Contracts
{
    public interface ISendEmail
    {
        void Send(string Subject, string Email, string Message);
    }
}
