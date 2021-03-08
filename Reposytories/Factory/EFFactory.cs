using Reposytories.Abstract;
//using Reposytories.Concreate.EF;
using Reposytories.Concrete.EF;

namespace Reposytories.Factory
{
    public class EFFactory : IFactory
    {
        public IAudienceReposytory GetAudienceReposytory()
        { return new AudienceReposytory(); }
        public IGroupReposytory GetGroupReposytory()
        { return new GroupReposytory(); }
        public IHistoryReposytory GetHistoryReposytory()
        { return new HistoryReposytory(); }
        public ILecturerReposytory GetLecturerReposytory()
        { return new LecturerReposytory(); }
        public ILessonReposytory GetLessonReposytory()
        { return new LessonReposytory(); }
        public IStudentReposytory GetStudentReposytory()
        { return new StudentReposytory(); }
        public ISubjectReposytory GetSubjectReposytory()
        { return new SubjectReposytory(); }



    }
}
