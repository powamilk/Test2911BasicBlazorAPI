using AutoMapper;
using BUS.Service.Interface;
using BUS.ViewModel.WorkHistory;
using DAL.Entities;
using DAL.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Service.Implement
{
    public class WorkHistoryService : IWorkHistoryService
    {
        private readonly IWorkHistoryRepository _workHistoryRepository;
        private readonly IMapper _mapper;

        public WorkHistoryService(IWorkHistoryRepository workHistoryRepository, IMapper mapper)
        {
            _workHistoryRepository = workHistoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<WorkHistoryVM>> GetAllAsync()
        {
            var workHistories = await _workHistoryRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<WorkHistoryVM>>(workHistories);
        }

        public async Task<WorkHistoryVM> GetByIdAsync(int id)
        {
            var workHistory = await _workHistoryRepository.GetByIdAsync(id);
            if (workHistory == null) return null;

            return _mapper.Map<WorkHistoryVM>(workHistory);
        }

        public async Task AddAsync(WorkHistoryCreateVM workHistoryCreateVM)
        {
            var workHistory = _mapper.Map<WorkHistory>(workHistoryCreateVM);
            await _workHistoryRepository.AddAsync(workHistory);
        }

        public async Task UpdateAsync(int id, WorkHistoryUpdateVM workHistoryUpdateVM)
        {
            var existingWorkHistory = await _workHistoryRepository.GetByIdAsync(id);
            if (existingWorkHistory == null) return;

            _mapper.Map(workHistoryUpdateVM, existingWorkHistory);
            await _workHistoryRepository.UpdateAsync(existingWorkHistory);
        }

        public async Task DeleteAsync(int id)
        {
            await _workHistoryRepository.DeleteAsync(id);
        }
    }
}
