﻿using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using SEP3_Tier1.Models;
using Tier2.Data;

namespace Tier2.Network
{
    public class NetworkSocket : INetwork
    {
        private readonly TcpClient _tcpClient;
        private readonly NetworkStream stream;

        public NetworkSocket()
        {
            _tcpClient = new TcpClient("localhost:5003", 1236);
            stream = _tcpClient.GetStream();
        }


        public IList<string> GetBookSale()
        {
            //læs fra serveren
            string recieveStuff = JsonSerializer.Serialize(new Request
            {
                EnumRequest = EnumRequest.recieveProofOfConcept
            });
            byte[] recieveRequestSend = Encoding.ASCII.GetBytes(recieveStuff);
            stream.Write(recieveRequestSend, 0, recieveRequestSend.Length);
            
            byte[] fromServer = new byte[1024];
            int read = stream.Read(fromServer, 0, fromServer.Length);
            string recieved = Encoding.ASCII.GetString(fromServer, 0, read);
            List<string> jsonString = JsonSerializer.Deserialize<List<string>>(recieved);

            Console.WriteLine(jsonString);
            return jsonString;

        }


        public void UpdateBookSale(string helloWorld)
        {
            string request = JsonSerializer.Serialize(new Request
            {
                HelloWorld = helloWorld,
                EnumRequest = EnumRequest.sendProofOfConcept
            });
            
            byte[] sendStuffRequest = Encoding.ASCII.GetBytes(request);
            stream.Write(sendStuffRequest, 0, sendStuffRequest.Length);        
        }

        private Request WriteFromServer(string s)
        {
            var dataToServer = Encoding.ASCII.GetBytes(s);
            stream.Write(dataToServer, 0, dataToServer.Length);
            var fromServer = new byte[1024];
            var bytesRead = stream.Read(fromServer, 0, fromServer.Length);
            var response = Encoding.ASCII.GetString(fromServer, 0, bytesRead);
            Console.WriteLine(response);
            var requestT3 = JsonSerializer.Deserialize<Request>(response);
            return requestT3;
        }
       

        
    }
}