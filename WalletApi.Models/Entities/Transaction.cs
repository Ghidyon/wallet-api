using System;
using System.ComponentModel.DataAnnotations.Schema;
using WalletApi.Models.Interfaces;

namespace WalletApi.Models.Entities
{
    public class Transaction : ITracking, ISoftDelete, IDeactivate
    {
        public Transaction()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

        public Guid Id { get; set; }
        [ForeignKey("Wallet")]
        public Guid WalletId { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsDeactivated { get; set; }
    }
}
