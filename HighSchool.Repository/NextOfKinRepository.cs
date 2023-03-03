using System;
using HighSchool.Contracts;
using HighSchool.Entities.Models;
using HighSchool.Shared.RequestFeatures;
using Microsoft.EntityFrameworkCore;

namespace HighSchool.Repository
{
    public class NextOfKinRepository : GenericRepositoryBase<NextOfKin>,INextOfKinRepository
    {
        public NextOfKinRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }

        public void CreateNextOfKinAsync(Guid studentId,NextOfKin nextOfKin)
        {
            nextOfKin.Published = true;
            nextOfKin.DatePublished = DateTime.Now;
            nextOfKin.StudentId = studentId;
            Create(nextOfKin);
        }

        public async Task<PagedList<NextOfKin>> GetAllNextOfKinsAsync(RequestParameters requestParameters, bool trackChanges)
        {
            var nextOfKins = await FindByCondition(s => s.Deleted.Equals(false), trackChanges).OrderByDescending(p => p.DateCreated).ToListAsync();

            return PagedList<NextOfKin>.ToPagedList(nextOfKins, requestParameters.PageNumber, requestParameters.PageSize);
        }

        public async Task<NextOfKin> GetNextOfKinByIdAsync(Guid studentId,int nextOfKinId, bool trackChanges)
        {
            return await FindByCondition(p => p.NextOfKinId.Equals(nextOfKinId) && p.Deleted == false&& p.StudentId.Equals(studentId), trackChanges).SingleOrDefaultAsync();
        }

        public void MoveToTrash(NextOfKin nextOfKin)
        {
            nextOfKin.Deleted = true;
            nextOfKin.DateUpdated = DateTime.Now;
            nextOfKin.Published = false;
            Update(nextOfKin);
        }

        public void Publish(NextOfKin nextOfKin)
        {
            nextOfKin.DateUpdated = DateTime.Now;
            nextOfKin.Published = true;
            Update(nextOfKin);
        }

        public void SetToDraft(NextOfKin nextOfKin)
        {
            nextOfKin.DateUpdated = DateTime.Now;
            nextOfKin.Published = false;
            Update(nextOfKin);
        }

        public void UpdatNextOfKinAsync(NextOfKin nextOfKin)
        {
            Update(nextOfKin);
        }
    }
}

