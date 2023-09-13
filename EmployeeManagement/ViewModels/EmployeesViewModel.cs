using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using EmployeeManagement.Models;

namespace EmployeeManagement.ViewModels
{
    class EmployeesViewModel: INotifyPropertyChanged, IEmployeesViewModel
    {
        private EmployeeRepository _employeeRepository { get; }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] String name =null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public EmployeesViewModel()
        {
            _employeeRepository = new EmployeeRepository();
            FillListView();
            FillFilterMessage();
        }

        private ObservableCollection<Employee> _employees;
        public ObservableCollection<Employee> Employees
        {
            get
            {
                return _employees;
            }
            set
            {
                _employees = value;
                OnPropertyChanged();
            }
        }
        private string _filter;
        public string Filter
        {
            get
            {
                return _filter;
            }
            set
            {
                _filter = value;
                FillListView();
                FillFilterMessage();
            }
        }

        private string _filterMessage;
        public string FilterMessage
        {
            get
            {
                return _filterMessage;
            }
            set
            {
                _filterMessage = value;
                OnPropertyChanged();
            }
        }
        private void FillFilterMessage()
        {
            if (!String.IsNullOrEmpty(_filter))
            {
                FilterMessage = "По вашему запросу найдено: " + Employees.Count().ToString();
            }
            else
            {
                FilterMessage = "Введите данные для поиска";
            }
        }


        private void FillListView()
        {
            if (!String.IsNullOrEmpty(_filter))
            {
                Employees = new ObservableCollection<Employee>(
                  _employeeRepository.GetAll()
                  .Where(v => v.FirstName.Contains(_filter)));
            }
            else
            {
                Employees = new ObservableCollection<Employee>(
                  _employeeRepository.GetAll());
            }
        }
        //public ObservableCollection<Employee> Employees
        //{
        //    get
        //    {
        //        return new ObservableCollection<Employee>
        //            (this._employeeRepository.GetAll());
        //    }
        //}
    }
}
