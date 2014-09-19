using NUnit.Framework;
using System;

namespace PertTest
{
	[TestFixture()]
	public class Test
	{
		[Test()]
		public async void XCheckAsyncMethod_StringReturn()
		{
			// Arrange
			string success = "Success";


			// Act
			string  result = await PertEstimateCalculation.Estimate.GetString();


			// Assert
			Assert.AreEqual(success, result);
		}

		[Test()]
		public void PertEstimate_CalculateWithPositiveValues_CheckAccuracyIsSuccessful()
		{
			// Arrange
			double likelyAmount = 20;
			double bestCaseAmount = 12;
			double worstCaseAmount = 40;

			double estimateResult = 22;


			// Act
			double actualAmount = PertEstimateCalculation.Estimate.Calculate(likelyAmount, worstCaseAmount, bestCaseAmount);


			// Assert
			Assert.AreEqual(estimateResult, actualAmount);
		}

	}
}

