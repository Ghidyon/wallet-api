using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalletApi.Models.Dtos
{
    public class ViewWalletDto
    {
        public Guid UserId { get; set; }

        public Guid WalletId { get; set; }

        public decimal Balance { get; set; }
    }
}
