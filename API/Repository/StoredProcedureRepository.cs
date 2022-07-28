using API.Data;
using API.Entities;

namespace API.Repository
{
    public class StoredProcedureRepository : IRepository<StoredProcedure>
    {
        private readonly DataDbContext _context;

        public StoredProcedureRepository(DataDbContext context)
        {
            _context = context;
        }

        public Guid Add(StoredProcedure storedProcedure)
        {
            _context.Add(storedProcedure);
            _context.SaveChanges();
            return storedProcedure.StoredProcedureId;
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public StoredProcedure Get(Guid id)
        {
            return _context.StoredProcedure.FirstOrDefault(sp => sp.StoredProcedureId == id);
        }

        public IList<StoredProcedure> GetAll()
        {
            return _context.StoredProcedure.ToList();
        }

        public void Update(StoredProcedure entity)
        {
            _context.StoredProcedure.Update(entity);
            _context.SaveChanges();
        }
    }
}
