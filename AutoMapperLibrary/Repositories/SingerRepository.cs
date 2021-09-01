using AutoMapperLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMapperLibrary.Repositories
{
    public class SingerRepository : ISingerRepository
    {
        public Singer GetSinger()
        {
            return new Singer(){
                Id = 1,
                Nationality = "Estadounidense",
                BirthDay = new DateTime(1935, 1, 8),
                RealName = "Elvis Aaron Presley",
                FamousName = "Elvis Presley"
            };
        }
    }
}
