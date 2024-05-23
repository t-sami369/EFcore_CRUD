namespace EFcore_CRUD.Repositories
{
    public interface IRepository<T>
    {
        public void AddRecord(T model);

        public IEnumerable<T> GetAllRecords();

        public T GetSingleRecord(int id);

        public T UpdateRecord(T model);

        public T DeleteRecord(T model);
    }
}
