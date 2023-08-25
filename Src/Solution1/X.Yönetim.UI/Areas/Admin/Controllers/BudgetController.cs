using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using X.Yönetim.UI.Models.Dtos.Accounts;
using X.Yönetim.UI.Models.Dtos.Budgets;
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
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IConfiguration _configuration;

        public BudgetController(IMapper mapper, IRestService restService, IHttpContextAccessor contextAccessor, IConfiguration configuration)
        {
            _mapper = mapper;
            _restService = restService;
            _contextAccessor = contextAccessor;
            _configuration = configuration;
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
            //if (!ModelState.IsValid)
            //{
            //    return View(createBudgetVM);
            //}

            //Model validasyonu başarılı. Kaydı gerçekleştir.
            var response = await _restService.PostAsync<CreateBudgetVM, Result<int>>(createBudgetVM, "budget/create");

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("", response.Data.Errors[0]);
                return View();
            }
            else // herşey yolunda
            {
                var sessionKey = _configuration["Application:SessionKey"];
                var userInfo = JsonConvert.DeserializeObject<TokenDto>(_contextAccessor.HttpContext.Session?.GetString(sessionKey));

                ViewBag.UserId = userInfo.Id;//kullanıcı ıd si gelecek
                TempData["success"] = $"{response.Data.Data} numaralı kayıt başarıyla eklendi.";
                return RedirectToAction("List", "Budget", new { Area = "Admin" });
            }
        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            ViewBag.Header = "Bütçe İşlemleri";
            ViewBag.Title = "Bütçe Düzenle";

            //Apiye istek at
            //bütçe/get
            var sessionKey = _configuration["Application:SessionKey"];
            var userInfo = JsonConvert.DeserializeObject<TokenDto>(_contextAccessor.HttpContext.Session?.GetString(sessionKey));
            var response = await _restService.GetAsync<Result<List<BudgetDto>>>($"budget/get/{userInfo.Id}");

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("", "İşlem esnasında sunucu taraflı bir hata oluştu. Lütfen sistem yöneticinize başvurunuz.");
                return View();
            }
            else
            {
                return View(response.Data);
            }
        }
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Header = "Bütçe İşlemleri";
            ViewBag.Title = "Bütçe Güncelle";

            //ilgili bütçeyi bul ve View'e git
            var response = await _restService.GetAsync<Result<BudgetDto>>($"budget/get/{id}");

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("", response.Data.Errors[0]);
                return View();
            }
            else // herşey yolunda
            {
                var model = _mapper.Map<UpdateBudgetVM>(response.Data.Data);
                return View(model);
            }

        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateBudgetVM updateBudgetModel)
        {
            var response = await _restService.PutAsync<UpdateBudgetVM, Result<int>>(updateBudgetModel, $"budget/update/{updateBudgetModel.Id}");

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("", response.Data.Errors[0]);
                return View();
            }
            else // herşey yolunda
            {
                TempData["success"] = $"{response.Data.Data} numaralı kayıt başarıyla güncellendi.";
                return RedirectToAction("List", "Budget", new { Area = "Admin" });
            }

        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            //api endpointi çağır
            //budget/delete/id

            var response = await _restService.DeleteAsync<Result<int>>($"budget/delete/{id}");

            return Json(response.Data);

        }



    }
}
