using System;

namespace DtoLayer.DTOs.AnnouncementDtos
{
    public class UpdateAnnouncementDto
    {
        public int AnnouncementID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
    }
}