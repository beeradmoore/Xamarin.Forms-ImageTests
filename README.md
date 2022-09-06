# Xamarin.Forms ImageTests
App used to test various image loading libraries for iOS and Android in a Xamarin.Forms application.

Image loading libraries tested on iOS:
- [Xamarin.Forms](https://github.com/xamarin/Xamarin.Forms) (stock)
- [FFImageLoading](https://github.com/luberda-molinet/FFImageLoading)
- [Xamarin.Nuke](https://github.com/roubachof/NukeProxy) (via [Xamarin.Forms.Nuke](https://github.com/roubachof/Xamarin.Forms.Nuke))
- [Xamarin.SDWebImage](https://www.nuget.org/packages/Xamarin.SDWebImage/)

Image loading libraries tested on Android:
- [Xamarin.Forms](https://github.com/xamarin/Xamarin.Forms) (stock)
- [FFImageLoading](https://github.com/luberda-molinet/FFImageLoading)
- [Xamarin.Android.Glide](https://www.nuget.org/packages/Xamarin.Android.Glide/) (via [glidex.forms](https://github.com/jonathanpeppers/glidex))

### Building and deploying
This was only built and tested on macOS with Visual Studio 2022 installed. You will also require adb in your path to deploy for Android.

To build and deploy to iOS run
> ./build_and_deploy_ios.sh

To build and deploy to Android run
> ./build_and_deploy_android.sh

In both instances it is recommended to have a single iOS or single Android device connected to your computer. Running multiple devices or emulators/simulators on the computer may interfere with deployment and you will have to modify these scripts to target your specific devices.
