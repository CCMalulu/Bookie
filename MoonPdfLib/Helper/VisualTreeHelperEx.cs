/*! MoonPdfLib - Provides a WPF user control to display PDF files
Copyright (C) 2013  (see AUTHORS file)

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
!*/

namespace MoonPdfLib.Helper
{
    using System.Windows;
    using System.Windows.Media;

    internal static class VisualTreeHelperEx
    {
        public static T FindChild<T>(DependencyObject o) where T : DependencyObject
        {
            if (o is T)
                return (T) o;

            for (var i = 0; i < VisualTreeHelper.GetChildrenCount(o); i++)
            {
                var child = VisualTreeHelper.GetChild(o, i);
                var result = FindChild<T>(child);

                if (result != null)
                    return result;
            }

            return null;
        }
    }
}