using Maturnik.Application.Common;
using Maturnik.Application.Common.Interfaces;
using Maturnik.WebUI.Shared.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Maturnik.Application.Exams.Queries.ExamsAll
{
    public class AllExamsHandler : IRequestHandler<AllExamsQuery, ApiResponse<ExamsAllViewModel>>
    {
        private readonly IApplicationDbContext dbContext;

        public AllExamsHandler(IApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ApiResponse<ExamsAllViewModel>>Handle(AllExamsQuery request, CancellationToken cancellationToken)
        {
            var exams = await dbContext.SchoolSubjects
                                    .Select(x => new ExamViewModel(null, 
                                                                   ExamTypeExtensions.ReverseParseStr(x.Name),
                                                                   x.Name,
                                                                   0)).ToListAsync();

            ExamsAllViewModel vm = new ExamsAllViewModel(exams);
            return ApiResponse<ExamsAllViewModel>.Success(vm);
        }
    }
}
