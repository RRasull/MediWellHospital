using Core.Interfaces;
using Core.Models;
using Data.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implementations
{
   public class CardRepository : Repository<Card>, ICardRepository
    {
        private AppDbContext _context { get; set; }
        public CardRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

    
    }
}
