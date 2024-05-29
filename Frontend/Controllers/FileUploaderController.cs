using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers;

public class FileUploaderController : Controller
{
    [Route("/fileuploader")]
    public IActionResult FileUploader()
    {
        return View();
    }
}
