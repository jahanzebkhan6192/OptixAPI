namespace OptixAPI.Data;


/// <summary>
/// MovieRepository to retrieve data from a sql database
/// Note data can be accessed by using stored procs
/// Also to original Mymoviedb datafile int Id field was added as primary key 
/// </summary>
public class MovieRepository : IMovieRepository
{
    private OptixContext _dbContext;

    public MovieRepository(OptixContext dbontext)
    {
        _dbContext = dbontext;
    }

    public List<Mymoviedb> GetPaged(string movieName, string? genrefilter, int limit, int pageSize, int pageNumber)
    {
        if (string.IsNullOrWhiteSpace(genrefilter))
        {
            IQueryable<Mymoviedb> query = _dbContext.Mymoviedbs;

            return query.Where(x => x.Title.StartsWith(movieName))
                            .Take(limit)
                            .Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
        }
        else
        {
            return GetPagedFiltered(movieName, genrefilter, limit, pageSize, pageNumber);
        }

    }

    private List<Mymoviedb> GetPagedFiltered(string movieName, string genrefilter, int limit, int pageSize, int pageNumber)
    {
        string[] words = genrefilter.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
        IQueryable<Mymoviedb> query = _dbContext.Mymoviedbs;
        return query.Where(x => x.Title.StartsWith(movieName))
                          .Where(y => words.All(x => y.Genre.Contains(x)))
                          .Take(limit)
                          .Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
     
    }
}

