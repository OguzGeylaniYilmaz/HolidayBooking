using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.DTOs.AnnouncementDtos;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Traversal.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AnnouncementController : Controller
    {
        private readonly IAnnouncementService _announcementService;
        private readonly IMapper _mapper;

        public AnnouncementController(IAnnouncementService announcementService, IMapper mapper)
        {
            _announcementService = announcementService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var values = _mapper.Map<List<AnnouncementListDto>>(_announcementService.GetAll());
            return View(values);
        }

        [HttpGet]
        public IActionResult AddAnnouncement()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAnnouncement(AddAnnouncementDto announcementDto)
        {
            if (ModelState.IsValid)
            {
                _announcementService.Add(new Announcement()
                {
                    Content = announcementDto.Content,
                    Title = announcementDto.Title,
                    Date = Convert.ToDateTime(DateTime.Now.ToShortDateString())
                });
                return RedirectToAction("Index");
            }
            return View(announcementDto);
        }

        [Route("{id}")]
        public IActionResult DeleteAnnouncement(int id)
        {
            var deletedId = _announcementService.GetById(id);
            _announcementService.Remove(deletedId);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateAnnouncement(int id)
        {
            var updatedId = _mapper.Map<UpdateAnnouncementDto>(_announcementService.GetById(id));
            return View(updatedId);
        }

        [HttpPost]
        public IActionResult UpdateAnnouncement(UpdateAnnouncementDto announcementDto)
        {
            if (ModelState.IsValid)
            {
                _announcementService.Edit(new Announcement()
                {
                    AnnouncementID = announcementDto.AnnouncementID,
                    Content = announcementDto.Content,
                    Title = announcementDto.Title,
                    Date = Convert.ToDateTime(DateTime.Now.ToShortDateString())
                });

                return RedirectToAction("Index");
            }
            return View(announcementDto);
        }
    }
}
