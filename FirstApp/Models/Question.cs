using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using FirstApp.Annotations;

namespace FirstApp.Models
{
    public class Question : INotifyPropertyChanged
    {
        private string _questionDescription;
        private string _correctAnswer;
        private ObservableCollection<string> _answers;

        public Question(string questionDescription, ObservableCollection<string> answers, string correctAnswer)
        {
            QuestionDescription = questionDescription;
            Answers = answers;
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

        public ObservableCollection<string> Answers
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

    public class Answer : INotifyPropertyChanged
    {
        private string _someAnswer;
        public event PropertyChangedEventHandler PropertyChanged;

        public Answer(string someAnswer)
        {
            SomeAnswer = someAnswer;
        }
        public string SomeAnswer 
        {
            get => _someAnswer;
            set

            {
                _someAnswer = value;
                OnPropertyChanged(nameof(SomeAnswer));
            }
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}