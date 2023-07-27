using Domain.Entities;
using Domain.Entities.Enum;

namespace Application.DTO
{
    public class TaskQueryDTO
    {

        public TaskQueryDTO()
        {

        }


        public TaskQueryDTO(TaskEntity taskEntity)
        {
            Id = taskEntity.Id;
            Name = taskEntity.Name;
            Description = taskEntity.Description;
            Created = taskEntity.Created;
            Status  = taskEntity.Status;
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime Created { get; set; }
        public StatusEnum Status { get; set; }


        public static List<TaskQueryDTO> ToListEntity(List<TaskEntity> tasks)
        {
            var tasksDTO = new List<TaskQueryDTO>();
            foreach (var t in tasks)
                tasksDTO.Add(new TaskQueryDTO(t));

            return tasksDTO;
        }
    }
}
