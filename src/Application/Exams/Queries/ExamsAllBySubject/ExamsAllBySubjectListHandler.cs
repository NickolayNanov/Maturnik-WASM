using Maturnik.Application.Common;
using Maturnik.Application.Common.Interfaces;
using Maturnik.Application.Exams.Queries.ExamsAll;
using Maturnik.Domain.Entities;
using Maturnik.Domain.Enums;
using Maturnik.WebUI.Shared.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Maturnik.Application.Exams.Queries.ExamsAllBySubject
{
    public class ExamsAllBySubjectListHandler : IRequestHandler<ExamsAllBySubjectQuery, ApiResponse<ExamsAllBySubjectListViewModel>>
    {
        private readonly IApplicationDbContext dbContext;

        public ExamsAllBySubjectListHandler(IApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ApiResponse<ExamsAllBySubjectListViewModel>> Handle(ExamsAllBySubjectQuery request, CancellationToken cancellationToken)
        {
            ExamType examType = (ExamType)Enum.Parse(typeof(ExamType), request.ExamTypeUrl);

            IEnumerable<ExamViewModel> exams = await dbContext.Exams.AsNoTracking()
                                             .Where(x => x.ExamType == examType)
                                             .Select(x => new ExamViewModel(x.Id, 
                                                                            x.ExamType.ToString(), 
                                                                            ExamTypeExtensions.Parse(x), 
                                                                            x.YearOfCreation))
                                             .ToListAsync();

            ExamsAllBySubjectListViewModel vm = new ExamsAllBySubjectListViewModel(exams);
            return ApiResponse<ExamsAllBySubjectListViewModel>.Success(vm);
        }
    }
}
