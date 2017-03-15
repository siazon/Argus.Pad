using System;
using System.Diagnostics;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Argus.Pad.Converter
{
    /// <summary>
    /// 将秒显示为 分:秒 00:00 结构
    /// </summary>
    public class Second2TimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            //if (value == null || DependencyProperty.UnsetValue.Equals(value) || parameter == null)
            //{
            //    return value;
            //}

            try
            {
                var parValue = TimeSpan.FromSeconds((int)value).ToString(@"mm\:ss");

                return parValue;
            
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return value;

        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
