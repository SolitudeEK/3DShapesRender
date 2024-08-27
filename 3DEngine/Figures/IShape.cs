namespace _3DEngine.Figures
{
    public interface IShape
    {
        (int X, int Y, int Z)[] Vertices { get; }

        int[][] Faces { get; }
    }
}
