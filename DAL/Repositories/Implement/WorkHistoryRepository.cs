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
    public class WorkHistoryRepository : IWorkHistoryRepository
    {
        private readonly AppDbContext _context;

        public WorkHistoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<WorkHistory>> GetAllAsync()
        {
            return await _context.WorkHistories.ToListAsync();
        }

        public async Task<WorkHistory> GetByIdAsync(int id)
        {
            return await _context.WorkHistories.FindAsync(id);
        }

        public async Task AddAsync(WorkHistory workHistory)
        {
            await _context.WorkHistories.AddAsync(workHistory);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(WorkHistory workHistory)
        {
            _context.WorkHistories.Update(workHistory);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var workHistory = await _context.WorkHistories.FindAsync(id);
            if (workHistory != null)
            {
                _context.WorkHistories.Remove(workHistory);
                await _context.SaveChangesAsync();
            }
        }
    }
}
