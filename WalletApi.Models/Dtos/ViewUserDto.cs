using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalletApi.Models.Entities;

namespace WalletApi.Models.Dtos
{
    public class ViewUserDto
    {
        public string UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public Guid WalletId { get; set; }
        public decimal Balance { get; set; }
    }
}
