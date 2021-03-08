using Reposytories.Abstract;

namespace Reposytories.Factory
{
    public interface IFactory
    {
        IAudienceReposytory GetAudienceReposytory();
        IGroupReposytory GetGroupReposytory();
        IHistoryReposytory GetHistoryReposytory();
        ILecturerReposytory GetLecturerReposytory();
        ILessonReposytory GetLessonReposytory();
        IStudentReposytory GetStudentReposytory();
        ISubjectReposytory GetSubjectReposytory();
    }
}
