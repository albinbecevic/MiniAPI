using MiniAPI.Models;
using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using MiniAPI.Repository;

namespace MiniAPI.Tests { 


    public class TasksEndPointTests {

        public TasksEndPointTests()
        {
            TaskRepository.Clear();
        }

        [Fact]
        public void CreateTask_AssignsIncrementingId() {
            var t1 = TaskRepository.CreateTask(new TaskModel { Title = "A" });
            var t2 = TaskRepository.CreateTask(new TaskModel { Title = "B" });

            t1.Id.Should().Be(1);
            t2.Id.Should().Be(2);
        }

        [Fact]
        public void CreateTask_StoresTask() {
            TaskRepository.CreateTask(new TaskModel { Title = "A" });

            TaskRepository.GetAllTasks().Should().HaveCount(1);
        }

        [Fact]
        public void GetTask_ReturnsTask_WhenExists() {
            var created = TaskRepository.CreateTask(new TaskModel { Title = "A" });

            var result = TaskRepository.GetTask(created.Id);

            result.Should().NotBeNull();
            result!.Title.Should().Be("A");
        }

        [Fact]
        public void GetTask_ReturnsNull_WhenNotExists() {
            var result = TaskRepository.GetTask(999);
            result.Should().BeNull();
        }

        [Fact]
        public void UpdateTask_UpdatesFields() {
            var created = TaskRepository.CreateTask(new TaskModel { Title = "Old" });

            var updated = new TaskModel { Title = "New", Description = "Desc", DueDate = "Tomorrow" };

            TaskRepository.UpdateTask(created.Id, updated);

            var result = TaskRepository.GetTask(created.Id);
            result!.Title.Should().Be("New");
            result.Description.Should().Be("Desc");
        }

        [Fact]
        public void UpdateTask_ReturnsNull_IfNotFound() {
            var result = TaskRepository.UpdateTask(999, new TaskModel());
            result.Should().BeNull();
        }

        [Fact]
        public void DeleteTask_RemovesTask() {
            var t = TaskRepository.CreateTask(new TaskModel { Title = "A" });

            TaskRepository.DeleteTask(t.Id).Should().BeTrue();
            TaskRepository.GetAllTasks().Should().BeEmpty();
        }

        [Fact]
        public void DeleteTask_ReturnsFalse_IfNotFound() {
            TaskRepository.DeleteTask(999).Should().BeFalse();
        }

        [Fact]
        public void GetAllTasks_ReturnsAllTasks() {
            TaskRepository.CreateTask(new TaskModel { Title = "A" });
            TaskRepository.CreateTask(new TaskModel { Title = "B" });

            var result = TaskRepository.GetAllTasks().ToList();

            result.Should().HaveCount(2);
            result[0].Title.Should().Be("A");
            result[1].Title.Should().Be("B");
        }

        [Fact]
        public void Clear_EmptiesRepository() {
            TaskRepository.CreateTask(new TaskModel { Title = "A" });

            TaskRepository.Clear();

            TaskRepository.GetAllTasks().Should().BeEmpty();
        }
    }
}
