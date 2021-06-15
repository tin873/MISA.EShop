using Microsoft.AspNetCore.Mvc;
using MISA.Eshop.Core.Entities;
using MISA.Eshop.Core.Interfaces.IService;

namespace MISA.Eshop.API.Controllers
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class CountryController : EShopBaseController<Country>
    {
        public CountryController(IBaseService<Country> baseService): base(baseService)
        { }
    }
}
