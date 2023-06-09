using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using Webhelp.Rh.Domain.Entities.Candidate.Services;
using Webhelp.Rh.Web.ViewModel;

namespace Webhelp.Rh.Web.Controllers
{
    public class TechnologyController : Controller
    {
        private readonly ITechnologyService _technologyService;

        public TechnologyController(ITechnologyService technologyService)
        {
            _technologyService = technologyService;
        }
        // GET: Technology
        public async Task<ActionResult> Index()
        {
            var technologies = await _technologyService.GetAll();
            return View(technologies);
        }

        [HttpGet]
        public async Task<ActionResult> Vacancy(Guid id)
        {
            TechnologyViewModel model = new TechnologyViewModel() { Id = id, Name = "name" };
            //await _service.GetById(id);

            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var technology = await _technologyService.GetAll();
            return View(technology);
        }

        [HttpPost]
        public async Task<ActionResult> Create(TechnologyViewModel technology)
        {
            if (ModelState.IsValid)
            {
                await _technologyService.Create(technology.Name);

                return RedirectToAction("Index");
            }

            return View(technology);
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            var create = new TechnologyViewModel();

            return View(create);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(TechnologyViewModel technology)
        {
            try
            {
                await _technologyService.Update(technology.Id, technology.Name);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        [HttpGet]
        public async Task<ActionResult> Edit(Guid id)
        {
            var technology = await _technologyService.GetById(id);

            if (technology != null)
            {
                var model = new TechnologyViewModel()
                {
                    Name = technology.Name
                };

                return View(model);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                await _technologyService.Delete(id);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }
    }
}