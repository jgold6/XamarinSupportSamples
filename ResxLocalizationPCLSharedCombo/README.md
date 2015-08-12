Forms Shared Resx Localization
==============================

Simple demo of using Resx localization with Xamarin Forms solution when your core Xamarin Forms code is in a Shared Project type. The Resx does have to be in a PCL. You have to make sure to change the Custom Tool in the properties for the Resx localization files to PublicResXFileCodegenerator. The default is ResXFileCodegenerator which creates the resource class as "internal." Using PublicResXFileCodegenerator creates the resource class as "public."