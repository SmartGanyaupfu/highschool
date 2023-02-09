using System;
using HighSchool.Contracts;
using HighSchool.Entities.Models;
using HighSchool.Shared.RequestFeatures;
using Microsoft.EntityFrameworkCore;

namespace HighSchool.Repository
{
    public class QuestionRepository : GenericRepositoryBase<Question>,IQuestionRepository
    {
        public QuestionRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }

        void IQuestionRepository.CreateQuestionAsync(Question question)
        {
            Create(question);
        }

        async Task<PagedList<Question>> IQuestionRepository.GetAllQuestionsAsync(RequestParameters requestParameters, bool trackChanges)
        {
            var questions = await FindByCondition(s => s.Deleted.Equals(false), trackChanges).Include(q=>q.Answers).OrderByDescending(p => p.DateCreated).ToListAsync();

            return PagedList<Question>.ToPagedList(questions, requestParameters.PageNumber, requestParameters.PageSize);
        }

        async Task<Question> IQuestionRepository.GetQuestionByIdAsync(int questionId, bool trackChanges)
        {
            return await FindByCondition(p => p.QuestionId.Equals(questionId) && p.Deleted == false, trackChanges).Include(a=>a.Answers).SingleOrDefaultAsync();
        }

        async Task<Question> IQuestionRepository.GetQuestionBySlugAsync(string slug, bool trackChanges)
        {
            return await FindByCondition(p => p.Slug.Equals(slug) && p.Deleted == false, trackChanges).Include(a => a.Answers).SingleOrDefaultAsync();
        }

        void IQuestionRepository.MoveToTrash(Question question)
        {
            question.Deleted = true;
            question.DateUpdated = DateTime.Now;
            question.Published = false;
            Update(question);
        }

        void IQuestionRepository.Publish(Question question)
        {
            question.DateUpdated = DateTime.Now;
            question.Published = true;
            Update(question);
        }

        void IQuestionRepository.SetToDraft(Question question)
        {
            question.DateUpdated = DateTime.Now;
            question.Published = false;
            Update(question);
        }

        void IQuestionRepository.UpdateQuestionAsync(Question question)
        {
            Update(question);
        }
    }
}

