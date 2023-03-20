using System;
using Resunet.DAL.Models;
namespace Resunet.DAL.Auth
{
	public interface IAUTHDal
	{
		Task<UserModel> GetUser(string email);

        Task<UserModel> GetUser(int id);

		Task<int> CreateUser(UserModel model);
    }
}

