using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Argus.Pad
{
    public class MyWrapPanel : Panel
    {
        protected override Size ArrangeOverride(Size finalSize)
        {
            double x = 0;
            double y = 0;
            double maxHeight = 0;


            foreach (FrameworkElement child in Children)
            {
                if (maxHeight < child.DesiredSize.Height)
                {
                    maxHeight = child.DesiredSize.Height;
                }

                if ((x + child.DesiredSize.Width) > finalSize.Width)
                {
                    x = 0;
                    y += maxHeight;
                    maxHeight = 0;
                }

                child.Arrange(new Rect(new Point(x, y), child.DesiredSize));
                x += child.DesiredSize.Width;
            }

            return finalSize;
        }
        protected override Size MeasureOverride(Size availableSize)
        {
            foreach (FrameworkElement child in Children)
            {
                child.Measure(availableSize);
            }

            return availableSize;

        }
    }
}
