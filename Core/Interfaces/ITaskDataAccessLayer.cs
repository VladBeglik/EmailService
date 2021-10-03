using Core.Entities;
using System.Collections.Generic;

namespace Core.Interfaces
{
	public interface ITaskDataAccessLayer
	{
		IEnumerable<Task> GetAllEmployees();
		void AddEmployee(Task employee);
		void UpdateEmployee(Task employee);
		void DeleteEmployee(string id);
	}
}