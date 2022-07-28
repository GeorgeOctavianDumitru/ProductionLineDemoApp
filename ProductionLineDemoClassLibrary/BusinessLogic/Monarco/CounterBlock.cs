using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionLineDemoClassLibrary.BusinessLogic.Monarco
{
    public class CounterBlock
    {
        //Counter block inputs on MONARCO unit
        private bool _r1;
        private int _n0;
        private bool _seth;
        private bool _up;
        private bool _down;
        private bool _hold;
        private int _maxNumber;
        //Counter block outputs on MONARCO unit
        private int _count;
        private bool _sign;
        private bool _counterState;
        private bool _errorIndicator;


        /// <summary>
        /// Block Reset. By turning this "TRUE" the counter block reset to the origial settings
        /// </summary>
        public bool R1
        {
            get { return _r1; }
            set { _r1 = value; }
        }


        /// <summary>
        /// Value to set the counter to. You can use this property to set the counter to a predefined number. 
        /// </summary>
        public int N0
        {
            get { return _n0; }
            set { _n0 = value; }
        }
        /// <summary>
        /// This bolean will trigger the SET on the Count block and will set the value of the counter to the value of N0. 
        /// By default, if N0 is not redefined, it will setthe value to 0. 
        /// </summary>
        public bool SETH
        {
            get { return _seth; }
            set { _seth = value; }
        }

        /// <summary>
        /// Increments the value of the counter by 1 when true. 
        /// </summary>
        public bool UP
        {
            get { return _up; }
            set { _up = value; }
        }


        /// <summary>
        /// Decrements the value of the counter by 1 when true. 
        /// </summary>
        public bool DN
        {
            get { return _down; }
            set { _down = value; }
        }


        /// <summary>
        /// Counter freeze.
        /// Whilst this bool is TRUE, the counter 
        /// </summary>
        public bool HLD
        {
            get { return _hold; }
            set { _hold = value; }
        }

        /// <summary>
        /// Counter Target Value
        /// Use this property to set up the maximum number that you want the counter to reach. 
        /// </summary>
        public int nmax
        {
            get { return _maxNumber; }
            set { _maxNumber = value; }
        }


        /// <summary>
        /// Total number of poulses 
        /// </summary>
        public int CNT
        {
            get { return _count; }
            set { _count = value; }
        }


        /// <summary>
        /// Sign of the CNT output
        /// Positive is TRUE, negative if FALSE. 
        /// </summary>
        public bool SGN
        {
            get { return _sign; }
            set { _sign = value; }
        }

        /// <summary>
        /// Counter State (Counting/ Not Counting)
        /// </summary>
        public bool Q
        {
            get { return _counterState; }
            set { _counterState = value; }
        }

        /// <summary>
        /// Error indicator. If this is true, there is an error on the counter block on MONARCO Unit. 
        /// </summary>
        public bool E
        {
            get { return _errorIndicator; }
            set { _errorIndicator = value; }
        }

    }
}
