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
        private static ObservableCollection<Question> _questions;
        private static int _numberOfQuestions;
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

        public int NumberOfQuestions
        {
            get => _numberOfQuestions;
            set
            {
                _numberOfQuestions = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
