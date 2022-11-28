using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Services
{
    public class LockService
    {
        public readonly LockContext context;
        public LockService()
        {
            context = new LockContext("Server=tcp:azusql1.database.windows.net,1433;Initial Catalog=LockingMechanism;Persist Security Info=False;User ID=seamadmin;Password=8eXhjJBxBEK8BGz40nkG;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

        public bool CreateLock(int userId, int deviceId)
        {
            var currentDate = DateTime.Now;
            var activeLock = context.Locks.Where(l => l.UserId == userId && l.ReleasedTimeStamp == null).FirstOrDefault();
            var hasCurrentLock = false;

            if (activeLock != null)
            {
                if ((currentDate - activeLock.LastUpdate).Minutes < 5)
                {
                    hasCurrentLock = true;
                }
            }

            if (!hasCurrentLock)
            {
                var Lock = new Lock
                {
                    UserId = userId,
                    DeviceId = deviceId,
                    LockTimeStamp = currentDate,
                    LastUpdate = currentDate
                };

                context.Locks.Add(Lock);
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ReleaseLock(int userId, int deviceId)
        {
            var currentDate = DateTime.Now;
            var activeLock = context.Locks.Where(l => l.UserId == userId && l.DeviceId == deviceId && l.ReleasedTimeStamp == null).FirstOrDefault();

            if (activeLock != null)
            {
                activeLock.ReleasedTimeStamp = currentDate;
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateLock(int userId, int deviceId)
        {
            var currentDate = DateTime.Now;
            var activeLock = context.Locks.Where(l => l.UserId == userId && l.DeviceId == deviceId && l.ReleasedTimeStamp == null).FirstOrDefault();

            if (activeLock != null)
            {
                activeLock.LastUpdate = currentDate;
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
