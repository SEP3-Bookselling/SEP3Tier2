﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Tier2.Data.Network;

namespace Tier2.Data.User
{
    public class UserService : IUserService
    { 
        
        private readonly INetwork DBConn;
        private Models.Customer customerToSend;
        private Models.User userToSend;

        public UserService()
        {
            DBConn = new NetworkSocket();
        }
        

        public async Task<Models.Customer> CreateCustomerAsync(Models.Customer customer)
        {
            DBConn.CreateCustomer(customer);
            return customer;
        }


        public async Task<Models.User> CreateUserAsync(Models.User user)
        {
            DBConn.CreateUserAsync(user);
            return user;
        }

        public async Task<IList<Models.User>> GetUserListAsync(string username)
        {
            return await DBConn.GetUserListAsync(username);
        }
        
        public async Task<User> GetSpecificUserLoginAsync(string username, string password)
        {
            return await DBConn.GetSpecificUserLoginAsync(username, password);
        }

        public async Task UpdateUserAsync(User user)
        {
            DBConn.UpdateUser(user);
        }

        public async Task DeleteUser(string username)
        {
            DBConn.DeleteUser(username);
        }
    }
}