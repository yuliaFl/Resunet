 using System;
using Resunet.DAL.Models;
using Resunet.DAL;

namespace Resunet.BL.Auth{
	public class AuthBL :IAuthBL {
		private readonly IAuthDal authDal;
		private readonly IEncrypt encrypt;

		public AuthBL(IAuthDal authDal, IEncrypt encrypt)
		{
			this.authDal = authDal;
			this.encrypt = encrypt;
		}
	
		public async Task<int> CreateUser(UserModel user){
			user.Salt = Guid.NewGuid().ToString();
			user.Password = encrypt.HashPassword(user.Password, user.Salt);
			return await authDal.CreateUser(user);
		}
	}
}

