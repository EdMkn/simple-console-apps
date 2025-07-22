using Gtk;
using ImageViewerMVC.Models;
using ImageViewerMVC.Views;
using ImageViewerMVC.Controllers;

class Program
{
    public static void Main()
    {
        Application.Init();

        var model = new ImageModel();
        var view = new ImageView();
        var controller = new ImageController(model, view);

        Application.Run();
    }
}
