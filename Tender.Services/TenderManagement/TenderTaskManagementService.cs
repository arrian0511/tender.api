using System;
using System.Collections.Generic;
using System.Text;
using Tender.Models;
using Tender.Storage.Context;
using Tender.Storage.Repository;

namespace Tender.Services
{
    public class TenderTaskManagementService : ITenderTaskManagementService
    {
        private IEntityRepository<TenderTask> _entityRepository;

        public TenderTaskManagementService(TenderContext context)
        {
            this._entityRepository = new EntityRepository<TenderTask>(context);
        }

        public ServiceResponse<IEnumerable<TenderTask>> GetAllTasks()
        {
            var response = new ServiceResponse<IEnumerable<TenderTask>>();
            try
            {
                var result = this._entityRepository.GetAll();

                // Set Successfull Response
                response.StatusCode = 200;
                response.ErrorMessage = null;
                response.Content = result;
                return response;
            }
            catch (Exception ex)
            {
                // Set Error Response
                response.StatusCode = 500;
                response.ErrorMessage = ex.Message;
                response.Content = null;
                return response;
            }
        }

        public ServiceResponse<TenderTask> GetTaskById(Guid id)
        {
            var response = new ServiceResponse<TenderTask>();
            try
            {
                var entity = this._entityRepository.GetById(id);

                // Set Successfull Response
                response.StatusCode = 200;
                response.ErrorMessage = null;
                response.Content = entity;
                return response;
            }
            catch (Exception ex)
            {
                // Set Error Response
                response.StatusCode = 500;
                response.ErrorMessage = ex.Message;
                response.Content = null;
                return response;
            }
        }

        public ServiceResponse<TenderTask> CreateTask(TenderTask entity)
        {
            var response = new ServiceResponse<TenderTask>();
            try
            {
                this._entityRepository.Create(entity);

                // Set Successfull Response
                response.StatusCode = 200;
                response.ErrorMessage = null;
                response.Content = entity;
                return response;
            }
            catch (Exception ex)
            {
                // Set Error Response
                response.StatusCode = 500;
                response.ErrorMessage = ex.Message;
                response.Content = entity;
                return response;
            }
        }

        public ServiceResponse<TenderTask> UpdateTask(Guid id, TenderTask entity)
        {
            var response = new ServiceResponse<TenderTask>();
            try
            {
                var originalEntity = this._entityRepository.GetById(id);
                if (originalEntity != null)
                {
                    originalEntity.Copy(entity, false);
                    this._entityRepository.Update(originalEntity);
                }
                else
                {
                    this._entityRepository.Create(entity);
                }

                // Set Successfull Response
                response.StatusCode = 200;
                response.ErrorMessage = null;
                response.Content = entity;
                return response;
            }
            catch (Exception ex)
            {
                // Set Error Response
                response.StatusCode = 500;
                response.ErrorMessage = ex.Message;
                response.Content = entity;
                return response;
            }
        }

        public ServiceResponse<TenderTask> DeleteTask(Guid id)
        {
            var response = new ServiceResponse<TenderTask>();
            try
            {
                var originalEntity = this._entityRepository.GetById(id);
                if (originalEntity != null)
                {
                    this._entityRepository.Delete(originalEntity);
                }

                // Set Successfull Response
                response.StatusCode = 200;
                response.ErrorMessage = null;
                response.Content = originalEntity;
                return response;
            }
            catch (Exception ex)
            {
                // Set Error Response
                response.StatusCode = 500;
                response.ErrorMessage = ex.Message;
                response.Content = null;
                return response;
            }
        }
    }
}
