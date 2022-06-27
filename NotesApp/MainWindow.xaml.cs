using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NotesApp
{
    public partial class MainWindow : Window
    {
        List<ToDoItem> list = new List<ToDoItem>();

        public ObservableCollection<ToDoItem> taskList;

        public AddTaskWindow atw;

        public MainWindow()
        {
            InitializeComponent();
            atw = new AddTaskWindow();
            taskList = new ObservableCollection<ToDoItem>
            {
                new ToDoItem() { Title = "Title",Description = "Description" },
            };

            icTodolist.ItemsSource = taskList;

            Window_Loaded();
        }

        //check for the T key when the window loaded
        private void Window_Loaded()
        {
            this.KeyDown += new KeyEventHandler(MainWindow_KeyDown);
        }

        void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.T)
            {
                MakeNewTask(sender,e);
            }
        }

        //adding a new task on pressing the button
        public void AddNewTask(string title, string description)
        {
            taskList.Add(new ToDoItem() { Title = title, Description = description });

            icTodolist.ItemsSource = taskList;
        }

        //the class for an todoitem
        public class ToDoItem
        {
            public string Title { get; set; }
            public string Description { get; set; }
        }

        //when the x Button is Pressed it should be deleted
        private void DeleteActualElement(object sender, RoutedEventArgs e)
        {
            //remove item from list
            var button = sender as Button;
            var task = button.DataContext as ToDoItem;
            ((ObservableCollection<ToDoItem>)icTodolist.ItemsSource).Remove(task);
        }

        //open a window to create a new task
        private void MakeNewTask(object sender, RoutedEventArgs e)
        {
            if (atw.IsActive)
            {
                return;
            }
            else
            {
                atw.TitleNameTextBox.Text = "";
                atw.DescriptionTextBox.Text = "";
                atw.Show();
                
            }
        }

        //when main window is closed close all side windows with it
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            Application.Current.Shutdown();
        }
    }
}
