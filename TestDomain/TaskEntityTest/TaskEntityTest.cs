using Domain.Entities;
using Domain.Entities.Enum;
using Domain.Entities.Exceptions;
using ExpectedObjects;
using TestDomain.Builders;

namespace TestDomain.TaskEntityTest
{
    public class TaskEntityTest
    {


        private int _id = 1;
        private string? _name = "Preparar treinamento";
        private string? _description = "Preparar o treinamento com o desenvolvimento de um projeto Web API com arquitetura limpa, testes e padrão REST.";


        [Fact]
        public void DeveCriarTask()
        {
            var taskCriado = new TaskEntity(_id,_name, _description);

            var createdValue = taskCriado.Created;

            var taskEsperado = new
            {
                Id = _id,
                Name = _name,
                Description = _description,
                Created = createdValue,
                Status = StatusEnum.ToDo
            };

            taskEsperado.ToExpectedObject().ShouldMatch(taskCriado);
        }


        [Theory]
        [InlineData(-1)]
        [InlineData(-2)]
        [InlineData(-3)]
        [InlineData(-100000)]
        [InlineData(0)]
        public void DeveLancarExcecaoParaIdInvalido(int id)
        {
            Assert.Throws<DomainException>(() =>
            {
                var taskEntity = TaskBuilder.New().WithId(id).Build();
            });
        }

        [Theory]
        [InlineData("Ed")]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.")]
        public void DeveLancarExcecaoParaNomeInvalido(string name)
        {
            Assert.Throws<DomainException>(() =>
            {
                var taskEntity = TaskBuilder.New().WithName(name).Build();
            });
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("Ed")]
        [InlineData("Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.")]
        public void DeveLancarExcecaoParaDescricaoInvalida(string description)
        {
            Assert.Throws<DomainException>(() =>
            {
                var taskEntity = TaskBuilder.New().WithDescription(description).Build();
            });
        }

        [Fact]
        public void DeveAtualizarTaskComoDoneSomenteSeEstiverDoing()
        {
            Assert.Throws<DomainException>(() =>
            {
                var taskEntity = TaskBuilder.New().Build();
                taskEntity.SetDone();
            });
        }

        [Fact]
        public void DeveLancarExcecaoCasoTroqueDeDoingParaDoing()
        {
            Assert.Throws<DomainException>(() =>
            {
                var taskEntity = TaskBuilder.New().Build();
                taskEntity.SetDoing();
                taskEntity.SetDoing();
            });
        }


        [Fact]
        public void DeveLancarExcecaoCasoTroqueDeDoneParaDoing()
        {
            Assert.Throws<DomainException>(() =>
            {
                var taskEntity = TaskBuilder.New().Build();
                taskEntity.SetDoing();
                taskEntity.SetDone();
                taskEntity.SetDoing();
            });
        }
    }
}
