namespace OptixAPI.Data
{
    public interface IMovieRepository
    {
        public Task<List<Mymoviedb>> GetPagedAsync(string movieName, string filter, int limit, int pageSize, int pageNumber);
    }
}