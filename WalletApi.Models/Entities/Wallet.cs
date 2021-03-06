using System;
using WalletApi.Models.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace WalletApi.Models.Entities
{
    public class Wallet : ITracking, ISoftDelete, IDeactivate
    {
        public Wallet()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
        
        [Column("WalletId")]
        public Guid Id { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        [Column(TypeName = "decimal(38,2)")]
        public decimal Balance { get; set; }
        
        public DateTime CreatedAt { get; set; }
        
        public DateTime UpdatedAt { get; set; }
        
        public bool IsDeleted { get; set; }
        
        public bool IsDeactivated { get; set; }
    }
}
