using Laboratorium1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Laboratorium1.Controllers
{
    public enum Operator
    {
        Add, Sub, Mul, Div, Unknown
    }
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult About()
        {

            return View();
        }

        public IActionResult Calculator(string op, double? a, double? b)
        {
            ViewBag.Op = op;
            ViewBag.A = a;
            ViewBag.B = b;
            ViewBag.Result = CalculateResult(op, a, b);
            return View();
        }

        private string CalculateResult(string op, double? a, double? b)
        {
            if (a == null || b == null) return "Błąd: brakujące parametry";

            try
            {
                switch (op)
                {
                    case "add": return (a + b).ToString();
                    case "sub": return (a - b).ToString();
                    case "mul": return (a * b).ToString();
                    case "div": return b != 0 ? (a / b).ToString() : "Błąd: dzielenie przez zero";
                    default: return "Nieznany operator";
                }
            }
            catch (Exception ex)
            {
                return $"Błąd: {ex.Message}";
            }
        }

    }
}