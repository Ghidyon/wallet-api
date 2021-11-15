using System;
using WalletApi.Models.Interfaces;

namespace WalletApi.Models.Entities
{
    public class Wallet : ITracking, ISoftDelete, IDeactivate
    {
        public Wallet()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

        public Guid Id { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }
        public Guid WalletId { get; set; }
        public decimal Balance { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsDeactivated { get; set; }
    }
}
