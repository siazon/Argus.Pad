//   *********  请勿修改此文件   *********
//   此文件由设计工具再生成。更改
//   此文件可能会导致错误。
namespace Blend.SampleData.SampleDataSource
{
    using System; 
    using System.ComponentModel;

// 若要在生产应用程序中显著减小示例数据涉及面，则可以设置
// DISABLE_SAMPLE_DATA 条件编译常量并在运行时禁用示例数据。
#if DISABLE_SAMPLE_DATA
    internal class SampleDataSource { }
#else

    public class SampleDataSource : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public SampleDataSource()
        {
            try
            {
                Uri resourceUri = new Uri("ms-appx:/SampleData/SampleDataSource/SampleDataSource.xaml", UriKind.RelativeOrAbsolute);
                Windows.UI.Xaml.Application.LoadComponent(this, resourceUri);
            }
            catch
            {
            }
        }

        private GroupCollection _Groups = new GroupCollection();

        public GroupCollection Groups
        {
            get
            {
                return this._Groups;
            }
        }

        private string _Name = string.Empty;

        public string Name
        {
            get
            {
                return this._Name;
            }

            set
            {
                if (this._Name != value)
                {
                    this._Name = value;
                    this.OnPropertyChanged("Name");
                }
            }
        }
    }

    public class Group : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private string _name = string.Empty;

        public string name
        {
            get
            {
                return this._name;
            }

            set
            {
                if (this._name != value)
                {
                    this._name = value;
                    this.OnPropertyChanged("name");
                }
            }
        }

        private string _ID = string.Empty;

        public string ID
        {
            get
            {
                return this._ID;
            }

            set
            {
                if (this._ID != value)
                {
                    this._ID = value;
                    this.OnPropertyChanged("ID");
                }
            }
        }

        private Windows.UI.Xaml.Media.ImageSource _age = null;

        public Windows.UI.Xaml.Media.ImageSource age
        {
            get
            {
                return this._age;
            }

            set
            {
                if (this._age != value)
                {
                    this._age = value;
                    this.OnPropertyChanged("age");
                }
            }
        }

        private ItemCollection _Items = new ItemCollection();

        public ItemCollection Items
        {
            get
            {
                return this._Items;
            }
        }

        private string _Class = string.Empty;

        public string Class
        {
            get
            {
                return this._Class;
            }

            set
            {
                if (this._Class != value)
                {
                    this._Class = value;
                    this.OnPropertyChanged("Class");
                }
            }
        }
    }

    public class Item : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private string _Property1 = string.Empty;

        public string Property1
        {
            get
            {
                return this._Property1;
            }

            set
            {
                if (this._Property1 != value)
                {
                    this._Property1 = value;
                    this.OnPropertyChanged("Property1");
                }
            }
        }

        private string _Property2 = string.Empty;

        public string Property2
        {
            get
            {
                return this._Property2;
            }

            set
            {
                if (this._Property2 != value)
                {
                    this._Property2 = value;
                    this.OnPropertyChanged("Property2");
                }
            }
        }

        private Windows.UI.Xaml.Media.ImageSource _Property3 = null;

        public Windows.UI.Xaml.Media.ImageSource Property3
        {
            get
            {
                return this._Property3;
            }

            set
            {
                if (this._Property3 != value)
                {
                    this._Property3 = value;
                    this.OnPropertyChanged("Property3");
                }
            }
        }
    }

    public class ItemCollection : System.Collections.ObjectModel.ObservableCollection<Item>
    { 
    }

    public class GroupCollection : System.Collections.ObjectModel.ObservableCollection<Group>
    { 
    }
#endif
}
