using Xamarin.Forms;
using System;
using System.Collections.ObjectModel;

namespace SQLiteSample
{
    public partial class TodoList : ContentPage
    {
        private Entry textfield = null;
        private ObservableCollection<string> ls = new ObservableCollection<string>() { };
        private ListView lv = null;
        static TodoDatabase localdb = null; 
        public TodoList()
        {
            localdb = new TodoDatabase();

            ObservableCollection<Todo> list = localdb.GetTodoList();
            foreach (Todo t in list)
            {
                ls.Add(t.title);
            }
            
            var addbtn = new Button
            {
                Text = "Add",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            addbtn.Clicked += OnClickAddBtn;

            var delbtn = new Button
            {
				Text = "Del",
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.FillAndExpand
            };
            delbtn.Clicked += OnClickDelBtn;

            var grid = new Grid
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Center,
                RowDefinitions = {
                    new RowDefinition(){Height = GridLength.Auto}
                },
                ColumnDefinitions = {
                    new ColumnDefinition(){Width = new GridLength(1, GridUnitType.Star)},
                    new ColumnDefinition(){Width = new GridLength(1, GridUnitType.Star)}
                },
                Children = {
                    {addbtn, 0, 0}, {delbtn, 1, 0}
                }
            };

            this.textfield = new Entry
            {
                Placeholder = "text"
            };

            this.lv = new ListView
            {
                ItemsSource = ls
            };

            var sl = new StackLayout
            {
                
                Children = {
                    grid, this.textfield, this.lv
                }
            };
            Content = sl;
        }

        void OnClickAddBtn(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("add");
			System.Diagnostics.Debug.WriteLine(this.textfield.Text);
            ls.Add(this.textfield.Text);
            var _t = new Todo();
            _t.title = this.textfield.Text;
            _t._id = 0;
            localdb.UpdateTodo(_t);
            this.textfield.Text = "";
		}

        void OnClickDelBtn(object sender, EventArgs e)
        {
			System.Diagnostics.Debug.WriteLine("del");
            localdb.AllDelete();
            ls.Clear();
        }
    }
}
