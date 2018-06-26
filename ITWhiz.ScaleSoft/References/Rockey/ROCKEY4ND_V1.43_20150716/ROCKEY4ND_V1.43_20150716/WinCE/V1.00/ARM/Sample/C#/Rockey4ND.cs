using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
namespace Sample
{
    class Rockey4ND
    {
            [DllImport("Rockey4ND.dll",EntryPoint="Rockey")]
¡¡¡¡        public static extern ushort Rockey(ushort function, ref ushort handle,ref uint lp1,ref  uint lp2, ref  ushort p1,ref  ushort p2, ref  ushort p3, ref ushort p4,  byte []buffer);
    }
}
