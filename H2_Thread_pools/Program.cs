using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using H2_Thread_pools.Controller;

namespace H2_Thread_pools
{
	internal class Program
	{
		/// <summary>
		/// Calls the controller called ExerciseHandler, at the entry point method.
		/// </summary>
		static void Main()
		{
			new ExerciseHandler().HandleExercises();
		}
	}
}
