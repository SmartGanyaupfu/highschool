using System;
using HighSchool.Entities.Models;
using HighSchool.Shared.RequestFeatures;

namespace HighSchool.Contracts
{
    public interface INextOfKinRepository
    {
        Task<PagedList<NextOfKin>> GetAllNextOfKinsAsync(RequestParameters requestParameters, bool trackChanges);
        Task<NextOfKin> GetNextOfKinByIdAsync(Guid studentId,int nextOfKinId, bool trackChanges);
        void CreateNextOfKinAsync(Guid studentId,NextOfKin nextOfKin);
        void MoveToTrash(NextOfKin nextOfKin);
        void SetToDraft(NextOfKin nextOfKin);
        void Publish(NextOfKin nextOfKin);
        void UpdatNextOfKinAsync(NextOfKin nextOfKin);
    }
}

