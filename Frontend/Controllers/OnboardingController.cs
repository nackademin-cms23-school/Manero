using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers;

public class OnboardingController : Controller
{
    [Route("/")]
    public IActionResult Onboarding()
    {
        return View();
    }
}
