using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FirstApp.UserControl
{
    class CustomCell : ViewCell
    {
        Label answer;
        RadioButton radioButton;

        public CustomCell()
        {
            answer = new Label();
            radioButton = new RadioButton();

            StackLayout cell = new StackLayout();
            cell.Orientation = StackOrientation.Horizontal;

            StackLayout titleDetailLayout = new StackLayout();
            titleDetailLayout.Children.Add(answer);

            cell.Children.Add(radioButton);
            cell.Children.Add(titleDetailLayout);
            View = cell;
        }

        public static readonly BindableProperty AnswerProperty =
            BindableProperty.Create("Answer", typeof(string), typeof(CustomCell), "");

        public static readonly BindableProperty GroupNameProperty =
            BindableProperty.Create("GroupName", typeof(RadioButton), typeof(CustomCell), null);

        public string Answer
        {
            get { return (string)GetValue(AnswerProperty); }
            set { SetValue(AnswerProperty, value); }
        }

        public RadioButton GroupName
        {
            get { return (RadioButton)GetValue(GroupNameProperty); }
            set { SetValue(GroupNameProperty, value); }
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (BindingContext != null)
            {
                answer.Text = Answer;
                radioButton.GroupName= GroupName.GroupName;
            }
        }
    }
}
