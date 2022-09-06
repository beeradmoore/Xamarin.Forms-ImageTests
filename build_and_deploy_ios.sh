#!/bin/sh

set -euo pipefail

pushd ImageTests/ImageTests.iOS.Stock
    msbuild /p:BuildIpa=True /p:Platform=iPhone /p:Configuration=Release /t:Restore,Build
    /Library/Frameworks/Xamarin.iOS.framework/Versions/Current/bin/mtouch -installdev=bin/iPhone/Release/ImageTests.iOS.Stock.app
popd

pushd ImageTests/ImageTests.iOS.Nuke
    msbuild /p:BuildIpa=True /p:Platform=iPhone /p:Configuration=Release /t:Restore,Build
    /Library/Frameworks/Xamarin.iOS.framework/Versions/Current/bin/mtouch -installdev=bin/iPhone/Release/ImageTests.iOS.Nuke.app
popd

pushd ImageTests/ImageTests.iOS.FFImageLoading
    msbuild /p:BuildIpa=True /p:Platform=iPhone /p:Configuration=Release /t:Restore,Build
    /Library/Frameworks/Xamarin.iOS.framework/Versions/Current/bin/mtouch -installdev=bin/iPhone/Release/ImageTests.iOS.FFImageLoading.app
popd