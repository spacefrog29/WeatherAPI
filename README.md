# WeatherAPI
Weather API Example using Blazor

Original request was:

Create an authenticated web application using Angular or other frameworks to display the weather output from the REST API at metaweather.  Where Authorised Users can access the weather forcast for Belfast.The page needs to display the next 5 days of weather, including date, weather state, and image to represent the weather state.

Plan of action:

* My most familiar framework is Blazor and C# which extends ASP.Net. I'm sure it wouldn't take long to get my head around Angular or React but speed was of the essence here.
* Investigated how the REST API functions, what it returns and is any API Key required
* Build the initial solution in ASP.NET Core 3.1 (5 is current)
* Add testing Project to the Solution and design initial tests, e.g. "Can Construct"
* Create required Razor Components and remove the inital ones added when solution is spun up
* Design a login scenario which doesn't require database (e.g. cookies or fakebackend model)
* Add models to represent data returned in API Response
* Test to ensure criteria are met.

Findings:
* Although initially I created the solution with Interfaces and Services for separation of concerns I found they were no longer required. This made the testing tricky as everything was inbuilt with little risk of failures being introduced.
* Creating a login had to be simplistic, usually I would use a database backend (SQL) to hold the login information. This would also require encrypt, decrypt too with an individual password Salt.  The login is tested but the username and password are both "1" (both hard coded in the code)
* Unit tests project was left in place with a test in place to test an unused helper class, just to prove the concept.


