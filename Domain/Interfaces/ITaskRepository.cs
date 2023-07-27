using Domain.Entities;
using Domain.Entities.Enum;

namespace Domain.Interfaces
{
    public interface ITaskRepository
    {
        Task<TaskEntity> GetByIdAsync(int id);
        Task<List<TaskEntity>> GetAllAsync();
        Task<List<TaskEntity>> ListByStatus(StatusEnum status);
        Task<int> Create(TaskEntity taskEntity);
        Task Update(TaskEntity taskEntity);
        Task Delete(int id);
    }
}
