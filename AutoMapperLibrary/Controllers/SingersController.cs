using AutoMapper;
using AutoMapperLibrary.Models;
using AutoMapperLibrary.Services;
using Microsoft.AspNetCore.Mvc;

namespace AutoMapperLibrary.Controllers
{
    public class SingersController : Controller
    {
        private readonly ISingerService _service;
        private readonly IMapper _mapper;
        public SingersController(ISingerService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Details()
        {
            SingerViewModel singer = _service.GetSinger();
            return View(singer);
        }
    }
}
