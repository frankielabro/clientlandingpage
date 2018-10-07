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
        
        private DataContext _context;
        private readonly IMapper _map;
        private readonly IConfiguration _configuration;

        public ClientController(DataContext context, IMapper map, IConfiguration configuration)
        {
            _context = context;
            _map = map;
            _configuration = configuration;
        }


        [HttpPost("Submit")]
        public IActionResult Submit([FromBody] ClientSubmitViewModel clientVM)
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

                
                return Json(clientRequest);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        [HttpPut("Upload")]
        public IActionResult UploadFile(ClientUploadFileViewModel clientVM)
        {
            try
            {
                if (clientVM.UploadFile == null || clientVM.UploadFile.Length == 0)
                    return Json(Content("file not selected"));

                var dir = _configuration.GetSection("Directory:ClientUploadFile").Value;
                var clientRequest = _context.Client.FirstOrDefault(c => c.ClientId == clientVM.ClientId);

                var path = Path.Combine(dir, clientRequest.ClientId.ToString(), clientVM.UploadFile.FileName);

                Directory.CreateDirectory(Path.GetDirectoryName(path));

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    clientVM.UploadFile.CopyTo(stream);
                }

                clientRequest.UploadFile = clientRequest.ClientId.ToString() + "/" + clientVM.UploadFile.FileName;

                _context.Update(clientRequest);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }


            return Ok();
        }

        //[HttpPost("name")]
        //public IActionResult Trim(string name) {


        //    string[] splittedName = name.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);

        //    var initials = "";

        //    foreach (var word in splittedName)
        //    {
        //        initials += word.Substring(0, 1).ToUpper();

        //    }


        //    return Ok(initials);
        //}
        
    }
}