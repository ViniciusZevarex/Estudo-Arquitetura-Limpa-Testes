using Application.DTO;
using Domain.Entities.Enum;

namespace Application.Services.Interface
{
    public interface ITaskService
    {
        Task<List<TaskQueryDTO>> ListAll();
        Task<List<TaskQueryDTO>> ListByStatus(StatusEnum status);
        Task<TaskQueryDTO> GetTaskById(int id);


        Task<TaskQueryDTO> Create(TaskCommandDTO taskCreateDTO);
        Task<TaskQueryDTO> Update(TaskCommandDTO taskCreateDTO);
        Task<TaskQueryDTO> ChangeStatus(int id, StatusEnum status);
        Task<TaskQueryDTO> Delete(int id);
    }
}
