using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Building_Construction.Repository
{
    /// <summary>
    /// Класс-обёртка для коллекции рабочих.
    /// </summary>
    class WorkersRepository
    {
        ArrayList workers = new ArrayList();
        /// <summary>
        /// Проверка имени рабочего на валидность
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool Validate(string name) {
            return (name != "") && (name != null);
        }
        /// <summary>
        /// Добавление нового рабочего в коллекцию
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool Add(string name)
        {
            if (!Validate(name))
            {
                name = AutoName();
            }
            WorkerBuilder worker = new WorkerBuilder(name);
            workers.Add(worker);
            return true;
        }
        /// <summary>
        /// Создание рабочего с автогенерируемым именем (для удобства)
        /// </summary>
        /// <returns></returns>
        public bool Add()
        {
            return Add(AutoName());
        }
        /// <summary>
        /// Удаление последнего рабочего в коллекции
        /// </summary>
        /// <returns></returns>
        public bool RemoveLatsWorker()
        {
            int index = workers.Count - 1;
            if (index >= 0) {
                return RemoveWorkerAt(index);
            }
            return false;
        }
        /// <summary>
        /// Удаление рабочего по его индексу в коллекции
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool RemoveWorkerAt(int index)
        {
            if (index >= 0 && index < workers.Count) {
                workers.RemoveAt(index);
                return true;
            }
            return false;
        }
        /// <summary>
        /// Получение рабочего по его номеру
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public AbstractWorker this[int index]
        {
            get { return workers[index] as AbstractWorker; }
        }
        /// <summary>
        /// Итератор рабочих для перебора имён всех рабочих
        /// </summary>
        public IEnumerable<string> Workers
        {
            get
            {
                foreach (WorkerBuilder worker in workers) {
                    yield return worker.Name;
                }
            }
        }
        /// <summary>
        /// Свойство для получения количества рабочих в коллекции
        /// </summary>
        public int Count
        {
            get { return workers.Count; }
            protected set { }
        }
        /// <summary>
        /// Автогенерация имени рабочего
        /// </summary>
        /// <returns></returns>
        private string AutoName() {
            return "Рабочий " + (workers.Count + 1);
        }
    }
}
