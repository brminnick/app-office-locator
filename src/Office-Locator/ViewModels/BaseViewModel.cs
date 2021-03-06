﻿using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace OfficeLocator
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        string title = string.Empty;
        string subTitle = string.Empty;
        bool isBusy;
		bool canLoadMore = true;
        string icon;

        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<string> ErrorOcurred;

        /// <summary>
        /// Gets or sets the reverse of  isbusy. Handy for hiding views during busy times.
        /// </summary>
        public bool IsBusyRev
        {
            get { return !isBusy; }
        }

        /// <summary>
        /// Gets or sets the "Title" property
        /// </summary>
        /// <value>The title.</value>
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        /// <summary>
        /// Gets or sets the "Subtitle" property
        /// </summary>
        public string Subtitle
        {
            get { return subTitle; }
            set { SetProperty(ref subTitle, value); }
        }

        /// <summary>
        /// Gets or sets the "Icon" of the viewmodel
        /// </summary>
        public string Icon
        {
            get { return icon; }
            set { SetProperty(ref icon, value); }
        }

        /// <summary>
        /// Gets or sets if the view is busy.
        /// </summary>
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value, onChanged: () => OnPropertyChanged(nameof(IsBusyRev))); }
        }

        /// <summary>
        /// Gets or sets if we can load more.
        /// </summary>
        public bool CanLoadMore
        {
            get { return canLoadMore; }
            set { SetProperty(ref canLoadMore, value); }
        }

        protected void SetProperty<T>(ref T backingStore, T value, [CallerMemberName]string propertyName = "", Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return;

            backingStore = value;

            OnPropertyChanged(propertyName);

            onChanged?.Invoke();
        }

        protected void OnErrorOcurred(string errorMessage)
        {
            ErrorOcurred?.Invoke(this, errorMessage);
        }

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
