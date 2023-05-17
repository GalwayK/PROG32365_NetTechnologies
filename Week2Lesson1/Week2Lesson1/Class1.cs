using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Week2Lesson1
{
    public class Circle 
    {
        private double? _douRadius;
        private double? _douArea;
        private double? douRadius;

        public Circle(double? douRadius)
        {
            this._douRadius = douRadius;
            this.setArea(Math.Pow(Convert.ToDouble(douRadius), 2.0) * Math.PI);
        }

        public void setRadius(double douRadius)
        {
            this._douRadius = douRadius;
        }

        public double? getRadius()
        {
            return this._douRadius;
        }

        public void setArea(double douArea)
        {
            this._douArea = douArea;
        }

        public double? getArea()
        {
            return this._douArea;
        }
    }

}
