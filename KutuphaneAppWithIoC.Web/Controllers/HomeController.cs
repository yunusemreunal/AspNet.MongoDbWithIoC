using System.Web.Mvc;
using KutuphaneAppWithIoC.Core.Services;
using KutuphaneAppWithIoC.Core.Services.Dto;

namespace KutuphaneAppWithIoC.Web.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult GetAllBooks()
        {
            var model = Services.KutuphaneService.GetAllBooks();
            return PartialView("_AllBooksPartial", model);
        }

        public PartialViewResult GetAllLogs()
        {
            var model = Services.KutuphaneService.GetAllLogs();
            return PartialView("_AllLogsPartial", model);
        }

        [HttpPost]
        public JsonResult InsertNewBook(InsertBookDto dto)
        {
            if (ModelState.IsValid)
            {
                Services.KutuphaneService.InsertNewBook(dto);
                return Json(Services.KutuphaneService.Result);
            }
            return Json(false);
        }

        public PartialViewResult GetUpdateBookPartial(int isbn)
        {
            var model = Services.KutuphaneService.GetBookDetail(isbn);

            return PartialView("_UpdateBookPartial", model);
        }

        [HttpPost]
        public JsonResult UpdateBook(InsertBookDto dto)
        {
            Services.KutuphaneService.UpdateBook(dto);

            return Json(Services.KutuphaneService.Result);
        }

        [HttpPost]
        public JsonResult DeleteBook(int isbn)
        {
            Services.KutuphaneService.DeleteBook(isbn);

            return Json(Services.KutuphaneService.Result);
        }

        public PartialViewResult GetBorrowBookPartial(int isbn)
        {
            return PartialView("_BorrowBookPartial", isbn);
        }

        [HttpPost]
        public JsonResult BorrowBook(BorrowBookDto dto)
        {
            Services.KutuphaneService.BorrowBook(dto);

            return Json(Services.KutuphaneService.Result);
        }
    }
}
