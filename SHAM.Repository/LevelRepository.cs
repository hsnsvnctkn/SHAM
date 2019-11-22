using SHAM.Domain.Entities;
using SHAM.Repository.Contracts;
using SHAM.Repository.Dto;
using System.Collections.Generic;
using System.Linq;

namespace SHAM.Repository
{
    public class LevelRepository : GenericRepository<Level>, ILevelRepository
    {
        public LevelRepository(IUnitOfWork uow)
            : base(uow)
        {

        }
        public List<ConstantDto> GetList()
        {
            return _context.Levels.Select(p => new ConstantDto { ID = p.ID, NAME = p.LEVEL_NAME }).ToList();
        }
        public ConstantDto Get(int id)
        {
            var level = _context.Levels.FirstOrDefault(t => t.ID == id);
            return new ConstantDto { ID = level.ID, NAME = level.LEVEL_NAME };
        }
        public void DeleteLevel(int id)
        {
            var level = _context.Levels.FirstOrDefault(level => level.ID == id);
            _context.Levels.Remove(level);
            _context.SaveChanges();
        }

        public void Create(ConstantDto level)
        {
            _context.Levels.Add(new Level { ID = level.ID, LEVEL_NAME = level.NAME });
            _context.SaveChanges();
        }

        public void Update(ConstantDto level)
        {
            _context.Levels.Update(new Level { ID = level.ID, LEVEL_NAME = level.NAME });
            _context.SaveChanges();
        }
    }
}
