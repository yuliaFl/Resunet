 using System;
using Resunet.DAL.Models;
using Resunet.DAL;

namespace Resunet.BL.Auth{
	public class AuthBL :IAuthBL {
		private readonly IAuthDal authDal;

		public AuthBL(IAuthDal authDal)
		{
			this.authDal = authDal; 
		}
	
		public async Task<int> CreateUser(UserModel user){
			return await authDal.CreateUser(user);
		}
	}
}

