namespace _3DEngine.Figures
{
    public class Cube : IShape
    {
        public (int X, int Y, int Z)[] Vertices { get; } = new (int, int, int)[]
        {
        (-10, -10, -10), (10, -10, -10), (10, 10, -10), (-10, 10, -10), // Back face
        (-10, -10, 10), (10, -10, 10), (10, 10, 10), (-10, 10, 10)     // Front face
        };

        public int[][] Faces { get; } = new int[][]
        {
        new int[]{ 0, 1, 2, 3 }, // Back face
        new int[] { 4, 5, 6, 7 }, // Front face
        new int[] { 0, 1, 5, 4 }, // Bottom face
        new int[] { 2, 3, 7, 6 }, // Top face
        new int[] { 0, 3, 7, 4 }, // Left face
        new int[] { 1, 2, 6, 5 }  // Right face
        };

    }
}
