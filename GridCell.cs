using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static snake.Game;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace App_Center
{
    public class GridCell : Grid
    {
        private Rectangle rectangle;

        public GridCell()
        {
            rectangle = new Rectangle
            {
                Fill = new SolidColorBrush(Color.FromRgb(45, 45, 48)), // Dark background
                Stretch = Stretch.Fill
            };
            Children.Add(rectangle);
        }

        public void SetState(CellState state)
        {
            switch (state)
            {
                case CellState.Empty:
                    rectangle.Fill = new SolidColorBrush(Color.FromRgb(45, 45, 48)); // Dark background
                    break;
                case CellState.Snake:
                    rectangle.Fill = new SolidColorBrush(Color.FromRgb(78, 201, 176)); // Teal
                    break;
                case CellState.Apple:
                    rectangle.Fill = new SolidColorBrush(Color.FromRgb(220, 80, 80)); // Red
                    break;
            }
        }
    }
}
