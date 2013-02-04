﻿//      *********    DO NOT MODIFY THIS FILE     *********
//      This file is regenerated by a design tool. Making
//      changes to this file can cause errors.
namespace Expression.Blend.SampleData.Locations
{
	using System; 

// To significantly reduce the sample data footprint in your production application, you can set
// the DISABLE_SAMPLE_DATA conditional compilation constant and disable sample data at runtime.
#if DISABLE_SAMPLE_DATA
	internal class Locations { }
#else

	public class Locations : System.ComponentModel.INotifyPropertyChanged
	{
		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string propertyName)
		{
			if (this.PropertyChanged != null)
			{
				this.PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
			}
		}

		public Locations()
		{
			try
			{
				System.Uri resourceUri = new System.Uri("/modelOne;component/SampleData/Locations/Locations.xaml", System.UriKind.Relative);
				if (System.Windows.Application.GetResourceStream(resourceUri) != null)
				{
					System.Windows.Application.LoadComponent(this, resourceUri);
				}
			}
			catch (System.Exception)
			{
			}
		}

		private ItemCollection _Collection = new ItemCollection();

		public ItemCollection Collection
		{
			get
			{
				return this._Collection;
			}
		}
	}

	public class Item : System.ComponentModel.INotifyPropertyChanged
	{
		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string propertyName)
		{
			if (this.PropertyChanged != null)
			{
				this.PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
			}
		}

		private string _LocationName = string.Empty;

		public string LocationName
		{
			get
			{
				return this._LocationName;
			}

			set
			{
				if (this._LocationName != value)
				{
					this._LocationName = value;
					this.OnPropertyChanged("LocationName");
				}
			}
		}

		private string _LocationDistance = string.Empty;

		public string LocationDistance
		{
			get
			{
				return this._LocationDistance;
			}

			set
			{
				if (this._LocationDistance != value)
				{
					this._LocationDistance = value;
					this.OnPropertyChanged("LocationDistance");
				}
			}
		}

		private System.Windows.Media.ImageSource _LocationImage = null;

		public System.Windows.Media.ImageSource LocationImage
		{
			get
			{
				return this._LocationImage;
			}

			set
			{
				if (this._LocationImage != value)
				{
					this._LocationImage = value;
					this.OnPropertyChanged("LocationImage");
				}
			}
		}
	}

	public class ItemCollection : System.Collections.ObjectModel.ObservableCollection<Item>
	{ 
	}
#endif
}
