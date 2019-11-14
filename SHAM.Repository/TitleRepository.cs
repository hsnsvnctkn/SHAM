using SAM.Repository;
using SHAM.Domain.Entities;
using SHAM.Repository.Contracts;
using SHAM.Repository.Dto;
using System.Collections.Generic;
using System.Linq;

namespace SHAM.Repository
{
    public class TitleRepository : GenericRepository<Title>, ITitleRepository
    {
        public TitleRepository(IUnitOfWork uow)
            : base(uow)
        {

        }

        public List<TitleDto> GetList()
        {
            return _context.Titles.Select(t => new TitleDto { ID = t.ID, NAME = t.TITLE_NAME }).ToList();
        }
        public void DeleteTitle(TitleDto t)
        {
            Title title = new Title { ID = t.ID, TITLE_NAME = t.NAME };
            _context.Titles.Remove(title);
            _context.SaveChanges();
        }


        public TitleDto Get(int id)
        {
            var t = _context.Titles.FirstOrDefault(t => t.ID == id);
            return new TitleDto { ID = t.ID, NAME = t.TITLE_NAME };
        }

        public void Create(TitleDto title)
        {
            _context.Titles.Add(new Title { ID = title.ID, TITLE_NAME = title.NAME });
            _context.SaveChanges();
        }

        public void Update(TitleDto title)
        {
            _context.Titles.Update(new Title {ID=title.ID, TITLE_NAME = title.NAME });
            _context.SaveChanges();
        }
    }
}
