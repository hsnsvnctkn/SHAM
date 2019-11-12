using SAM.Repository;
using SHAM.Domain.Entities;
using SHAM.Repository.Contracts;
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

        public List<Title> GetList()
        {
          return  _context.Titles.Select(x => new Title { ID = x.ID, TITLE_NAME = x.TITLE_NAME }).ToList();
        }
    }
}
