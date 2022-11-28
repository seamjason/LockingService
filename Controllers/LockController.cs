using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Services;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LockController : ControllerBase
    {        
        private readonly ILogger<LockController> _logger;

        public LockController(ILogger<LockController> logger)
        {
            _logger = logger;
        }

        [HttpPost("lock")]
        public bool CreateLock(int UserId, int DeviceId)
        {
            var lockService = new LockService();
            return lockService.CreateLock(UserId, DeviceId);
        }

        [HttpPost("unlock")]
        public bool ReleaseLock(int UserId, int DeviceId)
        {
            var lockService = new LockService();
            return lockService.ReleaseLock(UserId, DeviceId);
        }

        [HttpPost("updateLock")]
        public bool UpdateLock(int UserId, int DeviceId)
        {
            var lockService = new LockService();
            return lockService.UpdateLock(UserId, DeviceId);
        }
    }
}