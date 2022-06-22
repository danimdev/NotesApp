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
using System.Windows.Shapes;

namespace NotesApp
{
    public partial class AddTaskWindow : Window
    {
        int titleMaxCharacterLenth = 30;

        public AddTaskWindow()
        {
            InitializeComponent();
            TitleNameTextBox.MaxLength = titleMaxCharacterLenth;
        }

        private void CreateNewTaskButton(object sender, RoutedEventArgs e)
        {
            if (TitleNameTextBox.Text != "" && DescriptionTextBox.Text != "")
            {
                ((MainWindow)System.Windows.Application.Current.MainWindow).AddNewTask(TitleNameTextBox.Text, DescriptionTextBox.Text);
                ((MainWindow)System.Windows.Application.Current.MainWindow).atw.Hide();
            }
            else
            {
                MessageBox.Show("Some of the Fields are empty!");
            }
        }

        private void CancelButton(object sender, RoutedEventArgs e)
        {
            ((MainWindow)System.Windows.Application.Current.MainWindow).atw.Hide();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }
    }
}
