using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Lab2.Pages
{
    public class ChooseUserModel : PageModel
    {
        [BindProperty]
        public String Username { get; set; }

        [BindProperty]
        public String Password { get; set; }

        [BindProperty]
        public String Email { get; set; }

        [BindProperty]
        public String Phone { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (Lab2.Pages.DB.DBClass.SecureLogin(Username, Password) > 0)
            {
                HttpContext.Session.SetString("username", Username);
                ViewData["LoginMessage"] = "Login Successful!";

            }
            else
            {
                ViewData["LoginMessage"] = "Username and/or Password Incorrect";

            }

            Lab2.Pages.DB.DBClass.Lab2DBConnection.Close();

            return Page();
        }

        // Handler for clearing text fields
        public IActionResult OnPostClearHandler()
        {
            return Page();
        }

        // Handler for populating text fields
        public IActionResult OnPostPopulateHandler()
        {
            ModelState.Clear(); // used to ignore validation
            Username = "";
            Password = "";
            Email = "";
            Phone = "";
            return Page();
        }
    }
}
