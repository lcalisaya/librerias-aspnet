using AutoMapperLibrary.Models;

namespace AutoMapperLibrary.Repositories
{
    public interface ISingerRepository
    {
        Singer GetSinger();
        Singer GetModifiedSinger(Singer singer);
    }
}
