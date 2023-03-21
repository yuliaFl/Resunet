using System;
using Resunet.DAL.Models;
namespace Resunet.DAL
{
	public interface IAuthDal
	{
		Task<UserModel> GetUser(string email);

        Task<UserModel> GetUser(int id);

		Task<int> CreateUser(UserModel model);
    }
}

