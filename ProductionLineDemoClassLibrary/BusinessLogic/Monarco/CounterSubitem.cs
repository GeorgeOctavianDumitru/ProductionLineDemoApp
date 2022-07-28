using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionLineDemoClassLibrary.BusinessLogic.Monarco
{
    public class CounterSubitem
    {
        public class Cnt
        {
            public int v { get; set; }
        }
        public class UP
        {
            public int v { get; set; }
        }
        public class DN
        {
            public int v { get; set; }
        }

        public class E
        {
            public int v { get; set; }
        }

        public class HLD
        {
            public int v { get; set; }
        }

        public class N0
        {
            public int v { get; set; }
        }

        public class Nmax
        {
            public int v { get; set; }
        }

        public class Q
        {
            public int v { get; set; }
        }

        public class R1
        {
            public int v { get; set; }
        }

        public class Root
        {
            public List<Subitem> subitems { get; set; }
        }

        public class SETH
        {
            public int v { get; set; }
        }

        public class SGN
        {
            public int v { get; set; }
        }

        public class Subitem
        {
            public R1 R1 { get; set; }
            public N0 n0 { get; set; }
            public SETH SETH { get; set; }
            public UP UP { get; set; }
            public DN DN { get; set; }
            public HLD HLD { get; set; }
            public Nmax nmax { get; set; }
            public Cnt cnt { get; set; }
            public SGN SGN { get; set; }
            public Q Q { get; set; }
            public E E { get; set; }
        }

    }
}
