using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2_Thread_pools.Controller.Exercises
{
	internal class ExerciseZero
	{
		private readonly View.View view = new View.View();

		/**
		 * Both methods within this class are pretty simple. 
		 * Run through a for loop a few times and output a message to the console window.
		 * They take a object parameter, due to being called as delegates.
		 */

		internal void Task1(object obj)
		{
			int runLoop = 3;
			for (int i = 0; i < runLoop; i++)
			{
				view.OutputLine("Task 1 is being executed.");
			}
		}

		internal void Task2(object obj)
		{
			int runLoop = 3;
			for (int i = 0; i < runLoop; i++)
			{
				view.OutputLine("Task 2 is being executed.");
			}
		}
	}
}
