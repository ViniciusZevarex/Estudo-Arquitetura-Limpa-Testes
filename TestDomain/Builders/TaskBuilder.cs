using Domain.Entities;

namespace TestDomain.Builders
{
    public class TaskBuilder
    {
        private int _id = 1;
        private string? _name = "Preparar treinamento";
        private string? _description = "Preparar o treinamento com o desenvolvimento de um projeto Web API com arquitetura limpa, testes e padrão REST.";
        

        public static TaskBuilder New()
        {
            return new TaskBuilder();
        }

        public TaskBuilder WithId(int id)
        {
            _id = id;
            return this;
        }


        public TaskBuilder WithName(string? name)
        {
            _name = name;
            return this;
        }


        public TaskBuilder WithDescription(string? description)
        {
            _description = description;
            return this;
        }

        public TaskEntity Build()
        {
            var tsk = new TaskEntity(_id,_name, _description);
            return tsk;
        }

    }
}
