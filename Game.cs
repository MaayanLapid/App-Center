using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Center
{
    public enum Direction { Up, Down, Left, Right }
    public enum CellState { Empty, Snake, Apple }

    public class Game
    {
        private Snake snake;
        private Apple apple;
        private int width;
        private int height;
        private Random random;
        public bool GameOver { get; private set; }
        public int Score { get; private set; }

        public Game(int width, int height)
        {
            this.width = width;
            this.height = height;
            ResetGame();
        }

        public void ResetGame()
        {
            snake = new Snake(width / 2, height / 2);
            random = new Random();
            GenerateApple();
            Score = 0;
            GameOver = false;
        }

        public void Update()
        {
            if (GameOver) return;

            snake.Move();
            WrapSnake();

            if (snake.Head.X == apple.X && snake.Head.Y == apple.Y)
            {
                snake.Grow();
                GenerateApple();
                Score++;
            }

            if (IsGameOver())
            {
                GameOver = true;
            }
        }

        private void WrapSnake()
        {
            var head = snake.Head;
            head.X = (head.X + width) % width;
            head.Y = (head.Y + height) % height;
            snake.UpdateHead(head);
        }

        public void ChangeDirection(Direction direction)
        {
            snake.ChangeDirection(direction);
        }

        public CellState GetCellState(int x, int y)
        {
            if (snake.Body.Any(p => p.X == x && p.Y == y))
                return CellState.Snake;
            if (apple.X == x && apple.Y == y)
                return CellState.Apple;
            return CellState.Empty;
        }

        private void GenerateApple()
        {
            do
            {
                apple = new Apple(random.Next(width), random.Next(height));
            } while (snake.Body.Any(p => p.X == apple.X && p.Y == apple.Y));
        }

        private bool IsGameOver()
        {
            // Game over only if snake collides with itself
            // We exclude the head from the check to avoid false positives
            return snake.Body.Take(snake.Body.Count - 1).Any(p => p.X == snake.Head.X && p.Y == snake.Head.Y);
        }
    }

}
