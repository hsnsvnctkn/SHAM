using SHAM.Domain.Entities;
using SHAM.Repository.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace SHAM.Repository.Contracts
{
    public interface INotificationRepository : IGenericRepository<Notification>
    {
        List<NotificationDto> GetList();
        NotificationDto Get(int id);
        void Delete(int id);
        void Create(NotificationDto notifi);
        void Update(NotificationDto notifi);
    }
}
