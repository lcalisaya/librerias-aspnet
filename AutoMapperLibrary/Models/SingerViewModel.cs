using System;

namespace AutoMapperLibrary.Models
{
    public class SingerViewModel
    {
        public int Id { get; set; }
        public DateTime BirthDay { get; set; }
        public string RealName { get; set; }
        public string FamousName { get; set; }
        public string Nationality { get; set; }
    }
}
