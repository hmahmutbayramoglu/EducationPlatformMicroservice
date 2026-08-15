using AutoMapper;
using EducationPlatformMicroservice.Catalog.Api.Features.Courses.Dtos;
using EducationPlatformMicroservice.Catalog.Api.Repositories;

namespace EducationPlatformMicroservice.Catalog.Api.Features.Courses.GetAllByUserId
{
    public class GetAllCourseByUserIdQueryHandler(AppDbContext context, IMapper mapper) : IRequestHandler<GetAllCourseByUserIdQuery, ServiceResult<List<CourseDto>>>
    {
        public async Task<ServiceResult<List<CourseDto>>> Handle(GetAllCourseByUserIdQuery request, CancellationToken cancellationToken)
        {

            var courses = await context.Courses.Where(x => x.CreatorUserId == request.Id)
                .ToListAsync(cancellationToken);
            var categories = await context.Categories.ToListAsync(cancellationToken);

            foreach (var course in courses)
            {
                course.Category = categories.First(c => c.Id == course.CategoryId);
            }

            var courseDtos = mapper.Map<List<CourseDto>>(courses);
            return ServiceResult<List<CourseDto>>.SuccessAsOk(courseDtos);

        }

      
    }


}
