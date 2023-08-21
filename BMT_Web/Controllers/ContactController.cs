using AutoMapper;
using BMT_Utility;
using BMT_Web.Models;
using BMT_Web.Models.Dto;
using BMT_Web.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Reflection;

namespace BMT_Web.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;
        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        public async Task<IActionResult> IndexContact()
        {
            List<ContactDTO> list = new();

            var response = await _contactService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<ContactDTO>>(Convert.ToString(response.Result));
            }
            return View(list);
        }
        [Authorize(Roles ="admin")]
        public async Task<IActionResult> CreateContact()
        {
            return View();
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateContact(ContactCreateDTO model)
        {
            if (ModelState.IsValid)
            {

                var response = await _contactService.CreateAsync<APIResponse>(model, HttpContext.Session.GetString(SD.SessionToken));
                if (response != null && response.IsSuccess)
{
                    TempData["success"] = "Contact created successfully";
                    return RedirectToAction(nameof(IndexContact));
                }
            }
            TempData["error"] = "Error encountered.";
            return View(model);
        }
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateContact(int contactId)
{
            var response = await _contactService.GetAsync<APIResponse>(contactId, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                
                ContactDTO model = JsonConvert.DeserializeObject<ContactDTO>(Convert.ToString(response.Result));
                return View(_mapper.Map<ContactUpdateDTO>(model));
            }
            return NotFound();
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateContact(ContactUpdateDTO model)
        {
            if (ModelState.IsValid)
            {
                TempData["success"] = "Contact updated successfully";
                var response = await _contactService.UpdateAsync<APIResponse>(model, HttpContext.Session.GetString(SD.SessionToken));
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexContact));
                }
            }
            TempData["error"] = "Error encountered.";
            return View(model);
        }
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteContact(int contactId)
        {
            var response = await _contactService.GetAsync<APIResponse>(contactId, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                ContactDTO model = JsonConvert.DeserializeObject<ContactDTO>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteContact(ContactDTO model)
        {
            
                var response = await _contactService.DeleteAsync<APIResponse>(model.Id, HttpContext.Session.GetString(SD.SessionToken));
                if (response != null && response.IsSuccess)
                {
                TempData["success"] = "Contact deleted successfully";
                return RedirectToAction(nameof(IndexContact));
                }
            TempData["error"] = "Error encountered.";
            return View(model);
        }

    }
}
