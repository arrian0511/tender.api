using System;
using System.Collections.Generic;
using System.Text;
using Tender.Models;

namespace Tender.Services
{
    public interface ITenderTaskManagementService
    {
        /// <summary>
        /// Get All Tasks
        /// </summary>
        /// <returns></returns>
        ServiceResponse<IEnumerable<TenderTask>> GetAllTasks();
        ServiceResponse<TenderTask> GetTaskById(Guid id);
        ServiceResponse<TenderTask> CreateTask(TenderTask entity);
        ServiceResponse<TenderTask> UpdateTask(Guid id, TenderTask entity);
        ServiceResponse<TenderTask> DeleteTask(Guid id);
    }
}
