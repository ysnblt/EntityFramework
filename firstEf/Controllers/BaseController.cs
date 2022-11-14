using firstEf.Context;
using Microsoft.AspNetCore.Mvc;

namespace firstEf.Controllers
{
    public class BaseController : Controller
    {
       public  PerContext _db;   
        public BaseController(PerContext db)
        {
            _db = db;
        }
    }
}
