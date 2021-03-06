﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using NUnit.Framework;

namespace MiniRest.NetCore.Test
{
    [TestFixture]
    public class RestRequestTests
    {
        [Test]
        public void Get()
        {
            IRestRequest request = new RestRequest("http://localhost:3508");
            request.AddPath("/api/test");
            request.AddContentType("application/json");
            request.AddDataFormat(DataFormat.Json);
            request.AddMethod(Method.GET);
            IRestClient client = new RestClient(request);
            var response = client.Execute<object>();
            Assert.IsTrue(response.StatusCode == HttpStatusCode.OK);
        }

        [Test]
        public void Post()
        {
            IRestRequest request = new RestRequest("http://localhost:3508");
            request.AddPath("/api/gateway");
            request.AddContentType("application/json");
            request.AddDataFormat(DataFormat.Json);
            request.AddMethod(Method.POST);
            request.AddBody("Request Post body data");
            IRestClient client = new RestClient(request);
            var response = client.Execute<object>();
        }
    }
}
