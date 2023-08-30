using System;

namespace MyPhotoshop
{

	
	public interface IFilter
	{
        /// <returns></returns>
  	    ParameterInfo[] GetParameters();
        /// <param name="original"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
		Photo Process(Photo original, double[] parameters);
	}
}

