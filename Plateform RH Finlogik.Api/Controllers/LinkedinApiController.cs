using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Plateform_RH_Finlogik.Application.Contracts.Persistance;
using Plateform_RH_Finlogik.Application.Features;
using Plateform_RH_Finlogik.Domain.Entities;
using RestSharp;
using System.Net.Http.Headers;
using System.Text;

namespace Plateform_RH_Finlogik.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinkedinApiController : ControllerBase
    {
        private readonly IOfferRepository _offerRepository;
        public LinkedinApiController(IOfferRepository offerRepository)
        {
            _offerRepository = offerRepository;
        }
        [HttpPost(Name = "PostCodeLinkedin")]

        public async Task PostCodeLinkedin(string code, [FromBody] OfferID idoffer)

        {
            var handler = new HttpClientHandler();
            handler.UseCookies = false;

         
            using (var httpClient = new HttpClient(handler))
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://www.linkedin.com/oauth/v2/accessToken?grant_type=authorization_code&code="+code+"&redirect_uri=http://localhost:4200/Offers&client_id=78garf686nkvua&client_secret=CugNTNdxohLAgzyt"))
                {
                    request.Headers.TryAddWithoutValidation("Cookie", "bcookie=\"v=2&6597299a-9f3d-4af0-814f-e84b092ee491\"; lang=v=2&lang=en-us; lidc=\"b=TB81:s=T:r=T:a=T:p=T:g=2823:u=256:x=1:i=1650203637:t=1650227421:v=2:sig=AQEE0H5pG0i6E2QJnNDeEWNc2_G6o8mx\"; bscookie=\"v=1&20220416234020ba4aca83-7415-4f12-8110-9df47a4e8630AQH-2t2zgqRPBqIfLWEqkxOUaiiDflVV\"");


                    var response = httpClient.SendAsync(request).Result;
                    var content = response.Content.ReadAsStringAsync().Result;
                    string AccessToken = JObject.Parse(content)["access_token"].ToString();


                    var handler2 = new HttpClientHandler();
                    handler2.UseCookies = false;

                    using (var httpClient2 = new HttpClient(handler2))
                    {
                        using (var request2 = new HttpRequestMessage(new HttpMethod("GET"), "https://api.linkedin.com/v2/me"))
                        {
                            request2.Headers.TryAddWithoutValidation("Authorization", "Bearer "+ AccessToken);
                            request2.Headers.TryAddWithoutValidation("Cookie", "bcookie=\"v=2&6597299a-9f3d-4af0-814f-e84b092ee491\"; lang=v=2&lang=en-us; lidc=\"b=TB81:s=T:r=T:a=T:p=T:g=2823:u=256:x=1:i=1650203637:t=1650227421:v=2:sig=AQEE0H5pG0i6E2QJnNDeEWNc2_G6o8mx\"");

                            
                            
                            
                            var response2 = await httpClient2.SendAsync(request2);
                             content = response2.Content.ReadAsStringAsync().Result;

                        
                            string Id = JObject.Parse(content)["id"].ToString();


                            var handler3 = new HttpClientHandler();
                            handler3.UseCookies = false;

                            using (var httpClient3 = new HttpClient(handler3))
                            {
                                Offer offer = await _offerRepository.GetByIDAsync(idoffer.id);
                                using (var request3 = new HttpRequestMessage(new HttpMethod("POST"), "https://api.linkedin.com/v2/ugcPosts"))
                                {
                                    request3.Headers.TryAddWithoutValidation("Authorization", "Bearer " + AccessToken);
                                    request3.Headers.TryAddWithoutValidation("Cookie", "bcookie=\"v=2&6597299a-9f3d-4af0-814f-e84b092ee491\"; lang=v=2&lang=en-us");

                                    request3.Content = new StringContent("{\n    \"author\": \"urn:li:person:"+Id+ "\",\n    \"lifecycleState\": \"PUBLISHED\",\n    \"specificContent\": {\n        \"com.linkedin.ugc.ShareContent\": {\n            \"shareCommentary\": {\n        \"text\": \" hello Linkedin ,"+offer.OfferName+""+offer.OfferDescription +"\" \n            },\n            \"shareMediaCategory\": \"NONE\"\n        }\n    },\n    \"visibility\": {\n        \"com.linkedin.ugc.MemberNetworkVisibility\": \"PUBLIC\"\n    }\n}");
                                    request3.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                                    var response3 = await httpClient.SendAsync(request3);

                                    var content3 = response3.Content.ReadAsStringAsync().Result;


                                }
                            }




                        }
                    }



                }
            }
        }

    }
}