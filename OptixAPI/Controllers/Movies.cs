using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OptixAPI.Data;

namespace OptixAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieRepository _movieRepository;
        private readonly ILogger<MovieController> _logger;

        public MovieController(IMovieRepository movieRepository, ILogger<MovieController> logger)
        {
            _movieRepository = movieRepository;
            _logger = logger;
        }

        [HttpGet(Name = "GetMovie")]
        [ProducesResponseType<Mymoviedb>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(string movieName, string? genrefilter, int limit, int PageSize, int Page)
        {
            var movies = _movieRepository.GetPaged(movieName, genrefilter, limit, PageSize, Page);
            _logger.LogInformation("GetMovie called");
            return movies == null ? NotFound() : Ok(movies);
        }
    }
}
