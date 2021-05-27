using System.ComponentModel;
using System.Runtime.CompilerServices;
using FirstApp.Annotations;
using SQLite;

namespace FirstApp.Models
{
    [Table("Users")]
    public class User : INotifyPropertyChanged
    {
        private int _resultTest1;
        private int _resultTest2;
        private int _resultTest3;

        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string Login { get; set; }

        public int ResultTest1
        {
            get => _resultTest1;
            set
            {
                _resultTest1 = value;
                OnPropertyChanged(nameof(ResultTest1));
            }
        }

        public int ResultTest2
        {
            get => _resultTest2;
            set
            {
                _resultTest2 = value;
                OnPropertyChanged(nameof(ResultTest2));
            }
        }
        
        public int ResultTest3
        {
            get => _resultTest3;
            set
            {
                _resultTest3 = value;
                OnPropertyChanged(nameof(ResultTest3));
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