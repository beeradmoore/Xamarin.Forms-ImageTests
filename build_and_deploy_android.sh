#!/bin/sh

set -euo pipefail

pushd ImageTests/ImageTests.Android.Stock
    msbuild /p:Configuration=Release /p:AndroidBuildApplicationPackage=True /t:Restore,Clean,Build,SignAndroidPackage
    adb install bin/Release/com.beeradmoore.imagetests.stock-Signed.apk
popd

pushd ImageTests/ImageTests.Android.Glide
    msbuild /p:Configuration=Release /p:AndroidBuildApplicationPackage=True /t:Restore,Clean,Build,SignAndroidPackage
    adb install bin/Release/com.beeradmoore.imagetests.glide-Signed.apk
popd

pushd ImageTests/ImageTests.Android.FFImageLoading
    msbuild /p:Configuration=Release /p:AndroidBuildApplicationPackage=True /t:Restore,Clean,Build,SignAndroidPackage
    adb install bin/Release/com.beeradmoore.imagetests.ffimageloading-Signed.apk
popd