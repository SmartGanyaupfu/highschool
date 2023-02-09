using System;
using HighSchool.Contracts;
using HighSchool.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace HighSchool.Repository
{
    public class AllocatedResourceRepository : GenericRepositoryBase<AllocatedResource>, IAllocatedResourceRepository
    {
        public AllocatedResourceRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }

        public void CreateResourceAsync(Guid studentId,AllocatedResource resource)
        {
            resource.StudentId = studentId;

            Create(resource);
        }

        public async Task<IEnumerable<AllocatedResource>> GetAllAllocatedResourcesForStudentAsync(Guid studentId, bool trackChanges)
        {
            return await FindByCondition(r => r.StudentId.Equals(studentId) && r.Deleted.Equals(false), trackChanges).OrderBy(r=>r.DateCreated).ToListAsync();
        }

        public async Task<AllocatedResource> GetAllocatedResourceByIdAsync(Guid studentId, int resourceId, bool trackChanges)
        {
            return await FindByCondition(r => r.StudentId.Equals(studentId) && r.AllocatedResourceId.Equals(resourceId) && r.Deleted.Equals(false), trackChanges).FirstOrDefaultAsync();
        }

        public void MoveToTrash(AllocatedResource resource)
        {
            resource.Deleted = true;

            Update(resource);
        }

        public void UpdateResourceAsync(AllocatedResource resource)
        {
            Update(resource);
        }
    }
}

