using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Exception;
using Login.DTO.impl;
using Login.Factory;
using Newtonsoft.Json;
using UniRx;
using UnityEngine;


namespace Login.DAO.impl
{
    public class PlayerDao : IPlayerDao
    {
        private string _baseUrl = "https://topictwisterequipocinco.herokuapp.com/player/";

        private HttpClient _httpClient;
        private IDtosFactory _dtosFactory;

        public PlayerDao(HttpClient httpClient, IDtosFactory dtosFactory)
        {
            _httpClient = httpClient;
            _dtosFactory = dtosFactory;
        }
        
        public string BaseUrl
        {
            get { return _baseUrl; }
            set { _baseUrl = value; }
        }
        
        public async Task<PlayerDto> LoginPlayer(string nickName)
        {
            // construyo mi logindto
            var loginDto = _dtosFactory.CreateLoginDto(nickName);
            
            // CONSTRUIMOS LA URL DE LA ACCIÓN
            var urlBuilder = new StringBuilder();
            urlBuilder.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "")
                       .Append("login/nickname");
            var url = urlBuilder.ToString();

            // RECUPERAMOS EL HttpClient
            var client = _httpClient;

            try
            {                
                using (var request = new HttpRequestMessage())
                {
                    ///////////////////////////////////////
                    // CONSTRUIMOS LA PETICIÓN (REQUEST) //
                    ///////////////////////////////////////
                    // DEFINIMOS EL Content CON EL OBJETO A ENVIAR SERIALIZADO.
                    request.Content = new StringContent(JsonConvert.SerializeObject(loginDto));

                    // DEFINIMOS EL ContentType, EN ESTE CASO ES "application/json"
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                    // DEFINIMOS EL MÉTODO HTTP
                    request.Method = new HttpMethod("POST");

                    // DEFINIMOS LA URI
                    request.RequestUri = new Uri(url, System.UriKind.RelativeOrAbsolute);

                    // DEFINIMOS EL Accept, EN ESTE CASO ES "application/json"
                    request.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));

                    /////////////////////////////////////////
                    // CONSTRUIMOS LA RESPUESTA (RESPONSE) //
                    /////////////////////////////////////////
                    // Utilizamos ConfigureAwait(false) para evitar el DeadLock.
                    var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);

                    // OBTENEMOS EL Content DEL RESPONSE como un String
                    // Utilizamos ConfigureAwait(false) para evitar el DeadLock.
                    var responseText = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                    // SI ES LA RESPUESTA ESPERADA !! ...
                    if (response.StatusCode == System.Net.HttpStatusCode.OK) // 200
                    {
                        // DESERIALIZAMOS Content DEL RESPONSE
                        var responseBody = JsonConvert.DeserializeObject<PlayerDto>(responseText);
                        return responseBody;
                    }
                    else
                    // SI NO SE ESTÁ AUTORIZADO ...
                    if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized) // 401
                    {
                        throw new System.Exception("401 Unauthorized. Las credenciales de acceso del usuario son incorrectas. " +
                                                   responseText);
                    }
                    else
                    // CUALQUIER OTRA RESPUESTA ...
                    if (response.StatusCode != System.Net.HttpStatusCode.OK && // 200
                        response.StatusCode != System.Net.HttpStatusCode.NoContent) // 204
                    {
                        throw new System.Exception((int)response.StatusCode + ". No se esperaba el código de estado HTTP de la respuesta. " +
                                                   responseText);
                    }

                    // RETORNAMOS EL OBJETO POR DEFECTO ESPERADO
                    return default;
                }
            }
            finally
            {
                // NO UTILIZAMOS CATCH, 
                // PASAMOS LA EXCEPCIÓN A LA APP.
            }
        }
        }


        /*public Task<PlayerDto> GetPlayer(string playerID)
        {
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(
                LoginURL + playerID);
            HttpWebResponse response = (HttpWebResponse) request.GetResponse();
            
            StreamReader reader = new StreamReader(response.GetResponseStream());
            var json = reader.ReadToEnd();

            return JsonUtility.FromJson<PlayerDto>(json);
        }

        public async Task<PlayerDto> GetPlayer(string nickName)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, nickName);
            request.Headers.TryAddWithoutValidation("some-header", "some-value");

            var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);

            if (response.IsSuccessStatusCode)
            {
                // perhaps check some headers before deserialising

                try
                {
                    return await response.Content.ReadAsStreamAsync<PlayerDto>();
                }
                catch (NotSupportedException) // When content type is not valid
                {
                    Console.WriteLine("The content type is not supported.");
                }
                catch (JsonException) // Invalid JSON
                {
                    Console.WriteLine("Invalid JSON.");
                }
            }

            return null;
        }
        
        private static async Task PostJsonContent(string uri, HttpClient httpClient)
        {
            var postUser = new User { Name = "Steve Gordon" };

            var postRequest = new HttpRequestMessage(HttpMethod.Post, uri)
            {
                Content = JsonContent.Create(postUser)
            };

            var postResponse = await httpClient.SendAsync(postRequest);

            postResponse.EnsureSuccessStatusCode();
        }*/

        
    
}