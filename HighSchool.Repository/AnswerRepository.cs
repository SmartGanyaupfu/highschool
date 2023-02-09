using System;
using HighSchool.Contracts;
using HighSchool.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace HighSchool.Repository
{
    public class AnswerRepository : GenericRepositoryBase<Answer>, IAnswerRepository
    {
        public AnswerRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }

        public void CreateAnswerAsync(int questionId, Answer answer)
        {
            answer.QuestionId = questionId;
            Create(answer);
        }

        public async Task<IEnumerable<Answer>> GetAllAnswersForQxnAsync(int questionId, bool trackChanges)
        {
            return await FindByCondition(a => a.QuestionId.Equals(questionId) && a.Deleted.Equals(false), trackChanges).ToListAsync();
        }

        public async Task<Answer> GetAnswerByIdAsync(int questionId, int answerId, bool trackChanges)
        {
            return await FindByCondition(a => a.QuestionId.Equals(questionId) && a.AnswerId.Equals(answerId), trackChanges).FirstOrDefaultAsync();
        }

        public void MoveToTrash(Answer answer)
        {
            answer.Deleted = true;
            Update(answer);
        }

        public void UpdateAnswerAsync(Answer answer)
        {
            Update(answer);
        }
    }
}

