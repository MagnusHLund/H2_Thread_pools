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

		internal void Start()
		{
			Stopwatch stopwatch = new Stopwatch();

			HandleStopWatch(ProcessWithThreadMethod);
			HandleStopWatch(ProcessWithThreadPoolMethod);
		}

		private void HandleStopWatch(ProcessDelegate process)
		{
			Stopwatch stopwatch = new Stopwatch();
			View.OutputLine($"{process.Method} timer started");
			stopwatch.Start();

			process();

			stopwatch.Stop();
			View.OutputLine($"{process.Method} timer stopped. Total time: {stopwatch.Elapsed}");

		}

		private static void ProcessWithThreadMethod()
		{
			int repeatLoop = 11;

			for (int i = 0; i < repeatLoop; i++)
			{
				Thread obj = new Thread(Process);
				obj.Start();
			}
		}

		private static void ProcessWithThreadPoolMethod()
		{
			int repeatLoop = 11;

			for (int i = 0; i < repeatLoop; i++)
			{
				ThreadPool.QueueUserWorkItem(Process);
			}
		}

		private static void Process(object obj)
		{
		}
	}
}
