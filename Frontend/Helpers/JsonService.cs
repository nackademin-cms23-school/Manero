using Newtonsoft.Json;

namespace Frontend.Helpers;

public class JsonService
{
    public static async Task<T> DeserializeToModelAsync<T>(HttpResponseMessage response)
    {
        string content = await response.Content.ReadAsStringAsync();
        T? obj = JsonConvert.DeserializeObject<T>(content);
        if (obj != null)
        {
            return obj;
        }
        return default!;
    }
}
