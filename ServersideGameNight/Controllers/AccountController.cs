using Avans.GameNight.Core.DomainServices.Interfaces;
using Avans.GameNight.Core.Domain.Models;
using Microsoft.AspNetCore.Identity;


using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Avans.GameNight.Infrastructure.EntityFramework.Interfaces;
using Avans.GameNight.App.Models;

namespace Avans.GameNight.App.Controllers
{


    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IPlayerRepository _playerRepo;


        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IPlayerRepository playerRepo)
        {
            _playerRepo =   playerRepo;
             _userManager = userManager;
            _signInManager = signInManager;
        }
            public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            //TODO: login errors tonen???
            //login functionality
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(loginModel.Email);

                if (user != null)
                {
                    //sign in
                    var signInResult = await _signInManager.PasswordSignInAsync(user, loginModel.Password, false, false);

                    if (signInResult.Succeeded)
                    {
                        TempData["SuccessMessage"] = "Success Login welcome: " + user.Email;
                        return RedirectToAction("LoginIndex", "Home");
                    }
                }
            }
                ModelState.AddModelError("LoginError", "Email/wachtwoord is onjuist");
            TempData["ErrorMessage"] = "Error wrong password or email";
            return View(loginModel);
            }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            TempData["SuccessMessage"] = "Success Logout";
            return RedirectToAction("Login");
        }

        public IActionResult Register()
            {
                return View();
            }
       
        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel registerModel)
        {
            if (registerModel.BirthDate > DateTime.Today)
            {
                ModelState.AddModelError(string.Empty, "Birthday cannot be in the future!");
                return View();
            };

            if (DateTime.Today.Year - registerModel.BirthDate.Year < 16)
            {
                ModelState.AddModelError(string.Empty, "You have to be 16+!");
                return View();
            };
         

            if (!registerModel.Password.Equals(registerModel.ConfirmPassword))
            {
                ModelState.AddModelError(string.Empty, "Password don't match");
                return View();
            };

           
            var user = new IdentityUser
            {
                UserName = registerModel.UserName,
                Email = registerModel.Email,
                
                 
            };
           var player = new Player
            {
                Name = registerModel.UserName,
                MailAddress = registerModel.Email,
                BirthDate = registerModel.BirthDate,
            
                alert = Alert.None,
               Adress = " ",
               FoodPreference = " ",
               DrinkPreference = " ",
               City = " ",


           };
            

            //if (ModelState.IsValid)
            //{

            try {
                await _playerRepo.AddPlayer(player); 
            }catch(Exception ex)
            {
                ModelState.AddModelError("InvalidStateModel", ex.Message);
            }
            //}





            var userCreationResult = await _userManager.CreateAsync(user, registerModel.Password);
            if (!userCreationResult.Succeeded)
            {
               



                foreach (var error in userCreationResult.Errors)
                    ModelState.AddModelError(string.Empty, error.Description);
                return View();
            }


            TempData["SuccessMessage"] = "Success Register";
            return RedirectToAction("Login");
        }

      
        } 
}

