using System;
namespace Resunet.BL.Auth
{
	public interface IEncrypt
	{
		string HashPassword(string password, string salt);
	}
}

