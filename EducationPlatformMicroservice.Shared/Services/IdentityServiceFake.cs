using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatformMicroservice.Shared.Services
{
    public class IdentityServiceFake : IIdentityService
    {
        public Guid GetUserId => Guid.Parse("7430ed03-4e1c-4fc4-b4a0-6056b2fad000");

        public string GetUserName => "MahmutH36";
    }
}
