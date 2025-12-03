Project structure:

MiniAPI/
	Controllers/
		TasksController.cs
	Models/
		TaskModel.cs
		TaskDTO.cs
	Repository/
		TaskRepository.cs
	Program.cs

MiniAPI.Tests/
	TaskEndPointTests.cs

README.md

Run the API:

	cd MiniAPI
	dotnet run
	or
	Press run in visual studio

	API will start on https://localhost:7036

Packages:
	Xunit
	FluentAssertions
	Microsoft.AspNetCoreMvc.Testing
