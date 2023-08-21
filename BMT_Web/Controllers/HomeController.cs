using AutoMapper;
using BMT_Utility;
using BMT_Web.Models;
using BMT_Web.Models.Dto;
using BMT_Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace BMT_Web.Controllers
{
    public class HomeController : Controller
    {

        public async Task<IActionResult> Index()
        {
            return View();
        }
       
    }
}