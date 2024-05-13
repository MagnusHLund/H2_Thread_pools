using H2_Thread_pools.Controller.Exercises;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace H2_Thread_pools.Controller
{
	internal class ExerciseHandler
	{
		private readonly View.View view = new View.View();

		/// <summary>
		/// Keeps track of the different exercises to run.
		/// </summary>
		internal void HandleExercises()
		{
			// Infinite loop, so the user can interact with the menu after each exercise has run.
			while (true)
			{
				// Outputs basic user information, and accepts an int input value.
				view.OutputLine("Please write a number between 0 and 4");
				int userInput = view.NumberUserInput();

				// Checks the userInput value and runs the appropriate exercise.
				switch (userInput)
				{
					case 0:
						ExerciseZero();
						break;
					case 1:
						ExerciseOne();
						break;
					case 2:
						ExerciseTwo();
						break;
					case 3:
						ExerciseThree();
						break;
					default:
						continue;
				}

				Reset();
			}
		}

		/// <summary>
		/// The main thread sleeps for 1 second.
		/// Then the console is cleared and the text color is reset.
		/// </summary>
		private void Reset()
		{
			Thread.Sleep(50000);
			view.Clear();
		}

		private void ExerciseZero()
		{
			ExerciseZero exerciseZero = new ExerciseZero();
			for (int i = 0; i < 2; i++)
			{
				/**
				 *  Answer for assignment: 
				 *  There is no difference between running "ThreadPool.QueueUserWorkItem(exerciseZero.Task1);" or 
				 *  "ThreadPool.QueueUserWorkItem(new WaitCallback(exerciseZero.Task1));"
				 *  This is due to C# being so friendly, that it automatically adds the delegate callback function, if it is not specifically included.
				 */
				ThreadPool.QueueUserWorkItem(exerciseZero.Task1);
				ThreadPool.QueueUserWorkItem(exerciseZero.Task2);
			}
		}

		private void ExerciseOne()
		{
			ExerciseOne exerciseOne = new ExerciseOne();
			exerciseOne.Start();
		}

		private void ExerciseTwo()
		{

		}

		private void ExerciseThree()
		{

		}
	}
}
