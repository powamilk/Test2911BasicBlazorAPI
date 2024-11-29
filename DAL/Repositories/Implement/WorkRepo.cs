using DAL.Entities;
using DAL.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Implement
{
    public class WorkRepo : IWorkRepo
    {
        private readonly AppDbContext _context;

        public WorkRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Work work)
        {
            await _context.Works.AddAsync(work);    
            await _context.SaveChangesAsync();  
        }

        public async Task DeleteAsync(int id)
        {
            var work = await _context.Works.FindAsync(id);
            if (work != null)
            {
                _context.Works.Remove(work);    
                await _context.SaveChangesAsync();
            }    
        }

        public async Task<IEnumerable<Work>> GetAllAsync()
        {
            return await _context.Works.ToListAsync();
        }

        public async Task<Work> GetByIdAsync(int id)
        {
            return await _context.Works.FindAsync(id);
        }

        public async Task<IEnumerable<Work>> GetByUserIdAsync(int userId)
        {
            return await _context.Works.Where(w => w.UserId == userId).ToListAsync();
        }

        public async Task UpdateAsync(Work work)
        {
            _context.Works.Update(work);
            await _context.SaveChangesAsync();
        }
    }
}
