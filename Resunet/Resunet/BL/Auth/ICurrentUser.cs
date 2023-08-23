using System;
namespace Resunet.BL.Auth{
    public interface ICurrentUser
    {
        bool IsLoggedIn(); 
    }
}