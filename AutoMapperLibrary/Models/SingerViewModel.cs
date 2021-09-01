using System;

namespace AutoMapperLibrary.Models
{
    public class SingerViewModel
    {
        public int Id { get; set; }
        public DateTime BirthDay { get; set; }
        public string RealName { get; set; }
        public string ArtisticName { get; set; }
        public string Nationality { get; set; }
        public DateTime MotherBirthDay { get; set; }
        public string MotherFirstName { get; set; }
        public string MotherLastName { get; set; }
    }
}
