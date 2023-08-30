using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPhotoshop
{
    /// <summary>
    /// This class contains a description of one filter parameter: what is it called, within what limits it changes, etc.
    /// This information is necessary to configure the GUI.
    /// </summary>
    public class ParameterInfo : Attribute
    {
        public string Name;
        public double DefaultValue;
        public double MinValue = 0;
        public double MaxValue = 1;
        public double Increment;
    }
}
