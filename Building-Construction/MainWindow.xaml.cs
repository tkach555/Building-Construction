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

using Building_Construction.Repository;
using System.Collections;

namespace Building_Construction
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Получаем из контейнера объект класса WorkersRepository по имени класса
        /// Имя класса в виде текстовой строки получаем при помощи конструкции: typeof(WorkersRepository).Name
        /// </summary>
        WorkersRepository workersRepository = Container.GetService(typeof(WorkersRepository).Name) as WorkersRepository;
        public MainWindow()
        {
            InitializeComponent();

            workersRepository.Add();
            workersRepository.Add();
            workersRepository.Add();
            UpdateView();
        }
        /// <summary>
        /// Обновить представление (форму, окно) в соответствии с измененными данными
        /// </summary>
        private void UpdateView() {
            WorkersList.ItemsSource = workersRepository.Workers;
            ArrayList log = new ArrayList();
            log.Add("Рабочие (" + workersRepository.Count + "):");
            foreach (string name in workersRepository.Workers) {
                log.Add(name);
            }
        }

        private void Button_Click_RemoveWorker(object sender, RoutedEventArgs e)
        {
            workersRepository.RemoveLatsWorker();
            UpdateView();
        }

        private void Button_Click_AddVorker(object sender, RoutedEventArgs e)
        {
            workersRepository.Add();
            UpdateView();
        }
    }
}
