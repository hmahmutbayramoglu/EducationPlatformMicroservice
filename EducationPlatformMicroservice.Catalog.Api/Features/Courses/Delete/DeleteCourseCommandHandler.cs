using AutoMapper;
using EducationPlatformMicroservice.Catalog.Api.Repositories;

namespace EducationPlatformMicroservice.Catalog.Api.Features.Courses.Delete
{
    public class DeleteCourseCommandHandler(AppDbContext context) : IRequestHandler<DeleteCourseCommand, ServiceResult>
    {
        public async Task<ServiceResult> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {
            var hasCourse = await context.Courses.FindAsync(new object[] { request.CourseId }, cancellationToken);

            if (hasCourse == null)
            {
                return ServiceResult.ErrorAsNotFound();
            }


            context.Courses.Remove(hasCourse);
            await context.SaveChangesAsync(cancellationToken);

            return ServiceResult.SuccessAsNoContent();

        }
    }
}
