using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using FirstApp.Annotations;

namespace FirstApp.Models
{
    public class Poll : INotifyPropertyChanged
    {
        private ObservableCollection<Question> _questions;
        private int _result;

        public Poll(ObservableCollection<Question> questions)
        {
            Questions = questions;
        }

        public ObservableCollection<Question> Questions
        {
            get => _questions;
            set
            {
                _questions = value;
                OnPropertyChanged(nameof(Questions));
            }
        }

        public int Result
        {
            get => _result;
            set
            {
                _result = value;
                OnPropertyChanged();
            }
        }

        public override string ToString() => Questions.Count.ToString();

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
