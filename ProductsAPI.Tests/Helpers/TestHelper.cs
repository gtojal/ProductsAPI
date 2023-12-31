﻿using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ProductsAPI.Tests.Helpers
{
    public static class TestHelper
    {
        /// <summary>
        /// Método para criar um client http da api de produtos
        /// </summary>
        public static HttpClient CreateClient
        {
            get
            {
                var accessToken = @"eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoie1wiSWRcIjpcIjQ0ZGFhNjdiLTc3YzMtNGMxOC1iNjc1LTg3MjYwYThiNDQ3Y1wiLFwiTmFtZVwiOlwiU2VyZ2lvIE1lbmRlc1wiLFwiRW1haWxcIjpcInNlcmdpby5jb3RpQHVvbC5jb21cIixcIlJvbGVcIjpcIlVTRVJfUk9MRVwiLFwiU2lnbmVkQXRcIjpcIjIwMjMtMDctMjZUMTk6MjU6NDAuNjk1OTM5NC0wMzowMFwifSIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IlVTRVJfUk9MRSIsImV4cCI6MTY5MDQxMTI0MCwiaXNzIjoidXNlcnNhcHAiLCJhdWQiOiIqIn0.9vS6HHtBz2rxCL5cfkNu4VC7HQFFccKU0lmTuwti1NM";
                var auth = new AuthenticationHeaderValue("Bearer", accessToken);

                var client = new WebApplicationFactory<Program>().CreateClient();
                client.DefaultRequestHeaders.Authorization = auth;

                return client;
            }
        }

        /// <summary>
        /// Método para serializar o conteudo da requisição que será enviada para um serviço
        /// </summary>
        public static StringContent CreateContent<TRequest>(TRequest request)
            => new StringContent(JsonConvert.SerializeObject(request),
                Encoding.UTF8, "application/json");

        /// <summary>
        /// Método para deserializar o retorno obtido pela execução de um serviço
        /// </summary>
        public static TResponse ReadResponse<TResponse>(HttpResponseMessage message)
            => JsonConvert.DeserializeObject<TResponse>(message.Content.ReadAsStringAsync().Result);
    }
}
