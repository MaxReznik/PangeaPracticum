using Microsoft.AspNetCore.Mvc;
using PangeaPracticum.lib;
using PangeaPracticum.lib.Domain;

namespace PangeaPracticum.Controllers
{
    [Route("[controller]")]
    public class RepositoriesController : Controller
    {
        IRepositoryService _repoService;

        public RepositoriesController(IRepositoryService repoService)
        {
            _repoService = repoService;
        }

        [HttpGet]
        public Repo[] Get()
        {
            return _repoService.GetAll();
        }
    }
}
