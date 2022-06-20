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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<ToDoItem> list = new List<ToDoItem>();
        private ObservableCollection<ToDoItem> taskList;
        public MainWindow()
        {
            InitializeComponent();

            taskList = new ObservableCollection<ToDoItem>
            {
                new ToDoItem() { Title = "Make a new Program",Description = "Make it versatile" },
                new ToDoItem() { Title = "Make a Game", Description = "Let it be a shooter and make it like so you can shoot other enemys" },
                new ToDoItem() { Title = "This is an extra long title to see how it would look like", Description = "test" }
            };

            icTodolist.ItemsSource = taskList;
        }

        public class ToDoItem
        {
            public string Title { get; set; }
            public string Description { get; set; }
        }

        private void DeleteActualElement(object sender, RoutedEventArgs e)
        {
            //remove item from list
            var button = sender as Button;
            var task = button.DataContext as ToDoItem;
            ((ObservableCollection<ToDoItem>)icTodolist.ItemsSource).Remove(task);
        }

        private void MakeNewTask(object sender, RoutedEventArgs e)
        {
            AddTaskWindow atw = new AddTaskWindow();
            atw.Show();
        }
    }
}
