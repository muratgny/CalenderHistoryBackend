using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        internal static string UserRegistered;
        internal static User UserNotFound;
        internal static User PasswordError;
        internal static string SuccessfulLogin;
        internal static string UserAlreadyExists;
        internal static string AccessTokenCreated;

        public static string OperationClaimExists => "OperationClaimExists";
        public static string AuthorizationsDenied => "AuthorizationsDenied";
        public static string Added => "Added";
        public static string Deleted => "Deleted";
        public static string Updated => "Updated";
        public static string NameAlreadyExist => "NameAlreadyExist";
        public static string TokenProviderException => "TokenProviderException";
        public static string Unknown => "Unknown";
    }
}
