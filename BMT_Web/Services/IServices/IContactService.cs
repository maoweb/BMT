﻿using BMT_Web.Models.Dto;

namespace BMT_Web.Services.IServices
{
    public interface IContactService
    {
        Task<T> GetAllAsync<T>(string token);
        Task<T> GetAsync<T>(int id, string token);
        Task<T> CreateAsync<T>(ContactCreateDTO dto, string token);
        Task<T> UpdateAsync<T>(ContactUpdateDTO dto, string token);
        Task<T> DeleteAsync<T>(int id, string token);
    }
}
