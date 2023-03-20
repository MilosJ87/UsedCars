using Newtonsoft.Json;
using UsedCars.Models;

namespace UsedCars.API.Services
{
    public class AdditionalEquip : IAdditionalEquip
    {
        private readonly HttpClient _client;

        public AdditionalEquip(IHttpClientFactory factory)
        {
            _client = factory.CreateClient("ArticleClient");
        }
        public async Task<bool> ArticleInInventory()
        {
            {
                using (HttpResponseMessage response =
                    await _client.GetAsync("api/equipment/{equipmentId}"))
                {
                    var hasArticle =
                        JsonConvert.DeserializeObject<bool>(response.Content.ReadAsStringAsync().Result);

                    return hasArticle;
                }
            }
        }



        public async Task<IEnumerable<AdditionalEquipmentDto>> GetAdditionalEquipment()
        {
            string url = $"/api/equipment";

            HttpResponseMessage response = await _client.GetAsync(url);

            IEnumerable<AdditionalEquipmentDto> article = null;

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                article = JsonConvert.DeserializeObject<IEnumerable<AdditionalEquipmentDto>>(result);
            }

            return article;

        }
    }
}
