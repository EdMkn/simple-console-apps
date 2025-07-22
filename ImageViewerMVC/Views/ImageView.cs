namespace ImageViewerMVC.Views
{
    using System;
    using Gtk;
    using ActionDelegate = System.Action;  // Alias pour System.Action

    public class ImageView : Window
    {
        public event ActionDelegate OpenFolderClicked;
        public event ActionDelegate NextClicked;
        public event ActionDelegate PreviousClicked;

        private Button btnOpen, btnNext, btnPrev;
        private Image imageWidget;

        public ImageView() : base("Visionneuse d'images GTK# - MVC")
        {
            SetDefaultSize(800, 600);
            SetPosition(WindowPosition.Center);

            VBox vbox = new VBox(false, 5);
            Add(vbox);

            HBox buttonBox = new HBox(false, 5);
            btnOpen = new Button("Ouvrir dossier");
            btnPrev = new Button("Précédent");
            btnNext = new Button("Suivant");

            btnPrev.Sensitive = false;
            btnNext.Sensitive = false;

            buttonBox.PackStart(btnOpen, false, false, 0);
            buttonBox.PackStart(btnPrev, false, false, 0);
            buttonBox.PackStart(btnNext, false, false, 0);
            vbox.PackStart(buttonBox, false, false, 0);

            imageWidget = new Image();
            ScrolledWindow scroll = new ScrolledWindow();
            scroll.AddWithViewport(imageWidget);
            vbox.PackStart(scroll, true, true, 0);

            btnOpen.Clicked += (s, e) => OpenFolderClicked?.Invoke();
            btnPrev.Clicked += (s, e) => PreviousClicked?.Invoke();
            btnNext.Clicked += (s, e) => NextClicked?.Invoke();

            DeleteEvent += (o, args) => Application.Quit();

            ShowAll();
        }

        public void SetImage(string imagePath)
        {
            if (string.IsNullOrEmpty(imagePath))
            {
                imageWidget.Pixbuf = null;
                Title = "Visionneuse d'images GTK# - MVC";
                return;
            }

            try
            {
                var pixbuf = new Gdk.Pixbuf(imagePath);
                imageWidget.Pixbuf = pixbuf.ScaleSimple(
                    Math.Min(pixbuf.Width, 700),
                    Math.Min(pixbuf.Height, 500),
                    Gdk.InterpType.Bilinear);

                Title = $"Visionneuse d'images GTK# - MVC - {System.IO.Path.GetFileName(imagePath)}";
            }
            catch
            {
                imageWidget.Pixbuf = null;
            }
        }

        public void EnableNavigation(bool enabled)
        {
            btnPrev.Sensitive = enabled;
            btnNext.Sensitive = enabled;
        }
    }
}
