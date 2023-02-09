using System;
using HighSchool.Entities.Models;

namespace HighSchool.Contracts
{
    public interface IAnswerRepository
    {
        Task<IEnumerable<Answer>> GetAllAnswersForQxnAsync(int questionId, bool trackChanges);
        Task<Answer> GetAnswerByIdAsync(int questionId, int answerId, bool trackChanges);
        void CreateAnswerAsync(int questionId, Answer answer);
        void MoveToTrash(Answer answer);
        void UpdateAnswerAsync(Answer answer);
    }
}

