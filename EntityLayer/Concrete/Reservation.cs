﻿using System;

namespace EntityLayer.Concrete
{
    public class Reservation
    {
        public int ReservationID { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public string PersonCount { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public int DestinationID { get; set; }
        public Destination Destination { get; set; }
    }
}
