using CarRentalMVC.ViewModel.User;
using CarRentalMVC.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

namespace CarRentalMVC.Controllers
{
    public class AccountController : Controller
    {

        private UserManager<Customer> _userManager;
        private SignInManager<Customer> _signInManager;

        public AccountController(UserManager<Customer> userManager, SignInManager<Customer> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }



        public IActionResult Register() 
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(Login_RegisterVM vm)
        {
            if (vm.RegisterVM != null)
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                Customer existUser = await _userManager.FindByEmailAsync(vm.RegisterVM.email);

                if (existUser != null)
                {
                    ModelState.AddModelError("RegisterVM.email", "This mail is exsist");

                    return View();
                }
                Customer customer = new Customer()
                {
                    name = vm.RegisterVM.name,
                    surname = vm.RegisterVM.surname,
                    Email = vm.RegisterVM.email,
                    PhoneNumber = vm.RegisterVM.phone,


                    address = vm.RegisterVM.address,
                    drivingLicense = vm.RegisterVM.drivingLicense,
                    city = vm.RegisterVM.city




                };
                var result = await _userManager.CreateAsync(customer, vm.RegisterVM.password);
                if (!result.Succeeded)
                {
                
                        ModelState.AddModelError("", "Mail already exist");
                    

                    return View();
                }
                await _signInManager.SignInAsync(customer, true);

                var role = _userManager.AddToRoleAsync(customer, "Customer");
                return RedirectToAction();

            }
            else if(vm.LoginVM != null)
            {
                Customer existUser = await _userManager.FindByEmailAsync(vm.LoginVM.email);
                if (existUser == null)
                {
                    ModelState.AddModelError("LoginVM.email", "Mail or password incorrect");

                    return View();
                }

                var result = await _signInManager.PasswordSignInAsync(existUser, vm.LoginVM.password, true, true);
                if (!result.Succeeded)
                {
                   
                        ModelState.AddModelError("", "Mail or password incorrect");
                    

                    return View();
                }
           return  RedirectToAction("Index");

            }
            else
            { return View(); }  
           

             

        }
            
            


        }

    }


