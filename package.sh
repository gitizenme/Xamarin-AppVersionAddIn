#!/bin/sh
#find . -name "obj" | xargs rm -Rf
#find . -name "bin" | xargs rm -Rf
#find . -name ".droidres" | xargs rm -Rf

BUILD_DATE=$(date +"%y-%m-%d-%H-%M")

mkdir ./builds
mkdir ./builds/mpack
mkdir ./builds/mpack/$BUILD_DATE

# Build our Addin
#xbuild ./AppVersionAddIn/AppVersionAddIn.csproj /t:Build /p:Configuration=Release 

# Package our addin using MD tool
/Applications/Xamarin\ Studio.app/Contents/MacOS/mdtool setup pack ./AppVersionAddIn/bin/Release/AppVersionAddIn.dll -d:./builds/mpack/$BUILD_DATE

# OPTIONAL: Build an addin repository description.
/Applications/Xamarin\ Studio.app/Contents/MacOS/mdtool setup rep-build ./builds/mpack/$BUILD_DATE

# View output
open ./builds/mpack/$BUILD_DATE
