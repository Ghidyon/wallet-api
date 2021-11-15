using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalletApi.Models.Interfaces;

namespace WalletApi.Models.Entities
{
    public class User : IdentityUser, ITracking, ISoftDelete, IDeactivate
    {
        public User()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsDeactivated { get; set; }
    }
}
