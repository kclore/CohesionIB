using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cohesionIB.Models;
using cohesionIB.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace cohesionibapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServiceRequestController : ControllerBase
    {
        private readonly IServiceRequestRepository _serviceRequestRepository;
        private readonly ILogger<ServiceRequestController> _logger;
        public ServiceRequestController(IServiceRequestRepository serviceRequestRepository, ILogger<ServiceRequestController> logger)
        {
           _serviceRequestRepository = serviceRequestRepository;
           _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<ServiceRequest>>> GetserviceRequests()
        {
            return  Ok(await _serviceRequestRepository.GetAllServiceRequests());  
        }

        [HttpGet("{id}")]
        public  async Task<ActionResult<ServiceRequest>> GetServiceRequestById(Guid id)
        {
            
            return await _serviceRequestRepository.GetServiceRequestById(id);        
        }

         [HttpPost]
        public async Task<IActionResult> AddServiceRequest( ServiceRequest serviceRequest)
        {
            await _serviceRequestRepository.AddServiceRequest(serviceRequest);  
            return CreatedAtAction("GetServiceRequestById", new { id = serviceRequest.Id},serviceRequest);
        }

        [HttpPut("{id}")]
        public async Task UpdateServiceRequest(ServiceRequest serviceRequest)
        {
             await _serviceRequestRepository.UpdateServiceRequest(serviceRequest);  
        }

        [HttpDelete("{id}")]
        public async Task DeleteServiceRequest(Guid id)
        {
             await _serviceRequestRepository.DeleteServiceRequest(id);  
        }
    }
}
