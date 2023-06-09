using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace PrismWPF.ConvertValue
{
    public class PasswordBoxHelper
    {


        public static string GetPassWord(DependencyObject obj)
        {
            return (string)obj.GetValue(PasswordProperty);
        }

        public static void SetPassWord(DependencyObject obj, string value)
        {
            obj.SetValue(PasswordProperty, value);
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.RegisterAttached("PassWord", typeof(string), typeof(PasswordBoxHelper), new PropertyMetadata("", PropertyCallBack));

        private static void PropertyCallBack(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            PasswordBox box = sender as PasswordBox;
            if (box != null && box.Password != (string)e.NewValue)
            {
                box.Password = (string)e.NewValue;
            }
        }
    }
}
