using Maturnik.Application.Common.Interfaces;
using Maturnik.Domain.Entities;
using Maturnik.WebUI.Shared.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Maturnik.Application.SchoolSubjects.Queries.All
{
    public class AllSchoolSubjectsHandler : IRequestHandler<AllSchoolSubjectsQuery, ApiResponse<AllSchoolSubjectsViewModel>>
    {
        private readonly IApplicationDbContext dbContext;

        public AllSchoolSubjectsHandler(IApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ApiResponse<AllSchoolSubjectsViewModel>> Handle(AllSchoolSubjectsQuery request, CancellationToken cancellationToken)
        {
            var subjects = await dbContext.SchoolSubjects.Select(s => new SchoolSubjectsViewModel(s.Name)).ToListAsync();
            var vm = new AllSchoolSubjectsViewModel(subjects);

            return ApiResponse<AllSchoolSubjectsViewModel>.Success(vm);
        }
    }
}
