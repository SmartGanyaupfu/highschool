using System;
using HighSchool.Entities.Models;
using HighSchool.Shared.RequestFeatures;

namespace HighSchool.Contracts
{
    public interface IQuestionRepository
    {
        Task<PagedList<Question>> GetAllQuestionsAsync(RequestParameters requestParameters, bool trackChanges);
        Task<Question> GetQuestionByIdAsync(int questionId, bool trackChanges);
        Task<Question> GetQuestionBySlugAsync(string slug, bool trackChanges);
        void CreateQuestionAsync(Question question);
        void MoveToTrash(Question question);
        void SetToDraft(Question question);
        void Publish(Question question);
        void UpdateQuestionAsync(Question question);
    }
}

