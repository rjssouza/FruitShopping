using Microsoft.AspNetCore.Http;
using System;

namespace Core.Utils
{
    public class UserFactory
    {
        public Func<string> _getUser;
    }
}