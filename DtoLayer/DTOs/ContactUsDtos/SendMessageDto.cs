using System;

namespace DtoLayer.DTOs.ContactUsDtos
{
    public class SendMessageDto
    {
        public int ContactUsID { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Subject { get; set; }
        public string MessageBody { get; set; }
        public DateTime Date { get; set; }
    }
}
