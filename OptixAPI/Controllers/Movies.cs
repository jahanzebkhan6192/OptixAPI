using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OptixAPI.Data;

namespace OptixAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieRepository _movieRepository;
        private readonly ILogger<MovieController> _logger;

        public MovieController(IMovieRepository movieRepository, ILogger<MovieController> logger)
        {
            _movieRepository = movieRepository;
            _logger = logger;
        }

        [HttpGet]
        [ActionName("GetMovie")]
        [ProducesResponseType<Mymoviedb>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType<string>(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAsync(string movieName, string? genrefilter, int limit, int PageSize, int Page)
        {
            try
            {
                var movies = await _movieRepository.GetPagedAsync(movieName, genrefilter, limit, PageSize, Page);
                _logger.LogInformation("GetMovie called");
                return movies == null ? NotFound() : Ok(movies);
             }
             catch (Exception ex)
             {
                 _logger.LogError(ex, "Failed to do stuff in OptixAPI.Controllers GetAsync");
                return BadRequest("Internal Server Error");
             }
        }

        [HttpGet]
        [ActionName("GetMovie2")]
        [ProducesResponseType<Mymoviedb>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAsync2([FromBody] MovieData md)
        {
            try
            {
                var movies = await _movieRepository.GetPagedAsync(md.movieName, md.genrefilter, md.limit, md.PageSize, md.Page);
                _logger.LogInformation("GetMovie called");
                return movies == null ? NotFound() : Ok(movies);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to do stuff in OptixAPI.Controllers GetAsync");
                return BadRequest("Internal Server Error");
            }
        }
    }
}
