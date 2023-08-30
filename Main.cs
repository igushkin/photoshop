using MyPhotoshop.Filters;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MyPhotoshop
{
	class MainClass
	{
        [STAThread]
		public static void Main (string[] args)
		{
			var window=new MainWindow();
			window.AddFilter(new PixelFilter<LighteningParameters>(
                "Brightness",
				(original, parameters) => original * parameters.Coefficient
			));
			window.AddFilter(new PixelFilter<EmptyParameters>(
                "Grayscale",
				(original, parameters) => {
					var lightness = 0.2126 * original.R + 0.7152 * original.G + 0.0722 * original.B;
					return new Pixel(lightness, lightness, lightness);
				}
			));
            window.AddFilter(new TransformFilter<EmptyParameters>(
                "Rotate 90",
				new FreeTransformer(
					size => new Size(size.Height, size.Width),
					(point, size) => new Point(size.Width - point.Y - 1, point.X)
				)
                
            ));
            window.AddFilter(new TransformFilter<EmptyParameters>(
                "Invert",
				new FreeTransformer(
					size => size,
					(point, size) => new Point(size.Width - point.X - 1, point.Y)
				)
            ));


            window.AddFilter(new TransformFilter<RotationParameters>(
				"Rotate",
				new RotateTransformer()
			));

			Application.Run (window);
		}
	}
}
