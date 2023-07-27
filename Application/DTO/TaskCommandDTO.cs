using Domain.Entities;

namespace Application.DTO
{
    public class TaskCommandDTO
    {
     
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public TaskEntity ToEntity()
        {
            var taskEntity = new TaskEntity(Id, Name, Description);
            return taskEntity;
        }
    }
}
