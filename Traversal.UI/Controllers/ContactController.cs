using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.DTOs.ContactUsDtos;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Traversal.UI.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {

        private readonly IContactUsService _contactUsService;
        private readonly IMapper _mapper;
        public ContactController(IContactUsService contactUsService, IMapper mapper)
        {
            _contactUsService = contactUsService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(SendMessageDto messageDto)
        {
            if (ModelState.IsValid)
            {
                _contactUsService.Add(new ContactUs
                {
                    Name = messageDto.Name,
                    Mail = messageDto.Mail,
                    Subject = messageDto.Subject,
                    MessageBody = messageDto.MessageBody,
                    Date = Convert.ToDateTime(DateTime.Now.ToString())
                   
                });

                return RedirectToAction("Index", "Home");
            }

            return View(messageDto);
        }
    }
}
