using AutoMapper;
using AutoMapperLibrary.Models;
using AutoMapperLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMapperLibrary.Services
{
    public class SingerService : ISingerService
    {
        private readonly ISingerRepository _repository;
        private readonly IMapper _mapper;
        public SingerService(ISingerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public SingerViewModel GetModifiedSinger(SingerViewModel singer)
        {

            Singer singerDDBB = _mapper.Map<Singer>(singer);
            var modifiedSinger = _repository.GetModifiedSinger(singerDDBB);
            SingerViewModel singerToTheView = _mapper.Map<SingerViewModel>(modifiedSinger);
            return singerToTheView;
        }

        public SingerViewModel GetSinger()
        {
            var singer = _repository.GetSinger();
            return _mapper.Map<SingerViewModel>(singer);
            //return new SingerViewModel() { 
            //    Id = singer.Id,
            //    Nationality = singer.Nationality,
            //    BirthDay = singer.BirthDay,
            //    RealName = singer.RealName,
            //    FamousName = singer.FamousName
            //};
        }

        
    }
}
