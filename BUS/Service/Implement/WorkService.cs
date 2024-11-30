using AutoMapper;
using BUS.Service.Interface;
using BUS.ViewModel;
using DAL.Entities;
using DAL.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Service.Implement
{
    public class WorkService : IWorkService
    {
        private readonly IWorkRepo _repo;
        private readonly IMapper _mapper;

        public WorkService(IWorkRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task CreateAsync(WorkCreateVM workVM)
        {
            var work = _mapper.Map<Work>(workVM);
            await _repo.AddAsync(work);
        }

        public async Task DeleteAsync(int id)
        {
            await _repo.DeleteAsync(id);
        }


        public async Task<IEnumerable<WorkVM>> GetAllAsync()
        {
            var work = await _repo.GetAllAsync();
            return _mapper.Map<IEnumerable<WorkVM>>(work);
        }

        public async Task<WorkVM> GetByIdAsync(int id)
        {
            var work = await _repo.GetByIdAsync(id);
            return work == null ? null : _mapper.Map<WorkVM>(work);
        }

        public async Task UpdateAsync(WorkUpdateVM workVM)
        {
            var exiting = await _repo.GetByIdAsync(workVM.WorkId);
            if (exiting != null)
            {
                _mapper.Map(workVM, exiting);
                await _repo.UpdateAsync(exiting);
            }    
        }
    }
}
