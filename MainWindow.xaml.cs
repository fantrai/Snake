using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
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
using System.Xml;

namespace Snake
{
    class SnakeEl : Border
    {
        public SnakeEl(Border headSnake)
        {
            Background = headSnake.Background;
        }
    }

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool gameIsActive = true;
        List<Border> snake = new List<Border>();
        Vector vector = new Vector(1, 0);
        Vector lastPos = new Vector(0, 0);
        Vector applePos;
        bool[,] pool;
        int score = 0;

        public MainWindow()
        {
            InitializeComponent();
            StartGame();
        }

        void StartGame()
        {
            TextPan.Text = score.ToString();
            applePos = new Vector(Grid.GetColumn(AppleBox), Grid.GetRow(AppleBox));
            snake.Add(HeadSnake);
            pool = new bool[GamePool.ColumnDefinitions.Count + 1, GamePool.RowDefinitions.Count + 1];
            pool[Grid.GetColumn(HeadSnake), Grid.GetRow(HeadSnake)] = true;
            Move();
        }

        public void Input (object sender, KeyEventArgs e)
        {
            Key inputKey = e.Key;
            switch (inputKey) 
            { 
                case Key.A:
                    if(vector.X!=1)
                        vector = new Vector(-1, 0);
                    break;
                case Key.D:
                    if (vector.X != -1)
                        vector = new Vector(1, 0);
                    break;
                case Key.W:
                    if (vector.Y != 1)
                        vector = new Vector(0, -1);
                    break;
                case Key.S:
                    if (vector.Y != -1)
                        vector = new Vector(0, 1);
                    break;
                case Key.Space:
                    if (!gameIsActive)
                    {
                        RestartGame();
                    }
                    break;
            }
        }

        async void Move()
        {
            while (gameIsActive)
            {
                lastPos = new Vector(Grid.GetColumn(snake.Last()), Grid.GetRow(snake.Last()));

                for (int i = snake.Count -1; i > 0; i--)
                {
                    Grid.SetColumn(snake[i], Grid.GetColumn(snake[i -1]));
                    Grid.SetRow(snake[i], Grid.GetRow(snake[i -1]));
                }

                if (vector.Y == 1 && Grid.GetRow(HeadSnake) == GamePool.RowDefinitions.Count)
                    Grid.SetRow(HeadSnake, 0);
                else if (vector.Y == -1 && Grid.GetRow(HeadSnake) ==0)
                    Grid.SetRow(HeadSnake, GamePool.RowDefinitions.Count);
                else
                    Grid.SetRow(HeadSnake, Grid.GetRow(HeadSnake) + (int)vector.Y);

                if (vector.X == 1 && Grid.GetColumn(HeadSnake) == GamePool.ColumnDefinitions.Count)
                    Grid.SetColumn(HeadSnake, 0);
                else if (vector.X == -1 && Grid.GetColumn(HeadSnake) == 0)
                    Grid.SetColumn(HeadSnake, GamePool.ColumnDefinitions.Count);
                else
                    Grid.SetColumn(HeadSnake, Grid.GetColumn(HeadSnake) + (int)vector.X);

                if (Grid.GetColumn(HeadSnake) == applePos.X && Grid.GetRow(HeadSnake) == applePos.Y)
                {
                    Apple();
                }
                if (pool[Grid.GetColumn(HeadSnake), Grid.GetRow(HeadSnake)])
                {
                    foreach (var item in snake)
                    {
                        int x = Grid.GetColumn(item);
                        int y = Grid.GetRow(item);
                        if (pool[x, y])
                        {
                            item.Background = Brushes.Brown;
                        }
                    }
                    gameIsActive = false;
                    GameOverPan.Visibility = Visibility.Visible;
                }
                pool[Grid.GetColumn(HeadSnake), Grid.GetRow(HeadSnake)] = true;
                pool[(int)lastPos.X, (int)lastPos.Y] = false;

                await Task.Delay(100);
            }
        }

        void Apple()
        {
            var el = new SnakeEl(HeadSnake);
            GamePool.Children.Add(el);
            snake.Add(el);
            Grid.SetColumn(el, (int)lastPos.X);
            Grid.SetRow(el, (int)lastPos.Y);
             
            Random random = new Random();
            int posX;
            int posY;

            do
            {
                posX = random.Next(0, GamePool.ColumnDefinitions.Count);
                posY = random.Next(0, GamePool.RowDefinitions.Count);
            } while (pool[posX, posY]);
            applePos.X = posX;
            applePos.Y = posY;
            Grid.SetColumn(AppleBox, posX);
            Grid.SetRow(AppleBox, posY);
            score++;
            TextPan.Text = score.ToString();
        }

        void RestartGame()
        {
            Process.Start(Assembly.GetEntryAssembly().Location);
            Process.GetCurrentProcess().Kill();
        }
    }
}
