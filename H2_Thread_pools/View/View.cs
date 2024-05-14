using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2_Thread_pools.View
{
	internal class View
	{
		/// <summary>
		/// Outputs a message on a new line, based on a parameter.
		/// </summary>
		/// <param name="message">String which holds the message that should be output</param>
		internal void OutputLine(string message)
		{
			Console.WriteLine(message);
		}

		/// <summary>
		/// Reads a user input and parses it to an int.
		/// </summary>
		/// <returns>Users input, converted to an int</returns>
		internal sbyte NumberUserInput()
		{
			// Infinite loop, incase of invalid input
			while (true)
			{
				try
				{
					// Reads user input and converts it to int32
					string userInput = Console.ReadLine();
					return sbyte.Parse(userInput);
				}
				catch
				{
					OutputLine("Invalid input, please write a number between 0 and 4");
				}
			}

		}

		/// <summary>
		/// Clears the console for any text and resets the text color to white.
		/// </summary>
		internal void Clear()
		{
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.White;
		}
	}
}