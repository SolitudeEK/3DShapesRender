using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DEngine.Engine
{
    public static class ConsoleProvider
    {
        public static (int Width, int Height) GetConsoleSize()
            => (Console.WindowWidth, Console.WindowHeight);
        
       
    }
}
