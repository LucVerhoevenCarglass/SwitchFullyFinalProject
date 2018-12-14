using System;
using System.Collections.Generic;
using System.Text;

namespace Swintake.Integration.tests
{
   public class AuthenticationMiddleware
    {
        public const string FakeJWTAuthentication = "FakeAuthentication";
        public const string TestingHeader = "Authorization";
        public const string TestingHeaderValue = "X-Integration-Test";
    }
}
