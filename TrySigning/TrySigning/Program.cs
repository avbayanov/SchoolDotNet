using System;
using SignedAssembly;

namespace TrySigning
{
    class Program
    {
        static void Main(string[] args)
        {
#if DEBUG
            Console.WriteLine("Debug mode");
#endif

            #region CallUtils

            Utilities.SayHello();

            #endregion
        }
    }
}