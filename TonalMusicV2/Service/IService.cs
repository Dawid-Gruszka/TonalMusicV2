namespace TonalMusicV2.Service
{
    internal interface IService<T>
    {
        public Task<List<T>> GetAll();

        public Task<T> GetById(int id);

    }
}
