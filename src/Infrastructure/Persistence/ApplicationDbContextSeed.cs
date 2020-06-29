﻿using Maturnik.Domain.Entities;
using Maturnik.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maturnik.Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedDefaultUserAsync(UserManager<ApplicationUser> userManager)
        {
            var defaultUser = new ApplicationUser { UserName = "administrator@localhost", Email = "administrator@localhost" };

            if (userManager.Users.All(u => u.UserName != defaultUser.UserName))
            {
                await userManager.CreateAsync(defaultUser, "Fr3s7ed23@");
            }
        }

        public static async Task SeedSampleSchoolSubjects(ApplicationDbContext context)
        {
            if (!context.SchoolSubjects.Any())
            {
                List<SchoolSubject> subjects = new List<SchoolSubject>()
                {
                    new SchoolSubject("Математика"),
                    new SchoolSubject("Български език"),
                    new SchoolSubject("Химия"),
                    new SchoolSubject("Биология"),
                    new SchoolSubject("Психология"),
                    new SchoolSubject("История"),
                    new SchoolSubject("География"),
                    new SchoolSubject("Информационни технологии")
                };

                await context.SchoolSubjects.AddRangeAsync(subjects);
                await context.SaveChangesAsync();
            }
        }

        public static async Task SeedExams(ApplicationDbContext context)
        {
            if (!context.Exams.Any())
            {
                Exam[] exams =
                {
                    new Exam(){ ExamType = ExamType.Bulgarian, YearOfCreation = 2019 },
                    new Exam(){ ExamType = ExamType.Bulgarian, YearOfCreation = 2018 },
                    new Exam(){ ExamType = ExamType.Bulgarian, YearOfCreation = 2017 },
                    new Exam(){ ExamType = ExamType.Bulgarian, YearOfCreation = 2016 },
                    new Exam(){ ExamType = ExamType.Bulgarian, YearOfCreation = 2015 },
                    new Exam(){ ExamType = ExamType.Math, YearOfCreation = 2019 },
                    new Exam(){ ExamType = ExamType.Math, YearOfCreation = 2018 },
                    new Exam(){ ExamType = ExamType.Math, YearOfCreation = 2017 },
                    new Exam(){ ExamType = ExamType.Math, YearOfCreation = 2016 },
                    new Exam(){ ExamType = ExamType.Math, YearOfCreation = 2015 },
                    new Exam(){ ExamType = ExamType.English, YearOfCreation = 2019 },
                    new Exam(){ ExamType = ExamType.English, YearOfCreation = 2018 },
                    new Exam(){ ExamType = ExamType.English, YearOfCreation = 2017 },
                    new Exam(){ ExamType = ExamType.English, YearOfCreation = 2016 },
                    new Exam(){ ExamType = ExamType.English, YearOfCreation = 2015 },
                    new Exam(){ ExamType = ExamType.Geography, YearOfCreation = 2019 },
                    new Exam(){ ExamType = ExamType.Geography, YearOfCreation = 2018 },
                    new Exam(){ ExamType = ExamType.Geography, YearOfCreation = 2017 },
                    new Exam(){ ExamType = ExamType.Geography, YearOfCreation = 2016 },
                    new Exam(){ ExamType = ExamType.Geography, YearOfCreation = 2015 },
                    new Exam(){ ExamType = ExamType.History, YearOfCreation = 2019 },
                    new Exam(){ ExamType = ExamType.History, YearOfCreation = 2018 },
                    new Exam(){ ExamType = ExamType.History, YearOfCreation = 2017 },
                    new Exam(){ ExamType = ExamType.History, YearOfCreation = 2016 },
                    new Exam(){ ExamType = ExamType.History, YearOfCreation = 2015 },
                    new Exam(){ ExamType = ExamType.Psychology, YearOfCreation = 2019 },
                    new Exam(){ ExamType = ExamType.Psychology, YearOfCreation = 2018 },
                    new Exam(){ ExamType = ExamType.Psychology, YearOfCreation = 2017 },
                    new Exam(){ ExamType = ExamType.Psychology, YearOfCreation = 2016 },
                    new Exam(){ ExamType = ExamType.Psychology, YearOfCreation = 2015 },
                    new Exam(){ ExamType = ExamType.Biology, YearOfCreation = 2019 },
                    new Exam(){ ExamType = ExamType.Biology, YearOfCreation = 2018 },
                    new Exam(){ ExamType = ExamType.Biology, YearOfCreation = 2017 },
                    new Exam(){ ExamType = ExamType.Biology, YearOfCreation = 2016 },
                    new Exam(){ ExamType = ExamType.Biology, YearOfCreation = 2015 }
                };

                await context.Exams.AddRangeAsync(exams);
                await context.SaveChangesAsync();
            }
        }

        public static async Task SeedQuestionsAnswers(ApplicationDbContext context)
        {
            if (!context.Questions.Any())
            {
                string examId = context.Exams.FirstOrDefault(x => x.YearOfCreation == 2019 && x.ExamType == ExamType.Bulgarian).Id;

                Question[] questions =
                {
                    //1
                    new Question(2, examId)
                    {
                        QuestionNumber = 1,
                        IsOpenAnswer = false,
                        IsSingleAnswer = true,
                        Title = "В кой ред е допусната правописна грешка?",
                        Answers = new HashSet<Answer>()
                        {
                            new Answer("вървящи, стреляли, запели"),
                            new Answer("утроявам, овиквам, укупирам"),
                            new Answer("ситуации, пороища, медийни"),
                            new Answer("дръвник, закърпвам, вдлъбнат"),
                        }
                    },
                    //2
                    new Question(3, examId)
                    {
                        QuestionNumber = 2,
                        IsOpenAnswer = false,
                        IsSingleAnswer = true,
                        Title = "В кой ред е допусната правописна грешка?",
                        Answers = new HashSet<Answer>()
                        {
                            new Answer("водолаз, мираж, кардиолог"),
                            new Answer("искрен, братовчедка, разтвор"),
                            new Answer("тягостна, шестотин, прелест"),
                            new Answer("сбирка, сгъвам, сглобявам"),
                        }
                    },
                    //3
                    new Question(3, examId)
                    {
                        QuestionNumber = 3,
                        IsOpenAnswer = false,
                        IsSingleAnswer = true,
                        Title = "В кое изречение е допусната правописна грешка?",
                        Answers = new HashSet<Answer>()
                        {
                            new Answer("Нуждаем се от специалисти, които да отговарят за техническата поддръжка на машините."),
                            new Answer("В началото на летния сезон предстои да започнат снимките на най-новия български сериал."),
                            new Answer("Учените предупредиха, че популацията на египетските лешояди намалява с 7% на година."),
                            new Answer("При почистването на кошерите пчеларят задължително трябва да е с предпазно облекло."),
                        }
                    },
                    //4
                    new Question(3, examId)
                    {
                        QuestionNumber = 4,
                        IsOpenAnswer = false,
                        IsSingleAnswer = true,
                        Title = "В кое изречение е допусната правописна грешка?",
                        Answers = new HashSet<Answer>()
                        {
                            new Answer("Популярният актьор обяви, че е решил да сложи край на своята 50-годишна кариера в театъра и в киното."),
                            new Answer("Изложбата на известния художник модернист беше открита миналата седмица в новата галерия."),
                            new Answer("Целта на всеки електронен търговец е да привлече възможно най-много посетители на своята уеб-страница."),
                            new Answer("В интервю боксьорът сподели, че винаги е бил възпитаван да се труди и да не чака успехите наготово."),
                        }
                    },
                    //5
                    new Question(3, examId)
                    {
                        QuestionNumber = 5,
                        IsOpenAnswer = false,
                        IsSingleAnswer = true,
                        Title = "В кое изречение е допусната правописна грешка?",
                        Answers = new HashSet<Answer>()
                        {
                            new Answer("Националното състезание по счетоводство ще се проведе в една от Професионалните гимназии в столицата."),
                            new Answer("По време на посещението си в града всички гости ще се запознаят с особеностите на архитектурата на барока."),
                            new Answer("Утре експертите ще представят публично обобщените резултати от проведеното оценяване по математика."),
                            new Answer("През седмицата в Панагюрище тържествено ще бъде отбелязана годишнината от рождението на Райна Княгиня."),
                        }
                    },
                    new Question(5, examId)
                    {
                        QuestionNumber = 6,
                        IsOpenAnswer = false,
                        IsSingleAnswer = true,
                        Title = @"ТЕКСТ 1\nС богатството си от форми, багри и украси българските народни носии са запечатали бита и традициите на българина. Традиционните народни костюми съставляват един от значителните по съдържание дялове на българската материална култура. Носията свидетелства за богати знания у народа относно свойствата на текстилните материали – въздухопроницаемост, топлозащитност, хигроскопичност и др. Не е случайно, че в зноя на жътвата се предпочитат дрехи от ленени тъкани, които лесно поглъщат и лесно изпаряват влагата. Така кожата се охлажда. Топлозащитността и  хигроскопичността са свойствата, заради които народът предпочита вълнените тъкани при работа в планината и при зимни условия.
                                Българските народни носии имат множество разнообразни компоненти, т.е. те са със сложен състав. Пълната премяна, която се облича на празници и тържества, включва значителен брой дрехи и допълнителни принадлежности, украшения и накити. Народният костюм е свързан с усилената полска и домакинска работа. Горни дрехи при женските костюми са сукманът и саята. Във всички народни носии (мъжки и женски) основна дреха е ризата, наричана в някои части на България кошуля. Шие се от ленено,конопено или памучно платно. Тя е дълга и е с ръкави. Към основния състав на женските костюми принадлежи престилката, а на мъжките – поясът. Принадлежностите, свързани с прическата, украсата и покриването на косата при жените, също са част от костюма, както и коженият калпак при мъжете. Обединяващ елемент на българските народни носии са кожените цървули (опинци), които имат лодковидна форма, тъп или остър връх и върви, които се стягат при използване на цървулите.
                                Освен основното си предназначение – да предпазва тялото от климатичните влияния и да улеснява трудовата дейност, българският народен костюм изпълнява функцията на социален знак, тъй като носията, отделните дрехи, допълнителните части или видът украса отразяват половото или възрастовото деление, семейното положение, местожителството, принадлежността към даден слой от обществото. \n
                                ТЕКСТ 2\nИзвестен дизайнер споделя в ефир, че начинът, по който избираме, комбинираме и носим дрехи, отразява, независимо дали сме наясно, или не, чертите на нашата личност и начина ни на живот. Нещо повече – дрехите говорят много за нас, преди още да имаме възможността да се изразим с думи. Тук обаче не става въпрос за работна или за военна униформа, а за всекидневно и за официално облекло. Всеки стил на обличане има своите особености. Ако ги познаваме, няма да имаме съмнение, че сме неподходящо облечени в конкретна ситуация. Независимо обаче кой стил ще изберем, дрехите – като модели и цветове – трябва да отговарят и на възрастта, и на фигурата ни.
                                Начинът, по който се обличаме, зависи както от нас самите, от нашите предпочитания и възможности, така и от мястото и събитието, на което ще се появим. Важното е облеклото ни да не издава безвкусица или неуместност. Облеклото може да варира от обикновено до официално, от просто до екстравагантно, от елегантно до грубо и съответно да принадлежи към даден стил. Представяме ви най-често срещаните стилове: спортен, небрежен, делови.
                                Ако смятате, че имате нужда от хронометър, за да се справите с натоварения си дневен график, изберете спортния стил. Той е за предпочитане и заради удобството на кройките и материите, които предлагат подобни дрехи. Възможните облекла са широките тениски, потниците, анцузите, шортите, а за жените също роклите и полите с прави линии. Обувките са кецове или маратонки.
                                Близък до спортния стил е небрежният, наричан още свободен. Той включва разнообразни облекла и е подходящ не само за неформални срещи, но и за офиса. Можете да бъдете с джинси, дънки, ризи, сака, пуловери или блузи и да сте със спортни обувки. Ако жената реши да е по-елегантна, вместо дънки може да облече панталон или пола с изчистена кройка и подходяща дължина, а също и да бъде с по-официални обувки.
                                Костюмите, обикновено в черно, тъмносиньо или сиво, както и белите ризи са „запазена марка“ на деловия стил. Класическите сака, панталоните, ризите, полите – всички в неярки цветове, в съчетание с вратовръзки, елегантни колани и други аксесоари, както и официалните обувки допълват този стил на обличане, който е подходящ за бизнес, научни и други официални срещи и форуми или за работа в учреждение, фирма, офис, банка и под.",
                        Answers = new HashSet<Answer>()
                        {
                            new Answer(" "),
                            new Answer(" "),
                            new Answer(" "),
                            new Answer(" "),
                        }
                    },
                    new Question(5, examId)
                    {
                        QuestionNumber = 7,
                        IsOpenAnswer = false,
                        IsSingleAnswer = true,
                        Title =@"От коя сфера на общуване е Текст 1?",
                        Answers = new HashSet<Answer>()
                        {
                            new Answer("от естетическата сфера"),
                            new Answer("от научната сфера"),
                            new Answer("от битовата сфера"),
                            new Answer("от институционалната сфера"),
                        }
                    },
                    new Question(3, examId)
                    {
                        QuestionNumber = 8,
                        IsOpenAnswer = false,
                        IsSingleAnswer = true,
                        Title = "Кое от посочените твърдения е вярно за Текст 1?",
                        Answers = new HashSet<Answer>()
                        {
                            new Answer("Текстът изтъква предимствата на женската народна носия пред мъжката."),
                            new Answer("Текстът посочва разликата между традиционните и съвременните облекла."),
                            new Answer("Текстът представя характерни особености на българските народни носии."),
                            new Answer("Текстът акцентира върху ползата от съхранението на народните носии."),
                        }
                    },
                    new Question(1, examId)
                    {
                        QuestionNumber = 9,
                        IsOpenAnswer = false,
                        IsSingleAnswer = true,
                        Title = "Използваната в Текст 1 дума хигроскопичност е:",
                        Answers = new HashSet<Answer>()
                        {
                            new Answer("езикова единица от терминологичната лексика"),
                            new Answer("езикова единица от юридическата лексика"),
                            new Answer("експресивно натоварена езикова единица"),
                            new Answer("езикова единица от териториален диалект"),
                        }
                    },
                    new Question(3, examId)
                    {
                        QuestionNumber = 10,
                        IsOpenAnswer = false,
                        IsSingleAnswer = true,
                        Title = "Кое от посочените твърдения НЕ е вярно според Текст 1?",
                        Answers = new HashSet<Answer>()
                        {
                            new Answer("Българските народни носии се отличават с разнообразието си от компоненти."),
                            new Answer("Носиите са свидетелства за знанията на хората за свойствата на материите."),
                            new Answer("Ризата е неотделима и характерна част само за мъжката народна носия."),
                            new Answer("Общ елемент при женските и мъжките народни носии са цървулите."),
                        }
                    },
                };

                await context.Questions.AddRangeAsync(questions);
                await context.SaveChangesAsync();
            }
        }

        public static async Task LogException(ApplicationDbContext context, Exception exception)
        {
            if(exception.InnerException != null)
            {
                context.Exceptions.Add(new CustomException($"Inner Exception: " + exception.InnerException?.Message));
            }

            context.Exceptions.Add(new CustomException(exception.Message));
            await context.SaveChangesAsync();
        }
    }
}
