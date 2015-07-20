﻿//      *********    DO NOT MODIFY THIS FILE     *********
//      This file is regenerated by a design tool. Making
//      changes to this file can cause errors.

using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace Expression.Blend.SampleData.SampleDataSource
{
    // To significantly reduce the sample data footprint in your production application, you can set
    // the DISABLE_SAMPLE_DATA conditional compilation constant and disable sample data at runtime.
#if DISABLE_SAMPLE_DATA
	internal class SampleDataSource { }
#else

    public class SampleDataSource : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public SampleDataSource()
        {
            try
            {
                Uri resourceUri = new Uri("/Bookie;component/SampleData/SampleDataSource/SampleDataSource.xaml", UriKind.RelativeOrAbsolute);
                Application.LoadComponent(this, resourceUri);
            }
            catch
            {
            }
        }

        private readonly ItemCollection _Collection = new ItemCollection();

        public ItemCollection Collection
        {
            get
            {
                return _Collection;
            }
        }
    }

    public class Item : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private string _Property1 = string.Empty;

        public string Property1
        {
            get
            {
                return _Property1;
            }

            set
            {
                if (_Property1 != value)
                {
                    _Property1 = value;
                    OnPropertyChanged("Property1");
                }
            }
        }

        private ItemCollection _Collection = new ItemCollection();

        public ItemCollection Collection
        {
            get
            {
                return _Collection;
            }
        }
    }

    public class ItemCollection : ObservableCollection<Item>
    {
    }

#endif
}