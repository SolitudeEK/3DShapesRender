using _3DEngine.Figures;
using JetBrains.Annotations;
using System.Text;

namespace _3DEngine.Engine
{
    public class Render
    {
        private IShape _shape;
        private int _width;
        private int _height;
        private int _offsetX;
        private int _offsetY;
        private string[] _screen;

        public Render([NotNull]IShape shape)
        {
            var a = ConsoleProvider.GetConsoleSize();
            _width = a.Width;
            _height = a.Height;

            _offsetX = _width / 2;
            _offsetY = _height / 2;

            _shape = shape;
        }

        public string Process()
        {
            GetClearScreen();
            var faces = GetOrderedPolygones();

           foreach (var face in faces)
           {
                DrawPolygonOutline(face);
           }

           return String.Join("\n", _screen);
        }

        private void DrawPolygonOutline(int[] connections)
        {
            int n = connections.Length;
            for (int i = 1; i < n; i++)
            {
                DrawLine(connections[i - 1],connections[i]);
            }
        }

        private void DrawLine(int fromVertex, int toVertex)
        {
            int x1 = _shape.Vertices[fromVertex].X + _offsetX;
            int x2 = _shape.Vertices[toVertex].X + _offsetX;
            int y1 = _shape.Vertices[fromVertex].Y + _offsetY;
            int y2 = _shape.Vertices[toVertex].Y + _offsetY;


            int dx = Math.Abs(x2 - x1);
            int dy = Math.Abs(y2 - y1);
            int sx = x1 < x2 ? 1 : -1;
            int sy = y1 < y2 ? 1 : -1;
            int err = dx - dy;

            while (true)
            {
                var temp = _screen[y1].ToCharArray();
                temp[x1] = '#';//TODO: add depth symbols
                _screen[y1] = new string(temp);

                if (x1 == x2 && y1 == y2)
                    break;

                int e2 = 2 * err;
                if (e2 > -dy)
                {
                    err -= dy;
                    x1 += sx;
                }
                if (e2 < dx)
                {
                    err += dx;
                    y1 += sy;
                }
            }
        }

        private void FillPolygon()
        {

        }

        private int[][] GetOrderedPolygones()
            => _shape.Faces
                .Select(face => new
                {
                    Indices = face,
                    AverageZ = face.Select(index => _shape.Vertices[index].Z).Average()
                })
                .OrderBy(face => face.AverageZ)
                .Select(f => f.Indices)
                .ToArray();

        private void GetClearScreen()
        {
            var a = new char[_width];
            Array.Fill<char>(a, ' ');
            _screen = new string[_height];
            Array.Fill<string>(_screen, new string(a));
        }
    }

    public static class RenderExtenssion { 
        public static string ConvetToString(this char[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    sb.Append(matrix[i, j]);
                }
                sb.Append('\n');
            }
            return sb.ToString();
        }
    }

}
