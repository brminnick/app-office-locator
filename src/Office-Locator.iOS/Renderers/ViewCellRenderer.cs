﻿using OfficeLocator.iOS;

using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ViewCell), typeof(StandardViewCellRenderer))]
namespace OfficeLocator.iOS
{
	public class StandardViewCellRenderer : ViewCellRenderer
	{
		public override UIKit.UITableViewCell GetCell (Cell item, UIKit.UITableViewCell reusableCell, UIKit.UITableView tv)
		{
			var cell = base.GetCell (item, reusableCell, tv);
			cell.Accessory = UIKit.UITableViewCellAccessory.DisclosureIndicator;

			return cell;
		}
	}
}