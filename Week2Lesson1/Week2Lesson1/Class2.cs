using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2Lesson1
{
    public class Complex
    {
        private int _intRealPart;
        private int _intImaginaryPart;

        public int Real 
        {  
            get 
            { 
                return _intRealPart; 
            } 
            set 
            { 
                _intRealPart = value; 
            } 
        }

        public int Imaginary
        {
            get 
            {
                return _intImaginaryPart;
            }
            set 
            { 
                _intImaginaryPart = value; 
            }
        }

        public Complex(int intReal, int intImaginary)
        {
            Real = intReal;
            Imaginary = intImaginary;
        }

        public static Complex operator +(Complex a, Complex b) 
        {
            int intImaginary = a.Imaginary + b.Imaginary;
            int intReal = a.Real + b.Real;
            return new Complex(intReal, intImaginary);
        }
    }
}
