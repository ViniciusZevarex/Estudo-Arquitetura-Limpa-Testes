using Application.DTO;
using Application.Services.Interface;
using Domain.Entities;
using Domain.Entities.Enum;
using Domain.Interfaces;

namespace Application.Services.Implementation
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<TaskQueryDTO> ChangeStatus(int id, StatusEnum status)
        {
            TaskEntity taskEntity = await _taskRepository.GetByIdAsync(id);

            if (status == StatusEnum.Doing)
                taskEntity.SetDoing();
            else if (status == StatusEnum.Done)
                taskEntity.SetDone();
            else
                throw new Exception("Não é possível alterar o status para ToDo!");

            await _taskRepository.Update(taskEntity);
            TaskQueryDTO taskQuery = new TaskQueryDTO(taskEntity);
            return taskQuery;
        }

        public async Task<TaskQueryDTO> Create(TaskCommandDTO taskCreateDTO)
        {
            var task = taskCreateDTO.ToEntity();
            int id = await _taskRepository.Create(task);
            TaskEntity taskEntity = await _taskRepository.GetByIdAsync(id);
            var taskQuery = new TaskQueryDTO(taskEntity);

            return taskQuery;
        }

        public async Task<TaskQueryDTO> Delete(int id)
        {
            TaskEntity taskEntity = await _taskRepository.GetByIdAsync(id);
            await _taskRepository.Delete(id);

            var taskQuery = new TaskQueryDTO(taskEntity);

            return taskQuery;
        }

        public async Task<TaskQueryDTO> GetTaskById(int id)
        {
            TaskEntity taskEntity = await _taskRepository.GetByIdAsync(id);
            var taskQuery = new TaskQueryDTO(taskEntity);

            return taskQuery;
        }

        public async Task<List<TaskQueryDTO>> ListAll()
        {
            var tasks = await _taskRepository.GetAllAsync();
            var tasksDTO = TaskQueryDTO.ToListEntity(tasks);
            return tasksDTO;
        }

        public async Task<List<TaskQueryDTO>> ListByStatus(StatusEnum status)
        {
            var list = await _taskRepository.ListByStatus(status);
            var tasksDTO = TaskQueryDTO.ToListEntity(list);
            return tasksDTO;
        }

        public async Task<TaskQueryDTO> Update(TaskCommandDTO taskUpdateDTO)
        {
            TaskEntity entityExists = await _taskRepository.GetByIdAsync(taskUpdateDTO.Id);
            if (entityExists == null)
                throw new Exception("Task não encontrada!");

            var task = taskUpdateDTO.ToEntity();
            await _taskRepository.Update(task);

            var taskResult = await _taskRepository.GetByIdAsync(taskUpdateDTO.Id);
            var taskResultDTO = new TaskQueryDTO(taskResult);

            return taskResultDTO;
        }
    }
}
