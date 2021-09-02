using AutoMapperLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMapperLibrary.Services
{
    public interface ISingerService
    {
        SingerViewModel GetSinger();
        SingerViewModel GetModifiedSinger(SingerViewModel singer);
    }
}
