using System;
using System.Collections.Generic;
using Core.Entities;
using Core.Interfaces;
using Microsoft.Data.Sqlite;

namespace Infrastructure.Data
{
	public class TaskDataAccessLayer : ITaskDataAccessLayer
	{
		private const string ConnectionString = "Data Source=C:/Users/Ra1n/Desktop/EmailService/Api/skinet.db";

		public void AddEmployee(Task employee)
		{
			var sqlExpression =
				$"INSERT INTO Tasks (Id, Name, Description) VALUES ('{Guid.NewGuid()}', '{employee.Name}', '{employee.Description}')";
			using (var connection = new SqliteConnection(ConnectionString))
			{
				connection.Open();
				var command = new SqliteCommand(sqlExpression, connection);
				int number = command.ExecuteNonQuery();
				Console.WriteLine("Добавлено объектов: {0}", number);

			}
		}

		public void DeleteEmployee(string id)
		{
			var sqlExpression = $"DELETE FROM Tasks WHERE Id = '{id}'";
			using var connection = new SqliteConnection(ConnectionString);
			connection.Open();
			var command = new SqliteCommand(sqlExpression, connection);
			command.ExecuteNonQuery();
			Console.WriteLine("удалено объектов: {0}");
		}



		//To View all employees details
		public IEnumerable<Task> GetAllEmployees()
		{

			var tasks = new List<Task>();
			var sqlExpression = "SELECT * FROM Tasks";
			using var connection = new SqliteConnection(ConnectionString);
			connection.Open();

			var command = new SqliteCommand(sqlExpression, connection);
			using SqliteDataReader reader = command.ExecuteReader();
			if (!reader.HasRows) return tasks;
			while (reader.Read()) // построчно считываем данные
			{
				var task = new Task();
				task.Id = reader.GetString(0);
				task.Name = reader.GetString(1);
				task.Description = reader.GetString(2);
				//task.DateTime = reader.GetDateTime(3);

				Console.WriteLine($"{task.Id} \t {task.Name} \t {task.Description}");
				tasks.Add(task);
			}

			return tasks;
		}

		public void UpdateEmployee(Task employee)
		{
			var sqlExpression =
				$"UPDATE Tasks SET Name='{employee.Name}',Description='{employee.Description}' WHERE Id={employee.Id}"; 
			using (var connection = new SqliteConnection(ConnectionString))
			{
				connection.Open();
				var command = new SqliteCommand(sqlExpression, connection);
				var number = command.ExecuteNonQuery();
				Console.WriteLine("Обновлено объектов: {0}", number);

			}
		}

		public void SqlComandHandler(string sqlExpression)
		{
			using (var connection = new SqliteConnection(ConnectionString))
			{
				connection.Open();
				var command = new SqliteCommand(sqlExpression, connection);
				var number = command.ExecuteNonQuery();
				Console.WriteLine("Обновлено объектов: {0}", number);

			}
		}
	}
}
