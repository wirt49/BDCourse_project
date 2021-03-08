using Reposytories.Abstract;
using System;
using Reposytories.Factory;
using Models;

namespace BDCourse_project
{
    class Program
    {
        static void Main(string[] args)
        {
            string key;
            do
            {
                Console.WriteLine("What do u want to do? To access the student table click (st).\n To access the lessons table click (les). \n" +
                    " To access the lecturer table click(lec). \n To access the subject table click(sub). \n To access the history table click(h). \n" +
                    " To access the audience table click(a). \n To access the groups table click(g). \n\n To get all tables click(all). \n To exit enter (exit)");
                key = Console.ReadLine();
                try
                {
                    if(key == "st")
                    { StudentChioce(); }
                    else if(key == "les")
                    { LessonChoice(); }
                    else if(key == "lec")
                    { LecturerChoice(); }
                    else if (key == "sub")
                    { SubjectChoice(); }
                    else if(key == "h")
                    { HistoryChoice(); }
                    else if(key == "a")
                    { AudienceChoice(); }
                    else if(key == "g")
                    { GroupChoice(); }
                    else if(key == "all")
                    { GetAllData(); }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
            } while (key != "exit");
            
        }

        static void HistoryChoice()
        {
            IHistoryReposytory historyReposytory = Factories.GetFactory().GetHistoryReposytory();
            string key;
            do
            {
                Console.WriteLine("What do u want to do? Get all students?(all). To back enter (b)");
                key = Console.ReadLine();
                try
                {
                    if (key == "all")
                    {
                        Console.WriteLine("History of using database: ");
                        foreach (var history in historyReposytory.GetAllHistory())
                        {
                            Console.WriteLine(string.Format("ID: {0}, Lesson ID: {1}, Operation: {2}, Time: {3}",
                                history.Id, history.Lesson_ID, history.Operation, history.OnTime));
                        }
                        Console.WriteLine();
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
            } while (key != "b");
        }

        static void LessonChoice()
        {
            ILessonReposytory lessonReposytory = Factories.GetFactory().GetLessonReposytory();
            string key;
            do
            {
                Console.WriteLine("What do u want to do? Get all lessons?(all). Add lesson?(add). Update student?(update). Delete?(del). To back enter (b)");
                key = Console.ReadLine();
                try
                {
                    if (key == "all")
                    {
                        Console.WriteLine();
                        foreach (var lessons in lessonReposytory.GetAllLessons())
                        {
                            Console.WriteLine(string.Format("ID: {0}, Subject: {1}, Lecturer: {2}, Audience: {3}, " +
                                "Academic group: {4},Time: {5}, Day: {6}, Type: {7}",
                                lessons.Id, lessons.Subject, lessons.Lecturer, lessons.Audience, lessons.Academic_group, lessons.Time, lessons.Day, lessons.Type));
                        }
                        Console.WriteLine();
                    }
                    else if (key == "add")
                    {
                        Console.WriteLine("Enter id for new lesson: ");
                        int ID_for_new_elem = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter id for subject: ");
                        int ID_for_new_sub = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter id for lecturer: ");
                        int ID_for_new_lecutrer = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter id for auedience: ");
                        int ID_for_new_audience = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter id for academic group: ");
                        int ID_for_new_academic_group = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter time of lesson: ");
                        DateTime Ontime = Convert.ToDateTime(Console.ReadLine());
                        Console.WriteLine("Enter day: ");
                        string Day_ = Console.ReadLine();
                        Console.WriteLine("Enter type of lesson: ");
                        string Type_ = Console.ReadLine();
                        lessonReposytory.Add(new Lesson
                        {
                            Id = ID_for_new_elem,
                            Subject = ID_for_new_sub,
                            Lecturer = ID_for_new_lecutrer,
                            Audience = ID_for_new_audience,
                            Academic_group = ID_for_new_academic_group,
                            Time = Ontime,
                            Day = Day_,
                            Type = Type_
                        });
                    }
                    else if (key == "update")
                    {
                        Console.WriteLine("Enter id for new lesson: ");
                        int ID_for_new_elem = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter id for subject: ");
                        int ID_for_new_sub = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter id for lecturer: ");
                        int ID_for_new_lecutrer = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter id for auedience: ");
                        int ID_for_new_audience = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter id for academic group: ");
                        int ID_for_new_academic_group = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter time of lesson: ");
                        DateTime Ontime = Convert.ToDateTime(Console.ReadLine());
                        Console.WriteLine("Enter day: ");
                        string Day_ = Console.ReadLine();
                        Console.WriteLine("Enter type of lesson: ");
                        string Type_ = Console.ReadLine();
                        lessonReposytory.Update(new Lesson
                        {
                            Id = ID_for_new_elem,
                            Subject = ID_for_new_sub,
                            Lecturer = ID_for_new_lecutrer,
                            Audience = ID_for_new_audience,
                            Academic_group = ID_for_new_academic_group,
                            //Time = Ontime,
                            Day = Day_,
                            Type = Type_
                        });
                    }
                    else if (key == "del")
                    {
                        Console.WriteLine("Enter id of lesson u want to delete: ");
                        int x = int.Parse(Console.ReadLine());
                        lessonReposytory.Delete(new Models.Lesson
                        {
                            Id = x
                        });
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
            } while (key != "b");
        }

        static void StudentChioce()
        {
            IStudentReposytory studentReposytory = Factories.GetFactory().GetStudentReposytory();
            string key;
            do
            {
                Console.WriteLine("What do u want to do? Get all students?(all). Add student?(add). Update student?(update). Delete?(del). To back enter (b)");
                key = Console.ReadLine();
                try
                {
                    if (key == "all")
                    {
                        Console.WriteLine("There are such students: ");
                        Console.WriteLine();
                        foreach (var students in studentReposytory.GetAllStudents())
                        {
                            Console.WriteLine(string.Format("ID: {0}, First name: {1}, Last name: {2}, Birth: {3}, Academic group: {4}",
                                students.Id, students.FirstName, students.LastName, students.Birth, students.Group_number));
                        }
                        Console.WriteLine();
                    }
                    else if (key == "add")
                    {
                        Console.WriteLine("Enter id for new student: ");
                        int ID_for_new_elem = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter first name for new student: ");
                        string Name_for_new_student = Console.ReadLine();
                        Console.WriteLine("Enter last name for new student: ");
                        string Last_name_for_student = Console.ReadLine();
                        Console.WriteLine("enter new date of birth: ");
                        DateTime Date_of_birth = Convert.ToDateTime(Console.ReadLine());
                        Console.WriteLine("enter academic group: ");
                        int Academic_group = int.Parse(Console.ReadLine());
                        studentReposytory.Add(new Student
                        {
                            Id = ID_for_new_elem,
                            FirstName = Name_for_new_student,
                            LastName = Last_name_for_student,
                            Birth = Date_of_birth,
                            Group_number = Academic_group
                        });
                    }
                    else if (key == "update")
                    {
                        Console.WriteLine("Enter id of student u want to update: ");
                        int IdForUpdating = int.Parse(Console.ReadLine());
                        Console.WriteLine("enter new name: ");
                        string NameForUpdating = Console.ReadLine();
                        Console.WriteLine("enter new last name: ");
                        string LastNameForUpdate = Console.ReadLine();
                        Console.WriteLine("enter new date of birth: ");
                        DateTime Date_of_birth = Convert.ToDateTime(Console.ReadLine());
                        Console.WriteLine("enter new academic group: ");
                        int Academic_group = int.Parse(Console.ReadLine());
                        studentReposytory.Update(new Models.Student
                        {
                            Id = IdForUpdating,
                            FirstName = NameForUpdating,
                            LastName = LastNameForUpdate,
                            Birth = Date_of_birth,
                            Group_number = Academic_group
                        });

                    }
                    else if (key == "del")
                    {
                        Console.WriteLine("Enter id of student u want to delete: ");
                        int x = int.Parse(Console.ReadLine());
                        studentReposytory.Delete(new Models.Student
                        {
                            Id = x
                        });
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                Console.WriteLine("-------------------------------");


            } while (key != "b");
        }

        static void SubjectChoice()
        {
            ISubjectReposytory subjectReposytory = Factories.GetFactory().GetSubjectReposytory();
            string key;
            do
            {
                Console.WriteLine("What do u want to do? Get all subjects?(all). Add subject?(add). Update subject?(update). Delete?(del). To back enter (b)");
                key = Console.ReadLine();
                try
                {
                    if(key == "all")
                    {
                        Console.WriteLine("There are such subjects: ");
                        Console.WriteLine();
                        foreach (var subjects in subjectReposytory.GetAllSubjects())
                        {
                            Console.WriteLine(string.Format("ID: {0}, Name: {1}", subjects.Id, subjects.Name));
                        }
                        Console.WriteLine();
                    }
                    else if(key == "add")
                    {
                        Console.WriteLine("Enter id for new subject: ");
                        int ID_for_new_elem = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter name for new subject: ");
                        string Name_for_new_subject = Console.ReadLine();
                        
                        subjectReposytory.Add(new Subject
                        {
                            Id = ID_for_new_elem,
                            Name = Name_for_new_subject
                        });
                    }
                    else if(key == "update")
                    {
                        Console.WriteLine("Enter id of subject u want to update: ");
                        int ID_for_new_elem = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter name for new subject: ");
                        string Name_for_new_subject = Console.ReadLine();

                        subjectReposytory.Update(new Subject
                        {
                            Id = ID_for_new_elem,
                            Name = Name_for_new_subject
                        });
                    }
                    else if(key == "del")
                    {
                        Console.WriteLine("Enter id of subject u want to delete: ");
                        int x = int.Parse(Console.ReadLine());
                        subjectReposytory.DeleteReference(new Models.Subject
                        {
                            Id = x
                        });
                        subjectReposytory.Delete(new Models.Subject
                        {
                            Id = x
                        });
                    }
                }
                catch(Exception e) { Console.WriteLine(e.Message);  continue;}
            } while (key != "b");
        }

        static void LecturerChoice()
        {
            ILecturerReposytory lecturerReposytory = Factories.GetFactory().GetLecturerReposytory();
            string key;
            do
            {
                Console.WriteLine("What do u want to do? Get all subjects?(all). Add subject?(add). Update subject?(update). Delete?(del). To back enter (b)");
                key = Console.ReadLine();
                try
                {
                    if(key == "all")
                    {
                        Console.WriteLine("There are such lecturers: ");
                        Console.WriteLine();
                        foreach (var lecturers in lecturerReposytory.GetAllLecturers())
                        {
                            Console.WriteLine(string.Format("ID: {0}, First name: {1}, Last name: {2}, Reputation: {3}, Phone: {4}",
                                lecturers.Id, lecturers.FirstName, lecturers.LastName, lecturers.Reputation, lecturers.Phone));
                        }
                        Console.WriteLine();
                    }
                    else if(key == "add")
                    {
                        Console.WriteLine("Enter id for new lecturer: ");
                        int ID_for_new_elem = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter first name for new lecturer: ");
                        string Name_for_new_student = Console.ReadLine();
                        Console.WriteLine("Enter last name for new lecturer: ");
                        string Last_name_for_student = Console.ReadLine();
                        Console.WriteLine("enter new reputation: ");
                        int Reputation = int.Parse(Console.ReadLine());
                        Console.WriteLine("enter phone: ");
                        string Phone = Console.ReadLine();
                        lecturerReposytory.Add(new Lecturer
                        {
                            Id = ID_for_new_elem,
                            FirstName = Name_for_new_student,
                            LastName = Last_name_for_student,
                            Reputation = Reputation,
                            Phone = Phone
                        });
                    }
                    else if(key == "update")
                    {
                        Console.WriteLine("Enter id of lecturer u want to update: ");
                        int ID_for_new_elem = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter first name for new lecturer: ");
                        string Name_for_new_student = Console.ReadLine();
                        Console.WriteLine("Enter last name for new lecturer: ");
                        string Last_name_for_student = Console.ReadLine();
                        Console.WriteLine("enter new reputation: ");
                        int Reputation = int.Parse(Console.ReadLine());
                        Console.WriteLine("enter phone: ");
                        string Phone = Console.ReadLine();
                        lecturerReposytory.Update(new Lecturer
                        {
                            Id = ID_for_new_elem,
                            FirstName = Name_for_new_student,
                            LastName = Last_name_for_student,
                            Reputation = Reputation,
                            Phone = Phone
                        });
                    }
                    else if(key == "del")
                    {
                        Console.WriteLine("Enter id of lecturer u want to delete: ");
                        int x = int.Parse(Console.ReadLine());
                        lecturerReposytory.DeleteReference(new Models.Lecturer
                        {
                            Id = x
                        });
                        lecturerReposytory.Delete(new Models.Lecturer
                        {
                            Id = x
                        });
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
            }
            while (key != "b");

        }

        static void AudienceChoice()
        {
            IAudienceReposytory audienceReposytory = Factories.GetFactory().GetAudienceReposytory();
            string key;
            do
            {
                Console.WriteLine("What do u want to do? Get all audiences?(all). Add audience?(add). Update?(update). Delete?(del). To back enter (b)");
                key = Console.ReadLine();
                try
                {
                    if(key == "all")
                    {
                        Console.WriteLine("There are such audiences: ");
                        Console.WriteLine();
                        foreach (var audiences in audienceReposytory.GetAllAudiences())
                        {
                            Console.WriteLine(string.Format("ID: {0}, Number: {1}",
                                                            audiences.Id, audiences.Number));
                        }
                        Console.WriteLine();
                    }
                    else if(key == "add")
                    {
                        Console.WriteLine("Enter id for new audience: ");
                        int ID_for_new_elem = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter number for new audience: ");
                        int Number_for_new_subject = int.Parse(Console.ReadLine());

                        audienceReposytory.Add(new Audience
                        {
                            Id = ID_for_new_elem,
                            Number = Number_for_new_subject
                        });
                    }
                    else if(key == "update")
                    {
                        Console.WriteLine("Enter id for new audience: ");
                        int ID_for_new_elem = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter number for new audience: ");
                        int Number_for_new_subject = int.Parse(Console.ReadLine());

                        audienceReposytory.Update(new Audience
                        {
                            Id = ID_for_new_elem,
                            Number = Number_for_new_subject
                        });
                    }
                    else if(key == "del")
                    {
                        Console.WriteLine("Enter id of audience u want to delete: ");
                        int x = int.Parse(Console.ReadLine());
                        audienceReposytory.DeleteReference(new Models.Audience
                        {
                            Id = x
                        });
                        audienceReposytory.Delete(new Models.Audience
                        {
                            Id = x
                        });
                    }
                }
                catch( Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
            }
            while (key != "b");
        }

        static void GroupChoice()
        {
            IGroupReposytory groupReposytory = Factories.GetFactory().GetGroupReposytory();
            string key;
            do
            {
                Console.WriteLine("What do u want to do? Get all groups?(all). Add group?(add). Update subject?(update). Delete?(del). To back enter (b)");
                key = Console.ReadLine();
                try
                {
                    if(key == "all")
                    {
                        Console.WriteLine("There are such groups: ");
                        Console.WriteLine();
                        foreach (var groups in groupReposytory.GetAllGroups())
                        {
                            Console.WriteLine(string.Format("ID: {0}, Name: {1}",
                                groups.Id, groups.Name));
                        }
                        Console.WriteLine();
                    }
                    else if(key == "add")
                    {
                        Console.WriteLine("Enter id for new group: ");
                        int ID_for_new_group = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter name for new group: ");
                        string Name_for_new_group = Console.ReadLine();
                        groupReposytory.Add(new Groups
                        {
                            Id = ID_for_new_group,
                            Name = Name_for_new_group
                        });
                    }
                    else if(key == "update")
                    {
                        Console.WriteLine("Enter id of group u want to update: ");
                        int IdForUpdating = int.Parse(Console.ReadLine());
                        Console.WriteLine("enter new number");
                        string NumberForUpdating = Console.ReadLine();
                        groupReposytory.Update(new Models.Groups
                        {
                            Id = IdForUpdating,
                            Name = NumberForUpdating

                        });
                    }
                    else if(key == "del")
                    {
                        Console.WriteLine("Enter id of group u want to delete: ");
                        int x = int.Parse(Console.ReadLine());
                        groupReposytory.DeleteReference(new Models.Groups
                        {
                            Id = x
                        });
                        groupReposytory.Delete(new Models.Groups
                        {
                            Id = x
                        });
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
            } while (key != "b");
        }

        static void GetAllData()
        {
            IAudienceReposytory audienceReposytory = Factories.GetFactory().GetAudienceReposytory();
            IGroupReposytory groupReposytory = Factories.GetFactory().GetGroupReposytory();
            ILessonReposytory lessonReposytory = Factories.GetFactory().GetLessonReposytory();
            ILecturerReposytory lecturerReposytory = Factories.GetFactory().GetLecturerReposytory();
            IHistoryReposytory historyReposytory = Factories.GetFactory().GetHistoryReposytory();
            IStudentReposytory studentReposytory = Factories.GetFactory().GetStudentReposytory();
            ISubjectReposytory subjectReposytory = Factories.GetFactory().GetSubjectReposytory();
            Console.WriteLine("************Shedule************");
            Console.WriteLine();
            foreach (var lessons in lessonReposytory.GetAllLessons())
            {
                Console.WriteLine(string.Format("ID: {0}, Subject: {1}, Lecturer: {2}, Audience: {3}, " +
                    "Academic group: {4},Time:{5}, Day: {6}, Type: {7}",
                    lessons.Id, lessons.Subject, lessons.Lecturer, lessons.Audience, lessons.Academic_group, lessons.Time, lessons.Day, lessons.Type));
            }
            Console.WriteLine();
            Console.WriteLine("There are such audiences: ");
            Console.WriteLine();
            foreach (var audiences in audienceReposytory.GetAllAudiences())
            {
                Console.WriteLine(string.Format("ID: {0}, Number: {1}",
                                                audiences.Id, audiences.Number));
            }
            Console.WriteLine();
            Console.WriteLine("There are such groups: ");
            Console.WriteLine();
            foreach (var groups in groupReposytory.GetAllGroups())
            {
                Console.WriteLine(string.Format("ID: {0}, Name: {1}",
                    groups.Id, groups.Name));
            }
            Console.WriteLine();
            Console.WriteLine("There are such lecturers: ");
            Console.WriteLine();
            foreach (var lecturers in lecturerReposytory.GetAllLecturers())
            {
                Console.WriteLine(string.Format("ID: {0}, First name: {1}, Last name: {2}, Reputation: {3}, Phone: {4}",
                    lecturers.Id, lecturers.FirstName, lecturers.LastName, lecturers.Reputation, lecturers.Phone));
            }
            Console.WriteLine();
            Console.WriteLine("There are such students: ");
            Console.WriteLine();
            foreach (var students in studentReposytory.GetAllStudents())
            {
                Console.WriteLine(string.Format("ID: {0}, First name: {1}, Last name: {2}, Birth: {3}, Academic group: {4}",
                    students.Id, students.FirstName, students.LastName, students.Birth, students.Group_number));
            }
            Console.WriteLine();
            Console.WriteLine("There are such subjects: ");
            Console.WriteLine();
            foreach (var subjects in subjectReposytory.GetAllSubjects())
            {
                Console.WriteLine(string.Format("ID: {0}, Name: {1}", subjects.Id, subjects.Name));
            }
            Console.WriteLine();
            Console.WriteLine("History of using database: ");
            foreach(var history in historyReposytory.GetAllHistory())
            {
                Console.WriteLine(string.Format("ID: {0}, Lesson ID: {1}, Operation: {2}, Time: {3}",
                    history.Id, history.Lesson_ID, history.Operation, history.OnTime));
            }
        }
    }
}
