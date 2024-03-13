namespace OptixAPI.Data
{
    public interface IMovieRepository
    {
        public List<Mymoviedb> GetPaged(string movieName, string filter, int limit, int pageSize, int pageNumber);
    }
}