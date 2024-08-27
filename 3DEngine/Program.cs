using _3DEngine.Engine;
using _3DEngine.Figures;

public static class Program
{
    public static void Main()
    {
        Render renderer = new Render(new Cube());
        //while (true)
        //{
            Console.Clear();
            Console.WriteLine(renderer.Process());
            //System.Threading.Thread.Sleep(300); // Sleep for a while to control the refresh rate
       // }
    }
}