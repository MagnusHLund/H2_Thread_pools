using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace H2_Thread_pools.Controller.Exercises
{
	internal class ExerciseOne
	{
		private delegate void ProcessDelegate();
		private static readonly View.View View = new View.View();

		/// <summary>
		/// Entry point for the ExerciseOne class.
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

		/** 
		* Answer to question in the assignment:
		* The Process needs an object as a parameter, because QUeueUserWorkItem calls the method as a delegate.
		*/

		/// <summary>
		/// This method is empty, due to measuring performance. 
		/// </summary>
		private static void Process(object obj)
		{
		}
	}
}
