Feature: EvaludatioScenarios
	All FhirPath scenarios

@mytag
Scenario: FhirPath Evaluation
	Given I create patient with Id '1'	
	When I evaluate the rule 'id='1''
	Then The result is true
