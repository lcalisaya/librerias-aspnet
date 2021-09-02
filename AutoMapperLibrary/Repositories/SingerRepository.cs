﻿using AutoMapperLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMapperLibrary.Repositories
{
    public class SingerRepository : ISingerRepository
    {
        public Singer GetModifiedSinger(Singer singer)
        {
            var modifiedSinger = new Singer();
            modifiedSinger.FamousName = singer.FamousName + " modified";
            modifiedSinger.RealName = singer.RealName + " modified";
            modifiedSinger.Nationality = singer.Nationality + " modified";

            return modifiedSinger;
        }

        public Singer GetSinger()
        {
            return new Singer(){
                Id = 1,
                Nationality = "Estadounidense",
                BirthDay = new DateTime(1935, 1, 8),
                RealName = "Elvis Aaron Presley",
                FamousName = "Elvis Presley", 
                Mother = new Mother() { 
                    BirthDay = new DateTime(1912, 4, 25),
                    FirstName = "Gladys",
                    LastName = "Presley"
                }
            };
        }
    }
}
