using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingList.Models
{
    [Owned]
    public class CreationBuylist
    {
        public DateTime OrderDate { get; set; }
        public string Creator { get; set; }
    }
}
