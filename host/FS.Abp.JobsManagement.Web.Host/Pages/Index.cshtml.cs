using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace FS.Abp.JobsManagement.Pages
{
    public class IndexModel : JobsManagementPageModel
    {
        public void OnGet()
        {
            
        }

        public async Task OnPostLoginAsync()
        {
            await HttpContext.ChallengeAsync("oidc");
        }
    }
}