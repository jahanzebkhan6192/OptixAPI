using System.ComponentModel.DataAnnotations;

namespace OptixAPI.Controllers
{
    public class MovieData
    {
        [Required]
        public string movieName { get; set; }
        public string genrefilter { get; set; }
        [Required]
        [Range(0, 999999)]
        public int limit { get; set; }
        [Required]
        [Range(0, 999999)]
        public int PageSize { get; set; }
        [Required]
        [Range(0, 999999)]
        public int Page { get; set; }
    }
}