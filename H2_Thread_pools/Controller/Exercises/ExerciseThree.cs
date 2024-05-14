using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace H2_Thread_pools.Controller.Exercises
{
	internal class ExerciseThree
	{
		View.View readonly view = new View.View();
		
		/// <summary>
		/// Entry point for ExerciseThree
		/// This method calls 2 other methods, using thread pools.
		/// </summary>
		internal void Start()
		{
			ThreadPool.QueueUserWorkItem(DescribeThread);
			ThreadPool.QueueUserWorkItem(DescribeAndModifyThread);
		}

		/// <summary>
		/// Describes a thread, without modifying it
		/// </summary>
		/// <param name="obj">Object parameter, because we parse a method as a delegate</param>
		private void DescribeThread(object obj)
		{
			view.OutputLine($"Thread is alive: {Thread.CurrentThread.IsAlive} \n" +
				$"Thread is background: {Thread.CurrentThread.IsBackground} \n" +
				$"Thread priority is: {Thread.CurrentThread.Priority} \n" +
				$"Thread id is {Thread.CurrentThread.ManagedThreadId}");

		}

		/// <summary>
		/// Modifies a thread and outputs the information
		/// </summary>
		/// <param name="obj">Object parameter, because we parse a method as a delegate</param>
		private void DescribeAndModifyThread(object obj)
		{
			Thread.CurrentThread.IsBackground = false;
			Thread.CurrentThread.Priority = ThreadPriority.BelowNormal;
			Thread.CurrentThread.Name = "Very cool thread name";

			view.OutputLine($"Thread is alive: {Thread.CurrentThread.IsAlive} \n" +
				$"Thread is background: {Thread.CurrentThread.IsBackground} \n" +
				$"Thread priority is: {Thread.CurrentThread.Priority} \n" +
				$"Thread id is {Thread.CurrentThread.ManagedThreadId} \n" +
				$"Thread name is {Thread.CurrentThread.Name}");

		}

		/**
		 * Answer for assignment:
		 *		|----------------------------------------------------------------------------------------|
		 *		|		Method		|							Description								 |
		 *		|----------------------------------------------------------------------------------------|
		 *		| Start()			| Starts the thread													 |
		 *		|----------------------------------------------------------------------------------------|
		 *		| Suspend()			| Deprecated. Pauses the thread										 |
		 *		|----------------------------------------------------------------------------------------|
		 *		| Resume()			| Deprecated. Resumes a suspended thread							 |
		 *		|----------------------------------------------------------------------------------------|
		 *		| Abort()			| Stops a thread instantly											 |
		 *		|----------------------------------------------------------------------------------------|
		 *		| Join()			| Pauses the current thread, until the new thread is done executing	 |
		 *		|----------------------------------------------------------------------------------------|
		 */
	}
}
