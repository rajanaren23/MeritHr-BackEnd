using CommonDataModel.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dawn.Services
{
    public class UserManagement : IUserManagement
    {
        private readonly IMongoCollection<UserRegistration> userdetails;


        public UserManagement(IMongoDbSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            userdetails = database.GetCollection<UserRegistration>(settings.CollectionName);
        }

        public List<UserRegistration> Get() =>
            userdetails.Find(user => true).ToList();

        public UserRegistration Get(string id) =>
           userdetails.Find<UserRegistration>(user => user.Id == id).FirstOrDefault();


        public UserRegistration Create(UserRegistration user)
        {
            try
            {
                userdetails.InsertOne(user);
            }
            catch (Exception ex)
            {

            }
            return user;
        }

        public void Update(string id, UserRegistration userIn) =>
            userdetails.ReplaceOne(user => user.Id == id, userIn);

        public void Remove(UserRegistration userIn) =>
            userdetails.DeleteOne(user => user.Id == userIn.Id);

        public void Remove(string id) =>
            userdetails.DeleteOne(user => user.Id == id);

    }
}
