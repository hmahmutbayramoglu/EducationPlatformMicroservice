using AutoMapper;
using EducationPlatformMicroservice.Catalog.Api.Features.Courses.Dtos;
using EducationPlatformMicroservice.Catalog.Api.Repositories;

namespace EducationPlatformMicroservice.Catalog.Api.Features.Courses.GetById
{
    public class GetCourseByIdQueryHandler(AppDbContext context, IMapper mapper)
        : IRequestHandler<GetCourseByIdQuery, ServiceResult<CourseDto>>
    {
        public async Task<ServiceResult<CourseDto>> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
        {
            //ileride farklı ilişikisel bir db olursa include kullanılabilir. Şimdilik mongodb ilişkisel olmadığı için include kullanamıyoruz. Bu yüzden categoryyi ayrı çekiyoruz.
            //var hasCourse = await context.Courses
            //    .Include(context => context.Category)
            //    .Include(context => context.Feature).FirstOrDefaultAsync(context => context.Id == request.Id, cancellationToken);

            var hasCourse = await context.Courses.FirstOrDefaultAsync(context => context.Id == request.Id, cancellationToken);

            if (hasCourse is null)
            {
                return ServiceResult<CourseDto>.Error("Course not found", $"The course with id {request.Id} was not found",
                    HttpStatusCode.NotFound);
            }

            var category = await context.Categories.FindAsync(hasCourse.CategoryId, cancellationToken);
            hasCourse.Category = category!;

            var courseDto = mapper.Map<CourseDto>(hasCourse);
            return ServiceResult<CourseDto>.SuccessAsOk(courseDto);

        }
    }
}
