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
using System.Windows.Shapes;

namespace pr5
{
    public partial class AddStudentWindow : Window
    {
        public Classes.Student NewStudent { get; private set; }

        public AddStudentWindow()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            // Валидация
            if (string.IsNullOrWhiteSpace(tbLastName.Text) ||
                string.IsNullOrWhiteSpace(tbFirstName.Text) ||
                string.IsNullOrWhiteSpace(tbSurname.Text))
            {
                MessageBox.Show("Заполните фамилию, имя и отчество!",
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            int course = cbCourse.SelectedIndex + 1;
            bool scholarship = cbScholarship.IsChecked == true;

            NewStudent = new Classes.Student(
                tbFirstName.Text.Trim(),
                tbLastName.Text.Trim(),
                tbSurname.Text.Trim(),
                scholarship,
                course);

            DialogResult = true;
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
