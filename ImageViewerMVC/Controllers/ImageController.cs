namespace ImageViewerMVC.Controllers
{
    using System;
    using Gtk;
    using ImageViewerMVC.Models;
    using ImageViewerMVC.Views;

    public class ImageController
    {
        private ImageModel model;
        private ImageView view;

        public ImageController(ImageModel model, ImageView view)
        {
            this.model = model;
            this.view = view;

            this.view.OpenFolderClicked += OnOpenFolderClicked;
            this.view.NextClicked += OnNextClicked;
            this.view.PreviousClicked += OnPreviousClicked;
        }

        private void OnOpenFolderClicked()
        {
            FileChooserDialog chooser = new FileChooserDialog(
                "Choisir un dossier",
                view,
                FileChooserAction.SelectFolder,
                "Annuler", ResponseType.Cancel,
                "Ouvrir", ResponseType.Accept);

            if (chooser.Run() == (int)ResponseType.Accept)
            {
                model.LoadImagesFromFolder(chooser.Filename);
                chooser.Destroy();

                if (model.HasImages)
                {
                    view.SetImage(model.CurrentImage);
                    view.EnableNavigation(true);
                }
                else
                {
                    view.SetImage(null);
                    view.EnableNavigation(false);

                    MessageDialog md = new MessageDialog(view,
                        DialogFlags.Modal, MessageType.Info,
                        ButtonsType.Ok,
                        "Aucune image trouvée dans ce dossier.");
                    md.Run();
                    md.Destroy();
                }
            }
            else
            {
                chooser.Destroy();
            }
        }

        private void OnNextClicked()
        {
            model.Next();
            view.SetImage(model.CurrentImage);
        }

        private void OnPreviousClicked()
        {
            model.Previous();
            view.SetImage(model.CurrentImage);
        }
    }
}
