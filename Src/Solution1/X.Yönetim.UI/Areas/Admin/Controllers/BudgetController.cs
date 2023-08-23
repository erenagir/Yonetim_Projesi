using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using X.Yönetim.UI.Models.RequestModels.Budgets;
using X.Yönetim.UI.Services.Abstraction;
using X.Yönetim.UI.Wrapper;

namespace X.Yönetim.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Policy = "Admin")]
    public class BudgetController : Controller
    {
        private IRestService _restService;
        private readonly IMapper _mapper;

        public BudgetController(IMapper mapper, IRestService restService)
        {
            _mapper = mapper;
            _restService = restService;
        }


        public IActionResult Create()
        {
            ViewBag.Header = "Bütçe İşlemleri";
            ViewBag.Title = "Yeni bütçe Oluştur";

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateBudgetVM createBudgetVM)
        {
            //Fluent validation içerisinde tanımlanan kurallardan bir veya birkaçı ihlal edildiyse
            if (!ModelState.IsValid)
            {
                return View(createBudgetVM);
            }

            //Model validasyonu başarılı. Kaydı gerçekleştir.
            var response = await _restService.PostAsync<CreateBudgetVM, Result<int>>(createBudgetVM, "budget/create");

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("", response.Data.Errors[0]);
                return View();
            }
            else // herşey yolunda
            {
                TempData["success"] = $"{response.Data.Data} numaralı kayıt başarıyla eklendi.";
                return RedirectToAction("List", "Budget", new { Area = "Admin" });
            }
        }
        



    }
}
