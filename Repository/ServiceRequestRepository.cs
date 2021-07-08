using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using cohesionIB.Models;
using cohesionIB.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cohesionIB.Repository
{
    public class ServiceRequestRepository : IServiceRequestRepository
    {
        private readonly ServiceRequestContext _context;

        public ServiceRequestRepository(ServiceRequestContext context)
        {
            _context = context;
        }

        public async Task AddServiceRequest(ServiceRequest serviceRequest)
        {
            await _context.ServiceRequests.AddAsync(serviceRequest);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteServiceRequest(Guid id)
        {
            var deleteStudent = await _context.ServiceRequests.FirstOrDefaultAsync(
                u => u.Id == id);
            _context.ServiceRequests.Remove(deleteStudent);
            await _context.SaveChangesAsync();
        }

        public async Task<ActionResult<List<ServiceRequest>>> GetAllServiceRequests()
        {
            return await _context.ServiceRequests.ToListAsync();
        }

        public async Task<ActionResult<ServiceRequest>> GetServiceRequestById(Guid id)
        {
            var serviceRequest = await _context.ServiceRequests.FindAsync(id);
             if(serviceRequest == null){
                 return new StatusCodeResult(404);
             }   
             return serviceRequest;             
        }

        public async Task UpdateServiceRequest(ServiceRequest serviceRequest)
        {
            _context.ServiceRequests.Update(
               new ServiceRequest
               {
                   Id = serviceRequest.Id,
                   BuildingCode = serviceRequest.BuildingCode,
                   Description = serviceRequest.Description,
                   CurrentStatus = serviceRequest.CurrentStatus,
                   CreatedBy = serviceRequest.CreatedBy,
                   CreateDate = serviceRequest.CreateDate,
                   LastModifiedBy = serviceRequest.LastModifiedBy,
                   LastModifiedDate = serviceRequest.LastModifiedDate 
               });

            await _context.SaveChangesAsync();
        }
    }
}