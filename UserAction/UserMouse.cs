using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using WindowsInput;

namespace UserAction
{
    public class UserMouse : MouseSimulator, IMouseSimulator
    {
        public UserMouse(IInputSimulator inputSimulator) : base(inputSimulator)
        {
        }

        public void MoveMouseWithVisible(Point newPos)
        {
            Random rnd = new Random();

            var mpoint = MouseOperations.GetCursorPosition();
            var originalPos = new Point(mpoint.X, mpoint.Y);

            var firstPoint = new Point(originalPos.X + rnd.Next(15, 45), originalPos.Y + rnd.Next(15, 45));
            var secondPos = new Point(
                ((originalPos.X + newPos.X) / 2) + rnd.Next(15, 45),
                ((originalPos.Y + newPos.Y) / 2) + rnd.Next(15, 45));
            var thirdPoint = new Point(newPos.X + rnd.Next(15, 45), newPos.Y + rnd.Next(100, 150));

            LinearSmoothMove(firstPoint);
            LinearSmoothMove(secondPos);
            LinearSmoothMove(thirdPoint);
            LinearSmoothMove(newPos);
        }
        public void MoveMouseWithVisible(int toX, int toY )
        {
            MoveMouseWithVisible(new Point(toX, toY));
        }

        private void LinearSmoothMove(Point newPosition)
        {

            Random rnd = new Random();

            var mpoint = MouseOperations.GetCursorPosition();
            Point start =  new Point(mpoint.X,mpoint.Y);
            PointF iterPoint = start;


            // Find the slope of the line segment defined by start and newPosition
            PointF slope = new PointF(newPosition.X - start.X, newPosition.Y - start.Y);

            var steps = Math.Max(Math.Abs(slope.X), Math.Abs(slope.Y));

            // Divide by the number of steps
            slope.X /= steps;
            slope.Y /= steps;

            // Move the mouse to each iterative point.
            for (int i = 0; i < steps; i++)
            {
                iterPoint = new PointF(iterPoint.X + slope.X , iterPoint.Y + slope.Y );
                var misleadinpoint = Point.Round( new PointF(iterPoint.X + 1, iterPoint.Y + 1));
                MouseOperations.SetCursorPosition(misleadinpoint.X, misleadinpoint.Y);
                Thread.Sleep(1);
            }

            // Move the mouse to the final destination.
            MouseOperations.SetCursorPosition(newPosition.X, newPosition.Y);
        }

    }


    /// <summary>
    /// 
    /// </summary>
    public static class MouseOperations
    {

        [DllImport("user32.dll", EntryPoint = "SetCursorPos")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetCursorPos(int x, int y);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetCursorPos(out MousePoint lpMousePoint);

       

        public static void SetCursorPosition(int x, int y)
        {
            SetCursorPos(x, y);
        }

        public static void SetCursorPosition(MousePoint point)
        {
            SetCursorPos(point.X, point.Y);
        }

        public static MousePoint GetCursorPosition()
        {
            MousePoint currentMousePoint;
            var gotPoint = GetCursorPos(out currentMousePoint);
            if (!gotPoint) { currentMousePoint = new MousePoint(0, 0); }
            return currentMousePoint;
        }


        [StructLayout(LayoutKind.Sequential)]
        public struct MousePoint
        {
            public int X;
            public int Y;

            public MousePoint(int x, int y)
            {
                X = x;
                Y = y;
            }
        }
    }
}
