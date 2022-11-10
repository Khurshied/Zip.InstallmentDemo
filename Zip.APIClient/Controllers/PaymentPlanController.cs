using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Zip.APIClient.Models.Request;
using Zip.APIClient.Models.Response;
using Zip.InstallmentsService;

namespace Zip.APIClient.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    [ApiVersion("1.0")]
    public class PaymentPlanController : ControllerBase
    {
        [HttpGet(Name = "Installments")]
        [MapToApiVersion("1.0")]
        public IActionResult Installments([Required]decimal PurchaseAmount)
        {
            try
            {
                PaymentPlanFactory paymentPlan = new PaymentPlanFactory();
                var result = paymentPlan.CreatePaymentPlan(PurchaseAmount);
                return Ok(new ServiceResponse { Data=result,Message="Payment Plan Created Succesffully", Status=true});
            }
            catch (Exception)
            {
                return BadRequest(new ServiceResponse {Message = "Unexpected error occured", Status= false });              
            }                        
        }
    }
}