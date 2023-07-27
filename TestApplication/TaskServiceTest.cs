using Application.DTO;
using Application.Services.Implementation;
using Application.Services.Interface;
using Domain.Entities;
using Domain.Entities.Enum;
using Domain.Interfaces;
using Moq;
using TestDomain.Builders;

namespace TestApplication
{
    public class TaskServiceTest
    {

        private TaskCommandDTO _taskCommandDTO;
        private readonly Mock<ITaskRepository> _taskRepositorio;
        private readonly ITaskService _taskService;


        public TaskServiceTest()
        {
            _taskCommandDTO = new TaskCommandDTO
            {
                Description = "Lorem ipsum dolor amet ..",
                Name = "Criar projeto de teste"
            };

            _taskRepositorio = new Mock<ITaskRepository>();
            _taskService = new TaskService(_taskRepositorio.Object);
        }

        [Fact]
        public void DeveAdicionarTask()
        {
            _taskService.Create(_taskCommandDTO);

            _taskRepositorio.Verify(r => r.Create(
                    It.Is<TaskEntity>(
                            a => a.Name == _taskCommandDTO.Name &&
                            a.Description == _taskCommandDTO.Description
                        )
                ));
        }


        [Fact]
        public void DeveMudarStatus()
        {
            int id = 1;
            var taskEntity = TaskBuilder.New().Build();
            _taskRepositorio.Setup(r => r.GetByIdAsync(id).Result).Returns(taskEntity);

            _taskService.ChangeStatus(id, StatusEnum.Doing);

            Assert.Equal(StatusEnum.Doing, taskEntity.Status);
        }

        [Fact]
        public void NaoDeveAtualizarUmaTaskQueNaoExiste()
        {
            int id = 1;
            TaskEntity taskEntity = null;
            _taskRepositorio.Setup(r => r.GetByIdAsync(id).Result).Returns(taskEntity);

            TaskCommandDTO taskCommandDTO = new TaskCommandDTO
            {
                Id = id,
                Name = "Nome",
                Description = "Descricao"
            };

            var exception = Assert.ThrowsAsync<Exception>(async () => await _taskService.Update(taskCommandDTO)).Result;

            Assert.Equal("Task não encontrada!", exception.Message);
        }


    }
}
