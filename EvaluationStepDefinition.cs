using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hl7.Fhir.ElementModel;
using Hl7.Fhir.Model;
using Hl7.FhirPath;
using TechTalk.SpecFlow;
using Xunit;

namespace FhirPathSpecFlowTest
{
	[Binding]
	public sealed class EvaluationStepDefinition
	{
		private readonly ScenarioContext context;
		public EvaluationStepDefinition(ScenarioContext injectedContext)
		{
			context = injectedContext;
		}

		[Given(@"I create patient with Id '(.*)'")]
		public void GivenICreatePatientWithId(string patientId)
		{
			var patient = new Patient();
			patient.Id = patientId;
			context.Set<Patient>(patient);
		}

		[When(@"I evaluate the rule '(.*)'")]
		public void WhenIEvaluateTheRule(string rule)
		{
			Patient patient = context.Get<Patient>();
			var typeElement = patient.ToTypedElement();
			bool result = typeElement.Predicate(rule);
			context.Set<bool>(result);		
		}

		[Then(@"The result is true")]
		public void ThenTheResultIsTrue()
		{
			bool result = context.Get<bool>();
			Assert.True(result);
		}
	}
}
