using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Lock
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        public int DeviceId { get; set; }

        public DateTime LockTimeStamp { get; set; }

        public DateTime LastUpdate { get; set; }

        public DateTime? ReleasedTimeStamp {get; set;}
    }
}