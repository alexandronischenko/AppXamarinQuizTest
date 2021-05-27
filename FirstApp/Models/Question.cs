using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using FirstApp.Annotations;

namespace FirstApp.Models
{
    public class Question : INotifyPropertyChanged
    {
        private string _questionDescription;
        private string _correctAnswer;
        private ObservableCollection<StringCheckedItem> _answers;

        public Question(string questionDescription, ObservableCollection<string> answers, string correctAnswer)
        {
            QuestionDescription = questionDescription;
            Answers = new ObservableCollection<StringCheckedItem>(answers.Select(x => new StringCheckedItem { Item = x }));
            CorrectAnswer = correctAnswer;
        }

        public string QuestionDescription
        {
            get => _questionDescription;
            set
            {
                _questionDescription = value;
                OnPropertyChanged(nameof(QuestionDescription));
            }
        }

        public ObservableCollection<StringCheckedItem> Answers
        {
            get => _answers;
            set
            {
                _answers = value;
                OnPropertyChanged(nameof(Answers));
            }
        }

        public string CorrectAnswer
        {
            get => _correctAnswer;
            set
            {
                _correctAnswer = value;
                OnPropertyChanged(nameof(CorrectAnswer));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class StringCheckedItem : CheckedItem<string>
    {
    }

    public class CheckedItem<T> : INotifyPropertyChanged
    {
        private T _item;
        private bool _isChecked;

        public T Item
        {
            get => _item;
            set
            {
                _item = value;
                OnPropertyChanged();
            }
        }

        public bool IsChecked
        {
            get => _isChecked;
            set
            {
                _isChecked = value;
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