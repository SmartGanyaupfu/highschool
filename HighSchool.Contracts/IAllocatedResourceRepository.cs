using System;
using HighSchool.Entities.Models;

namespace HighSchool.Contracts
{
    public interface IAllocatedResourceRepository
    {
        Task<IEnumerable<AllocatedResource>> GetAllAllocatedResourcesForStudentAsync(Guid studentId, bool trackChanges);
        Task<AllocatedResource> GetAllocatedResourceByIdAsync(Guid studentId,int resourceId, bool trackChanges);
        void CreateResourceAsync(Guid studentId, AllocatedResource resource);
        void MoveToTrash( AllocatedResource resource);
        void UpdateResourceAsync( AllocatedResource resource);
    }
}

