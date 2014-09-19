using System;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace PertEstimateCalculation
{
	public class Estimate
	{
		public static double Calculate(double likelyAmount, double worstCaseAmount, double bestCaseAmount)
		{
			return (4*  likelyAmount + worstCaseAmount + bestCaseAmount) / 6;
		}

		public static async Task<string> GetString()
		{
			int i = 0;
			for (int x = 0; x < 100000; x++) {
				i+=x;
			}
			return "Success!";
		}
	}
}

