using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace Plateform_RH_Finlogik.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinkedinApiController : ControllerBase
    {
        [HttpPost(Name = "PostCodeLinkedin")]

        public async Task PostCodeLinkedin(string code)
        {
            using (var client = new HttpClient())
            {



                //HTTP POST
                var postTask = client.PostAsync("https://www.linkedin.com/oauth/v2/accessToken?grant_type=authorization_code&code=" + code + "&redirect_uri=http://localhost:4200/Offers&client_id=78garf686nkvua&client_secret=CugNTNdxohLAgzyt?grant_type=authorization_code&code="+code+"&redirect_uri=http://localhost:4200/Offers&client_id=78garf686nkvua&client_secret=CugNTNdxohLAgzyt", null);

                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {

                }


            }
        }
    }
}