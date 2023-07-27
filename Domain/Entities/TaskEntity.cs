using Domain.Entities.Enum;
using Domain.Entities.Exceptions;

namespace Domain.Entities
{
    public class TaskEntity
    {



        public TaskEntity(
            int id,
            string? name,
            string? description)
        {
            DomainException.VerifyValidation(id > 0, "O valor de id deve ser menor ou igual à zero.");
            DomainException.VerifyValidation(name?.Length > 3 && name?.Length < 100,
                "O nome da tarefa deve ter mais que 3 caracteres e menos que 100 caracteres");
            DomainException.VerifyValidation(description?.Length > 3 && description?.Length < 254,
                "A descrição da tarefa deve ter mais que 3 caracteres e menos que 254 caracteres");

            Id = id;
            Name = name;
            Description = description;
            Created = DateTime.Now;
            Status = StatusEnum.ToDo;
        }



        public TaskEntity(
                string? name,
                string? description)
        {
            DomainException.VerifyValidation(name?.Length > 3 && name?.Length < 100,
                "O nome da tarefa deve ter mais que 3 caracteres e menos que 100 caracteres");
            DomainException.VerifyValidation(description?.Length > 3 && description?.Length < 254,
                "A descrição da tarefa deve ter mais que 3 caracteres e menos que 254 caracteres");

            Name = name;
            Description = description;
            Created = DateTime.Now;
            Status = StatusEnum.ToDo;
        }


        //public TaskEntity(
        //        int id, 
        //        string? name, 
        //        string? description)
        //{
        //    DomainException.VerifyValidation(id > 0,
        //        "Id deve ser maior que 0.");
        //    DomainException.VerifyValidation(name?.Length > 3 && name?.Length < 100, 
        //        "O nome da tarefa deve ter mais que 3 caracteres e menos que 100 caracteres");
        //    DomainException.VerifyValidation(description?.Length > 3 && description?.Length < 254,
        //        "A descrição da tarefa deve ter mais que 3 caracteres e menos que 254 caracteres");
            
        //    Id = id;
        //    Name = name;
        //    Description = description;
        //    Created = DateTime.Now;
        //    Status = StatusEnum.ToDo;
        //}

        public int Id { get; private set;}
        public string? Name { get; private set;}
        public string? Description { get; private set;}
        public DateTime Created { get; private set;}
        public StatusEnum Status { get; private set; }


        public void SetDoing()
        {
            DomainException.VerifyValidation(Status == StatusEnum.ToDo,
                            "Só pode evoluir para Doing se o status atual for To Do.");
            Status = StatusEnum.Doing;
        }

        public void SetDone()
        {
            DomainException.VerifyValidation(Status == StatusEnum.Doing,
                "Só pode evoluir para Done se o status atual for Doing.");
            Status = StatusEnum.Done;
        }



    }
}
