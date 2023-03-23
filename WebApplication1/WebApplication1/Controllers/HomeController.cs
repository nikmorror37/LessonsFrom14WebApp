using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using WebApplication1.Dto;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    //public class имяController : Controller
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //Ключевым элементом контроллера являются его методами ещё они называются action(действния).
        //Действия контроллера - это публичные методы, которые могут сопоставляться с запросами.
        //public IActionResunt имя { код }
        public IActionResult Index()
        {
            return View();
        }

        //Для получения информации о запросе нас прежде всего будет интересовать свойство HttpContext,
        //которое представляет объект Microsoft.AspNetCore.Http.HttpContext.
        //HttpContext: содержит информацию о контексте запроса
        //ActionDescriptor: возвращает дескриптор действия - объект ActionDescriptor, который описывает вызываемое действие контроллера
        //ModelState: возвращает словарь ModelStateDictionary, который используется для валидации данных, отправленных пользователем
        //RouteData: возвращает данные маршрута


        // Объект HttpContext инкапсулирует всю информацию о запросе.В частности, он определяет следующие свойства:
        //Request: содержит собственно информацию о текущем запросе.
        //Response: управляет ответом
        //User: представляет текущего пользователя, который обращается к приложению
        //Session: объект для работы с сессиями

        //Свойство HttpContext.Response представляет объект HttpResponse и позволяет управлять ответом на запрос,
        //в частности, устанавливать заголовки ответа, куки, отправлять в выходной поток некоторый ответ.
        //Среди свойств объекта Response можно выделить следующие:
        //Body: объект Stream, который применяется для отправки данных в ответ пользователю
        //Cookies: куки, отправляемые в ответе
        //Headers: коллекция заголовков ответа  
        //StatusCode: статусный код ответа

        //Свойство HttpContext.Request представляет объект HttpRequest и предоставляет разнообразную информацию о запросе.
        // Среди свойств объекта Request можно выделить следующие:
        //Body: объект Stream, который используетя для чтения данных запроса
        //Cookies: куки, полученные в запросе
        //Form: коллекция значений отправленных форм
        //Headers: коллекция заголовков запроса
        //Path: возвращает запрошенный путь - строка запроса без домена и порта
        //Query: возвращает коллекцию переданных через строку запроса параметров
        //QueryString: возвращает ту часть запроса, которая содержит параметры.Например, в запросе http://localhost:52682/Home/Index?sessionid=4 это будет ?sessionid=4
        public IActionResult Privacy()
        {
            ViewData["UFO"] = true;
            ViewData["Ignat"] = "24 year's old student";
            ViewData["Numbers"] = 2020;

            ViewBag.BasketballSquad = new string[] { "Curry", "Lebron", "Jordan", "O'Neil", "Durant" };

            var clubs = new string[] {
            "https://i.pinimg.com/170x/38/39/42/383942cd41db58ef4174251df919d09b.jpg",
            "https://imgpng.ru/d/fcb_logo_PNG19.png",
            "https://static.tildacdn.com/tild3531-3761-4130-b466-633563663362/DcNtqBaWAAEF869_1_1.png"};

            var httpContext = ControllerContext.HttpContext;
            var _httpContextOne = HttpContext.Request;
            return View(clubs);

            //ContentResult отправляет клиенту ответ в виде строки.
            //return Content("Hello");
            
            //JSON не зависит от языка программирования, он более удобен и легче обрабатывается.
            //var artem = new Person("Artem", 1200);
            //return Json(artem);

            //В ASP.NET Core MVC для выполнения переадресация используется
            //return Redirect("~/Home/About");
            //return RedirectToAction("Privacy", "Profile");
            //return StatusCode(401);
            //return NotFound("Resource not found");
            //уведомляет пользователя, что он не автризован для доступа к ресурсу
            //return Unauthorized();
            //BadResult посылают код 400, что говорит о том, что запрос некорректный
            //return BadRequest("Bad");
            //Ok посылают код 200, уведомляя об успешном выполнении запроса
            //return Ok("Don't worry. Be happy");
            //var artem = new Person("Artem", 1200);
            //return Json(artem);
            //return Ok(artem);
        }
        [HttpGet]
        public IActionResult Form() => View();

        //[HttpPost]
        //public string Form(string username, string password, int age, string info)
        //{
        //    return $"User name is {username},  Password: {password},  Age:  {age},  Info:  {info}";  
        //}

		[HttpGet]
		public IActionResult Registration()
        {
            return View();
        }

		[HttpPost]
        public string Registration(UserViewModel userOne)
        {
            if (userOne.Password != userOne.ConfirmPassword)
			{
                return "Пароли не совпадают!";
			}
            else if(ModelState.IsValid)
            {
                return $"User name is {userOne.UserName},  Password: {userOne.Password},  Adress: {userOne.Adress}";
			}
            else
            {
                return "Данные не смогли пройти валидацию";
            }
        }













		public IActionResult Road()
        {
            var artem = new Person("Artem", 1200);
            return Json(artem);
        }

        public IActionResult TableItem()
        {
            var newItem = new ItemViewModel[]
            {
                new ItemViewModel(1, "iPhone", 3, "USA", Category.Electronics),
                new ItemViewModel(2, "Old Spice", 26, "UK", Category.Beauty),
                new ItemViewModel(3, "Lindt", 450, "Germany", Category.Food),
                new ItemViewModel(4, "Chair from IKEA", 12, "Sweden", Category.Home),
                new ItemViewModel(5, "FC Bayern T-Shirt", 4, "China", Category.Sport)
            };
            return View(newItem);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    //При использовании контроллеров существуют некоторые условности.
    //Прежде всего обычно в проекте контроллеры помещаются в каталог Controllers.
    //В ASP.NET Core MVC контроллер представляет обычный класс на языке C#, который обычно наследуется от абстрактного базового класса Microsoft.AspNetCore.Mvc.Controller и который
    //, как и любой класс на языке C#, может иметь поля, свойства, методы
    //. Согласно соглашениям об именовании названия контроллеров обычно оканчиваются на суффикс "Controller",
    //остальная же часть до этого суффикса считается именем контроллера, например, HomeController.
    //Но есть также и обязательные условности, которые предъявляются к контроллерам. Класс контроллера должен удовлетворять как минимум одному из следующих условий:
    //Класс контроллера имеет суффикс "Controller"
    //Класс контроллера наследуется от класса, который имеет суффикс "Controller"

}