using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CrossAppsPhotoPlugin;
using CrossAppsPhotoPlugin.iOS.Renderer;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(PhotoTakerView), typeof(NativeCameraRenderer))]
namespace CrossAppsPhotoPlugin.iOS.Renderer
{
    public class NativeCameraRenderer : UIViewController, IUIImagePickerControllerDelegate, IUINavigationControllerDelegate
    {
        public static void Init()
        {

        }


        [Export("imagePickerController:didFinishPickingMediaWithInfo:")]
        void FinishedPickingMedia(UIImagePickerController picker, NSDictionary dic)
        {
            UIImage img = dic.ObjectForKey(new NSString("UIImagePickerControllerOriginalImage")) as UIImage;

            picker.DismissViewController(true, () =>
            {
                //ImageView.Image = img;

                //img.SaveToPhotosAlbum((uiImage, nsError) =>
                //{
                //    if (nsError != null)
                //    {
                //        // do something about the error..
                //    }

                //    else
                //    {
                //        // image should be saved
                //    }

                //});

            });

        }

        [Export("imagePickerControllerDidCancel:")]
        void Canceled(UIImagePickerController picker)
        {
            picker.DismissViewController(true, null);
        }


        // call this method as you want
        void TakePhoto()
        {

            if (UIImagePickerController.IsSourceTypeAvailable(UIImagePickerControllerSourceType.Camera))
            {
                UIImagePickerController picker = new UIImagePickerController();

                picker.SourceType = UIImagePickerControllerSourceType.Camera;

                picker.CameraCaptureMode = UIImagePickerControllerCameraCaptureMode.Photo;

                picker.VideoQuality = UIImagePickerControllerQualityType.High;

                picker.WeakDelegate = this;

                PresentViewController(picker, true, null);

            }
            else
            {
                Console.WriteLine("couldn't open the camera");
            }

        }
    }
}