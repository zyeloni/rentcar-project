using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using RentCarDesktopApp.Model;

namespace RentCarDesktopApp.Core;

public class ApiAccessLayer<T> where T : IModel
{
    private String _Endpoint { get; set; }

    public ApiAccessLayer(string endpoint)
    {
        _Endpoint = Config.API_URL + endpoint;
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        using (HttpResponseMessage responseMessage = await ApiClient.HttpClient.GetAsync(_Endpoint + "/Get"))
        {
            if (!responseMessage.IsSuccessStatusCode)
                throw new Exception("Http Error Status Code | "
                                    + responseMessage.StatusCode + " | "
                                    + responseMessage.ReasonPhrase);

            var content = await responseMessage.Content.ReadAsAsync<IEnumerable<T>>();

            return content;
        }
    }

    public async Task<IEnumerable<T>> Delete(T t)
    {
        var uriBuilder = new UriBuilder(_Endpoint + "/Delete");
        var query = HttpUtility.ParseQueryString(uriBuilder.Query);
        query["Id"] = t.Id.ToString();
        uriBuilder.Query = query.ToString();
        string Endpoint = uriBuilder.ToString();

        using (HttpResponseMessage responseMessage = await ApiClient.HttpClient.GetAsync(Endpoint))
        {
            if (!responseMessage.IsSuccessStatusCode)
                throw new Exception("Http Error Status Code | "
                                    + responseMessage.StatusCode + " | "
                                    + responseMessage.ReasonPhrase);

            var content = await responseMessage.Content.ReadAsAsync<IEnumerable<T>>();

            return content;
        }
    }

    public async Task<T> Add(T t)
    {
        JsonContent objectContent = JsonContent.Create(t);

        using (HttpResponseMessage responseMessage =
               await ApiClient.HttpClient.PostAsync(_Endpoint + "/Add", objectContent))
        {
            if (!responseMessage.IsSuccessStatusCode)
                throw new Exception("Http Error Status Code | "
                                    + responseMessage.StatusCode + " | "
                                    + responseMessage.ReasonPhrase);

            var content = await responseMessage.Content.ReadAsAsync<T>();

            return content;
        }
    }

    public async Task<T> Edit(T t)
    {
        JsonContent objectContent = JsonContent.Create(t);

        using (HttpResponseMessage responseMessage =
               await ApiClient.HttpClient.PostAsync(_Endpoint + "/Edit", objectContent))
        {
            if (!responseMessage.IsSuccessStatusCode)
                throw new Exception("Http Error Status Code | "
                                    + responseMessage.StatusCode + " | "
                                    + responseMessage.ReasonPhrase);

            var content = await responseMessage.Content.ReadAsAsync<T>();

            return content;
        }
    }
}