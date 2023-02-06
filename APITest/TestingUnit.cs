using Api;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReqresTest;
using RestSharp;
using System;

namespace APITest
{

    [TestClass]
    public class TestingUnit
    {
        requests requestAddress = new requests();

        [TestMethod]
        public void VerifyListOfUsers()
        {
            var allUsers = new APIController <UsersDTO>();

            var URL = allUsers.ConstructURL(requestAddress.getUsers);
            var client = allUsers.MakeClient(URL);
            var request = allUsers.MakeGRequest();
            var response = allUsers.GetResponse(client, request);
            UsersDTO content = allUsers.GetContent<UsersDTO>(response);
            
            Assert.AreEqual(2, content.Page);
            Assert.AreEqual("Michael", content.Data[0].First_Name);


        }

        [TestMethod]
        public void addUser ()
        {
            string Body = @"{""name"": ""morpheus"",""job"": ""leader""}";
            var addUser = new APIController <AddUser>();
            var URL = addUser.ConstructURL(requestAddress.addUser);
            var client = addUser.MakeClient(URL);
            var request = addUser.MakePostRequest(Body);
            var response = addUser.GetResponse(client, request);
            AddUser content = addUser.GetContent<AddUser>(response);

            Assert.AreEqual("morpheus", content.Name);
            Assert.AreEqual("leader", content.Job);



        }
    }
}
