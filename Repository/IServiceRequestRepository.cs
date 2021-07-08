using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using cohesionIB.Models;
using Microsoft.AspNetCore.Mvc;

namespace cohesionIB.Repository
{
    public interface IServiceRequestRepository
    {
         Task<ActionResult<List<ServiceRequest>>> GetAllServiceRequests();
         Task<ActionResult<ServiceRequest>> GetServiceRequestById(Guid id);
         Task AddServiceRequest(ServiceRequest serviceRequest);
         Task UpdateServiceRequest(ServiceRequest serviceRequest);
         Task DeleteServiceRequest(Guid id);
    }
}