using SHAM.Domain.Entities;
using SHAM.Repository.Dto;
using System.Collections.Generic;

namespace SHAM.Repository.Contracts
{
    public interface ITitleRepository : IGenericRepository<Title>
    {
        TitleDto Get(int id);

        List<TitleDto> GetList();

        void DeleteTitle(TitleDto title);
        void Create(TitleDto title);
        void Update(TitleDto title);
    }
}
