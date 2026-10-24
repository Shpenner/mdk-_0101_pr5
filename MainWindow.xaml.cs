using System;
using System.Collections.Generic;
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

namespace pr5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Classes.Student> AllStudent = Classes.RepoStudents.AllStudent();
        public int Count = 10;
        public int Step = 0;
        public MainWindow()
        {
            InitializeComponent();

            CreateStudent(Step, Count);
        }

        public void CreateStudent(int Step, int Count)
        {
            for (int iStudent = Step; iStudent < Step + Count; iStudent++)
                if (AllStudent.Count > iStudent)
                    parent.Children.Add(new Elements.Student(AllStudent[iStudent]));
            this.Step += Count;
        }

        private void ScrollViewer_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            ScrollViewer scroll = sender as ScrollViewer;
            double ParentHeight = parent.ActualHeight;
            double WindowHeight = scroll.ActualHeight - 20;
            double DeltaHeight = ParentHeight - WindowHeight;
            if (DeltaHeight - scroll.VerticalOffset < 140)
            {
                CreateStudent(Step, Count);
            }
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new AddStudentWindow { Owner = this };
            if (dialog.ShowDialog() == true && dialog.NewStudent != null)
            {
                // Добавляем в общую коллекцию
                AllStudent.Add(dialog.NewStudent);

                // Сразу отображаем в UI (в конец списка)
                parent.Children.Add(new Elements.Student(dialog.NewStudent));

                // Корректируем Step, чтобы автоподгрузка не дублировала
                // элемент (т.к. он уже добавлен вручную)
                Step = AllStudent.Count;

                // Прокручиваем вниз, чтобы пользователь увидел новую запись
                var scroll = FindScrollViewer(parent);
                scroll?.ScrollToEnd();
            }
        }

        private static ScrollViewer FindScrollViewer(DependencyObject parent)
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                if (child is ScrollViewer sv) return sv;
                var result = FindScrollViewer(child);
                if (result != null) return result;
            }
            return null;
        }
    }
}
