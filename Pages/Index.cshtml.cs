using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDotnetCoreWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        // çoh önemli. aşağıda açıklandı
        [BindProperty]
        public String personName{get;set;}
        [BindProperty]
        public String personSurname { get; set; }
        [BindProperty]
        public DateTime personBirthdate { get; set; } = new DateTime(2000,02,01); // default değer getirdik
        // sadece sayfada olacak posttan gelmeyecekse bindproperty yapmaya gerek yok.
        public String message { get; set; }
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
        public void OnPost()
        {
            //var name = Request.Form["personName"]; requestten alma şekli
            //var name = personName; // bu da personName tanıtarak parametre ve asp-for ile alma şekli
            // şimdi de [BindProperty] ekledik ve böylece onPost'un aldığı parametreyi sildik. artık kullanmamıza gerek kalmadı.
            // yani otomatik bind ettik.
            var age = DateTime.Today.Year - personBirthdate.Year;
            message = String.Format("Welcome {0} {1}, your age is {2}",personName,personSurname,age);


        }
    }
}
