using Newtonsoft.Json;
using PangeaPracticum.lib.Domain;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace PangeaPracticum.lib
{
    public interface IRepoLoader
    {
        Repo[] LoadRepos();
    }

    public class GitHubHttpClient : IRepoLoader
    {
        public Repo[] LoadRepos()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.github.com/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("User-Agent", "Max4PangeaTestApp");
                var result = client.GetAsync("/orgs/gopangea/repos").Result;
                return JsonConvert.DeserializeObject<Repo[]>(result.Content.ReadAsStringAsync().Result);
            }
        }
    }
}
