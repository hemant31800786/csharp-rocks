using SqlliteConnection;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoDictnorySuggetion.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

         //   GetSuggestionWords("cat");
            return View(ViewBag);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult GetSuggestionWords(string s)
        {
            
            string search = s.Substring(0, s.Length - 1);
            SQLiteConnection sqlite_conn;
            sqlite_conn = Program.CreateConnection();
            //    // CreateTable(sqlite_conn);
            //    //   InsertData(sqlite_conn);
            ViewBag.item = Program.ReadData(sqlite_conn, search);

            return View(ViewBag);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult Autocomplete(string term)
        {

            string[] words = term.Split(' ');
            string searchword = words[words.Length - 1];
         
            SQLiteConnection sqlite_conn;
            sqlite_conn = Program.CreateConnection();
            //    // CreateTable(sqlite_conn);
            //    //   InsertData(sqlite_conn);
            //    ViewBag.item = Program.ReadData(sqlite_conn, search);
            var result3 = Program.ReadData(sqlite_conn, searchword);
            return Json(result3, JsonRequestBehavior.AllowGet);
        }

           
    }
}


//,
//         select: function(event, ui)
//{
//             //fill selected customer details on form
//             $.ajax({
//    cache: false,
//                 async: false,
//                 type: "POST",
//                 url: "@(Url.Action("GetDetail", " Home"))",
//                data: { "id": ui.item.Id },

//                success: function(data) {
//                    $('#VisitorDetail').show();
//                    $("#Name").html(data.VisitorName)
//                    $("#PatientName").html(data.PatientName)
//                    //alert(data.ArrivingTime.Hours)
//                    $("#VisitorId").val(data.VisitorId)
//                    $("#Date").html(data.Date)
//                    $("#ArrivingTime").html(data.ArrivingTime)
//                    $("#OverTime").html(data.OverTime)

//                    action = data.Action;
//        },
//                error: function(xhr, ajaxOptions, thrownError) {
//            alert('Failed to retrieve states.');
//        }
//    });
//}
//     });