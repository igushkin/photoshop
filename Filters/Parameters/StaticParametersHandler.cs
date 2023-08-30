﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MyPhotoshop
{
    public class StaticParametersHandler<TParameters> : IParametersHandler<TParameters>
        where TParameters : IParameters, new()
    {
        static PropertyInfo[] properties;
        static ParameterInfo[] descriptions;

        static StaticParametersHandler()
        {
            properties = typeof(TParameters)
                .GetProperties()
                .Where(n => n.GetCustomAttributes(typeof(ParameterInfo), false).Length != 0)
                .ToArray();
            descriptions = typeof(TParameters)
                .GetProperties()
                .Select(n => n.GetCustomAttributes(typeof(ParameterInfo), false))
                .Where(n => n.Length > 0)
                .Select(n => n[0])
                .Cast<ParameterInfo>()
                .ToArray();
        }
        
        public TParameters CreateParameters(double[] values)
        {
            var parameters = new TParameters();
            if (properties.Length != values.Length)
                throw new ArgumentException();
            for (int i = 0; i < values.Length; i++)
                properties[i].SetValue(parameters, values[i], new object[0]);
            return parameters;
        }

        public ParameterInfo[] GetDescription()
        {
            return descriptions;
        }
    }
}
