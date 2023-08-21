using BMT_Utility;
using BMT_Web.Models;
using BMT_Web.Models.Dto;
using BMT_Web.Services.IServices;

namespace BMT_Web.Services
{
    public class ContactService : BaseService, IContactService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string contactUrl;

        public ContactService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            contactUrl = configuration.GetValue<string>("ServiceUrls:VillaAPI");

        }

        public Task<T> CreateAsync<T>(ContactCreateDTO dto, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = dto,
                Url = contactUrl + "/api/contactAPI",
                Token = token
            });
        }

        public Task<T> DeleteAsync<T>(int id, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = contactUrl + "/api/contactAPI/"+id,
                Token = token
            });
        }

        public Task<T> GetAllAsync<T>(string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = contactUrl + "/api/contactAPI",
                Token = token
            });
        }

        public Task<T> GetAsync<T>(int id, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = contactUrl + "/api/contactAPI/" + id,
                Token = token
            });
        }

        public Task<T> UpdateAsync<T>(ContactUpdateDTO dto, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = dto,
                Url = contactUrl + "/api/contactAPI/" + dto.Id,
                Token = token
            }) ;
        }
    }
}
