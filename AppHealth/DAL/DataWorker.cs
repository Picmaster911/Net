namespace DAL
{
    public class DataWorker
    {
        private readonly AppDbContext _appDbContext;
        public DataWorker(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
    }
}
