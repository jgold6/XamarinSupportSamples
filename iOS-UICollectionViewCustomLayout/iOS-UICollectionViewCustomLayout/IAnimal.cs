using System;
using MonoTouch.UIKit;

namespace iOSUICollectionViewCustomLayout
{
	public interface IAnimal
	{
		string Name { get; }

		UIImage Image { get; }
	}
}