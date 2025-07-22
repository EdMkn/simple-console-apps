namespace ImageViewerMVC.Models
{
    using System;
    using System.IO;
    using System.Linq;

    public class ImageModel
    {
        private string[] images = Array.Empty<string>();
        private int currentIndex = -1;

        public bool HasImages => images.Length > 0;

        public string CurrentImage => (currentIndex >= 0 && currentIndex < images.Length) ? images[currentIndex] : null;

        public void LoadImagesFromFolder(string folderPath)
        {
            images = Directory.GetFiles(folderPath)
                .Where(f => f.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                            f.EndsWith(".png", StringComparison.OrdinalIgnoreCase) ||
                            f.EndsWith(".bmp", StringComparison.OrdinalIgnoreCase))
                .ToArray();

            currentIndex = images.Length > 0 ? 0 : -1;
        }

        public void Next()
        {
            if (!HasImages) return;
            currentIndex = (currentIndex + 1) % images.Length;
        }

        public void Previous()
        {
            if (!HasImages) return;
            currentIndex = (currentIndex - 1 + images.Length) % images.Length;
        }
    }
}