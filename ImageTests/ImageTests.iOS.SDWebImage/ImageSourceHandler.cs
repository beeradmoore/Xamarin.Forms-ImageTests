
using System;
using System.Threading;
using System.Threading.Tasks;
using Foundation;
using SDWebImage;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

// Class via https://github.com/roubachof/Xamarin.Forms.ImageSourceHandlers
[assembly: ExportImageSourceHandler(typeof(UriImageSource), typeof(ImageTests.iOS.SDWebImage.ImageSourceHandler))]

namespace ImageTests.iOS.SDWebImage
{
    [Preserve(AllMembers = true)]
    public class ImageSourceHandler : IImageSourceHandler
    {
        public Task<UIImage> LoadImageAsync(ImageSource imageSource, CancellationToken cancellationToken = new CancellationToken(), float scale = 1)
        {
            return LoadViaSDWebImage(imageSource, cancellationToken);
        }

        private Task<UIImage> LoadImageAsync(string urlString)
        {
            var tcs = new TaskCompletionSource<UIImage>();

            SDWebImageManager.SharedManager.LoadImage(
                new NSUrl(urlString),
                SDWebImageOptions.ScaleDownLargeImages,
                null,
                (image, data, error, cacheType, finished, url) =>
                {
                    if (image == null)
                    {
                        System.Diagnostics.Debug.WriteLine($"Fail to load image: {url.AbsoluteUrl}");
                    }

                    tcs.SetResult(image);
                });

            return tcs.Task;
        }


        public async Task<UIImage> LoadViaSDWebImage(ImageSource source, CancellationToken token)
        {
            UIImage result = null;

            try
            {
                switch (source)
                {
                    case UriImageSource uriSource:
                        var urlString = uriSource.Uri.OriginalString;
                        System.Diagnostics.Debug.WriteLine($"Loading `{urlString}` as a web URL");
                        result = await LoadImageAsync(urlString);
                        break;
                }
            }
            catch (Exception exception)
            {
                // Since developers can't catch this themselves, I think we should log it and silently fail
                System.Diagnostics.Debug.WriteLine($"Unexpected exception in SDWebImage: {exception.Message}");
            }

            return result;
        }
    }
}

