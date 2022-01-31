Feature: API
	Verify APIs with RestSharp


@mytag
Scenario: 00) GET Method
	Given a user in the Login Page
	When sends Get Method
	Then the response code should be 400


@mytag
Scenario: 01) POST Method
	Given a user in the Login Page
	When sends Post Method
	Then the response code should be 200