XBUILD=/Applications/Xcode.app/Contents/Developer/usr/bin/xcodebuild
PROJECT_ROOT=.
PROJECT=$(PROJECT_ROOT)/AMScrollingNavbar.xcodeproj
TARGET=AMScrollingNavbar

all: libAMScrollingNavbarSDK.a

libAMScrollingNavbar-i386.a:
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphonesimulator -configuration Release clean build
	-mv $(PROJECT_ROOT)/build/Release-iphonesimulator/lib$(TARGET).a $@

libAMScrollingNavbar-armv7.a:
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphoneos -arch armv7 -configuration Release clean build
	-mv $(PROJECT_ROOT)/build/Release-iphoneos/lib$(TARGET).a $@

libAMScrollingNavbarSDK.a: libAMScrollingNavbar-i386.a libAMScrollingNavbar-armv7.a
	lipo -create -output $@ $^

clean:
	-rm -f *.a *.dll