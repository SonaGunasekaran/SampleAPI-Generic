/*
 * Project:validating the API services and performing the operations like post,put,get,delete
 * Author:Sona G
 * Date:20/08/2021
 */
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System;
using System.Net;
namespace TestSampleAPIUsingGenerics
{
    [TestClass]
    public class TestSpotifyPlaylist
    {
        // the restclient as null
        RestClient client = null;
        RestClient client1 = null;
        private string myToken = null;
        private string user_id = "s27dmlg557v3itkvxtlfahdey";
        private string playlist_id = "5jHmGuLf7oR2n20SxeDBzb";
        [TestInitialize]
        //This method is calling evrytime to initialzie the restclient object
        public void SetUp()
        {
            client = new RestClient("https://api.spotify.com/v1/users/" + user_id + "/playlists");
            client1 = new RestClient("https://api.spotify.com/v1/playlists/" + playlist_id + "/tracks");
            myToken = "Bearer BQC5ABXThf6QXzyu3i1P79tiUxX7qT66vNFZ396GLJqlF2mqirJiVbXIByzarCyWfv2wBrHlcuvi9SiirsaUCwoJ1fNkmPtmEo6HyebQPuN8gIPY0AekdCC7rMG-1ho7SQgBQpKr3iv1kg6TBdDlTeB44JD4KT8i_p73xMxc0CwuwrANS5SKQAuQYXAGbWaTU1TlCt9n0pFbJEx4Lq0_NBo7QYwGavqgcn7P1iEYZrqgp_4I_a50V9lq_xqDYbOlQYUqEFp7zYPDLGrcQHJEm_ALgi1MNQ0oGIJZ4bE7";
        }
        public IRestResponse GetPlaylist()
        {
            //Get request
            RestRequest request = new RestRequest(Method.GET);
            //Passing the request and execute
            request.AddHeader("Authorization", "token" + myToken);
            IRestResponse response = client.Execute(request);
            //Return the response
            return response;
        }
        [TestMethod]
        public void TestGetPlaylist()
        {
            IRestResponse response = GetPlaylist();
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            if (response.IsSuccessful)
            {
                Console.WriteLine("Status Code:" + response.StatusCode);
                Console.WriteLine("Response: " + response.Content);
            }
        }
        public IRestResponse CreatePlaylist()
        {
            string JsonData = "{" +
                                  "\"name\": \"My Playlist 7\"," +
                                  "\"description\": \"New playlist description\"," +
                                  "\"public\":\" false\"" +
                              "}";
            RestRequest request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", "token" + myToken);
            request.AddJsonBody(JsonData);
            IRestResponse response = client.Execute(request);
            return response;
        }

        [TestMethod]
        public void TestCreatePlaylist()
        {
            IRestResponse response = CreatePlaylist();
            Assert.AreEqual(201, (int)response.StatusCode);
            if (response.IsSuccessful)
            {
                Console.WriteLine("Status Code:" + response.StatusCode);
                Console.WriteLine("Response: " + response.Content);
            }
        }
        public IRestResponse UpdatePlaylist()
        {
            string JsonData = "{" +
                                  "\"name\": \"Updated Playlist\"," +
                                  "\"description\": \"description\"," +
                                  "\"public\":\" false\"" +
                              "}";
            RestRequest request = new RestRequest(Method.PUT);
            request.AddHeader("Authorization", "token" + myToken);
            request.AddJsonBody(JsonData);
            IRestResponse response = client1.Execute(request);
            return response;
        }
        [TestMethod]
        public void TestUpdatePlaylist()
        {
            IRestResponse response = UpdatePlaylist();
            Assert.AreEqual(201, 204, (int)response.StatusCode);
            if (response.IsSuccessful)
            {
                Console.WriteLine("Status Code:" + response.StatusCode);
                Console.WriteLine("Response: " + response.Content);
            }
        }
        public IRestResponse DeletePlaylist()
        {
            //Get request
            RestRequest request = new RestRequest(Method.DELETE);
            //Passing the request and execute
            request.AddHeader("Authorization", "token" + myToken);
            IRestResponse response = client1.Execute(request);
            //Return the response
            return response;
        }
        [TestMethod]
        public void TestDeletePlaylist()
        {
            IRestResponse response = DeletePlaylist();
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            if (response.IsSuccessful)
            {
                Console.WriteLine("Status Code:" + response.StatusCode);
                Console.WriteLine("Response: " + response.Content);
            }
        }
    }
}
