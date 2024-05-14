using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace H2_Thread_pools.Controller.Exercises
{
	internal class ExerciseTwo
	{
		private delegate void ProcessDelegate();
		private static readonly View.View View = new View.View();

		/// <summary>
		/// Entry point for the ExerciseTwo class.
		/// Calls the HandleStopWatch method, with other methods as parameters.
		/// </summary>
		internal void Start()
		{
			HandleStopWatch(ProcessWithThreadMethod);
			HandleStopWatch(ProcessWithThreadPoolMethod);
		}


		/// <summary>
		/// Keeps track of the time used, to finish the execution in the parameter method.
		/// The time used gets printed to the console.
		/// </summary>
		/// <param name="process"></param>
		private void HandleStopWatch(ProcessDelegate process)
		{
			Stopwatch stopwatch = new Stopwatch();
			View.OutputLine($"{process.Method} timer started");
			stopwatch.Start();

			process();

			stopwatch.Stop();
			View.OutputLine($"{process.Method} timer stopped. Total time: {stopwatch.Elapsed}");

		}

		/// <summary>
		/// Loops through a for-loop, 11 times, calling the Process method using new threads.
		/// </summary>
		private static void ProcessWithThreadMethod()
		{
			int repeatLoop = 11;

			for (int i = 0; i < repeatLoop; i++)
			{
				Thread obj = new Thread(Process);
				obj.Start();
			}
		}

		/// <summary>
		/// Calls Process() 11 times, using thread pools. 
		/// </summary>
		private static void ProcessWithThreadPoolMethod()
		{
			int repeatLoop = 11;

			for (int i = 0; i < repeatLoop; i++)
			{
				ThreadPool.QueueUserWorkItem(Process);
			}
		}

		/// <summary>
		/// Runs through 2 for loops, to require more compute power, when going through the method.
		/// </summary>
		private static void Process(object obj)
		{
			for (int i = 0; i < 100000; i++)
			{
				for (int j = 0; j < 100000; j++)
				{
				}
			}
		}

		/**
		 * Answers to assignment:
		 * Having one for loop makes my laptop go wroooom.
		 * Having 2 for loops makes my laptop go WROOOOOOOOOOOOOOOM!
		 * 
		 * The time to execute is hard to tell. 
		 * Running the same code again and again, has seemingly random results.
		 * Sometimes having 2 for-loops is faster than having 1, which makes no sense.
		 */
	}
}
