using SHAM.Domain.Entities;
using SHAM.Repository.Dto;
using System.Collections.Generic;

namespace SHAM.Repository.Contracts
{
    public interface ITitleRepository : IGenericRepository<Title>
    {
        Title Get(int id);

        List<TitleDto> GetList();

        void DeleteTitle(Title title);
        void Create(TitleDto title);
        void Update(TitleDto title);
    }
}
