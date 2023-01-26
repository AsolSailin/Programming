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
using WordGame.Core;

namespace WordGame.Windows
{
    /// <summary>
    /// Логика взаимодействия для GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        Random random = new Random();
        const int keyCount = 40;
        Question _question;
        Core.Keyboard _keyboard = new Core.Keyboard();
        int click = 0;
        Label[] answerLetters;
        bool completed = false;
        int completedCount = 0;
        int health = 5;
        public GameWindow()
        {
            InitializeComponent();
            tbLifes.Text = health.ToString();
            GenerateQuation();
            GenerateAnswerCell();
            GenerateKeyboard();
        }

        private void GenerateQuation()
        {
            var questions = DataBase.MongoDataBase.FindQuestion();
            int numberQuestion = random.Next(0, questions.Length);
            _question = questions[numberQuestion];
            tbDescription.Text = _question.Description;
            answerLetters = new Label[_question.Answer.Length];
        }

        private void GenerateKeyboard()
        {
            char[] letters = _keyboard.GenerateLetters(_question.Answer);

            for (int i = 0; i < letters.Length; i++)
            {
                var button = new Button()
                {
                    Content = letters[i],
                    Height = 25,
                    Width = 40,
                    Margin = new Thickness(5)
                };
                button.Click += KeyBtn_Click;

                if (i < 10)
                {
                    spLetters1.Children.Add(button);
                }
                else if (i < 20)
                {
                    spLetters2.Children.Add(button);
                }
                else if (i < 30)
                {
                    spLetters3.Children.Add(button);
                }
                else
                    spLetters4.Children.Add(button);
            }
        }

        private void GenerateAnswerCell()
        {
            for (int i = 0; i < _question.Answer.Length; i++)
            {
                var label = new Label()
                {
                    Height = 50,
                    Width = 50,
                    Margin = new Thickness(1),
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                    VerticalContentAlignment = VerticalAlignment.Center
                };
                spAnswer.Children.Add(label);
                answerLetters[i] = label;
            }
        }

        private void KeyBtn_Click(object sender, RoutedEventArgs e)
        {
            completed = false;
            var button = (Button)sender;

            if (button.IsEnabled)
            {
                for (int i = 0; i < _question.Answer.Length; i++)
                {
                    if (click == i)
                    {
                        answerLetters[i].Content = button.Content;
                        button.IsEnabled = false;
                    }
                }
                click++;
            }
        }

        private void CheckBtn_Click(object sender, RoutedEventArgs e)
        {
            btnNext.IsEnabled = true;
            string answer = "";

            /*for (int i = 0; i < answerLetters.Length; i++)
            {
                if ((char)answerLetters[i].Content == _question.Answer[i])
                {
                    completedCount++;
                }
                else
                {
                    answerLetters[i].Content = "";
                }
            }*/

            for (int i = 0; i < answerLetters.Length; i++)
            {
                answer += answerLetters[i].Content;
            }


            if (answer == _question.Answer.ToUpper())
            {
                completed = true;
                MessageBox.Show("The riddle has been successfully solved");
            }
            else
            {
                health--;
                tbLifes.Text = health.ToString();
                MessageBox.Show("The answer is incorrect!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if(health == 0)
            {
                MessageBox.Show("Attempts are exhausted!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                this.Close();
            }
        }

        private void RemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            click = 0;
            spAnswer.Children.Clear();
            spLetters1.Children.Clear();
            spLetters2.Children.Clear();
            spLetters3.Children.Clear();
            spLetters4.Children.Clear();
            GenerateAnswerCell();
            GenerateKeyboard();
        }

        private void NextBtn_Click(object sender, RoutedEventArgs e)
        {
            if (completed)
            {
                click = 0;
                tbDescription.Text = "";
                spAnswer.Children.Clear();
                spLetters1.Children.Clear();
                spLetters2.Children.Clear();
                spLetters3.Children.Clear();
                spLetters4.Children.Clear();
                GenerateQuation();
                GenerateAnswerCell();
                GenerateKeyboard();
            }
            else
            {
                MessageBox.Show("You can't go any further because you haven't solved this riddle yet!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow menu = new MainWindow();
            menu.Show();
            this.Close();
        }
    }
}
