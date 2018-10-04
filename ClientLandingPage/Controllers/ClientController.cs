using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ClientLandingPage.Entity;
using ClientLandingPage.ViewModels;
using AutoMapper;
using ClientLandingPage.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Http;

namespace ClientLandingPage.Controllers
{
    [Route("Client")]
    public class ClientController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        private DataContext _context;
        private readonly IMapper _map;
        private readonly IConfiguration _configuration;

        public ClientController(DataContext context, IMapper map, IConfiguration configuration)
        {
            _context = context;
            _map = map;
            _configuration = configuration;
        }


        [HttpPost("submit")]
        public IActionResult Submit(ClientSubmitViewModel clientVM)
        {
            
            if (!ModelState.IsValid)
            {
                return Json(BadRequest(ModelState));
            }

            try
            {
                //adding to database
                var clientRequest = _map.Map<Models.Client>(clientVM);
                _context.Add(clientRequest);
                _context.SaveChanges();

                if (clientVM.UploadFile == null || clientVM.UploadFile.Length == 0)
                    return Json(Content("file not selected"));

                var dir = _configuration.GetSection("Directory:ClientUploadFile").Value;

                var path = Path.Combine(dir, clientRequest.ClientId.ToString(), clientVM.UploadFile.FileName);

                Directory.CreateDirectory(Path.GetDirectoryName(path));

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    clientVM.UploadFile.CopyTo(stream);
                }

                clientRequest.UploadFile = clientRequest.ClientId.ToString() + "/" + clientRequest.UploadFile;
                _context.Update(clientRequest);
                _context.SaveChanges();

                return Json(StatusCode(201));
            }
            catch (Exception ex)
            {

                throw ex;
            }

            
        }
        
    }
}