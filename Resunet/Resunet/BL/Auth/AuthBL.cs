 using System;
using Resunet.DAL.Models;
using Resunet.DAL;

namespace Resunet.BL.Auth{
	public class AuthBL :IAuthBL {
		private readonly IAuthDal authDal;
		private readonly IEncrypt encrypt;
		private readonly IHttpContextAccessor httpContextAccessor;
        public AuthBL(IAuthDal authDal, IEncrypt encrypt, IHttpContextAccessor httpContextAccessor)
		{
			this.authDal = authDal;
			this.encrypt = encrypt;
			this.httpContextAccessor = httpContextAccessor;
		}
	
		public async Task<int> CreateUser(UserModel user){
			user.Salt = Guid.NewGuid().ToString();
			user.Password = encrypt.HashPassword(user.Password, user.Salt);
			int id = await authDal.CreateUser(user);
			Login(id);
			return id;
		}
		public void Login(int id)
		{
			httpContextAccessor.HttpContext?.Session.SetInt32(AuthConstants.AUTH_SESSION_PARAM_NAME, id);
		}
        public async Task<int> Authenticate(string email, string password, bool rememberMe)
		{
			var user = await authDal.GetUser(email);
			if (user.Password == encrypt.HashPassword(password, user.Salt)){
				Login(user.UserId ?? 0); 
				return user.UserId ?? 0;
			}
			return 0;
			throw new Exception("NOT WORKING YET");
		}
    }
}

