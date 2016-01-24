# jcPVS

A handy library to add versioning request support to WebAPI Responses.  Eventually I plan to add in support for handling entirely different endpoints.

The idea for doing this little library was to handle the scenarios where you made a change to your WebAPI service that adds a new property to the JSON response.  All well and good, however if you have native apps across the board with varying times of approval (Apple Store vs Google Play/Windows) and coordinating client upgrades of platforms this becomes far more challenging that the code itself.  Thus the idea that you can tag attributes inside <b>DataContract<b/> with a version number and it would dynamically remove the properties that aren't available to the client requesting the data.

Trying to make the implementation easy, I've provided a WebAPI service that implements a test object to get you started, but if you have an existing WebAPI Service follow the steps below.

<h2>1. Add the jcPVSMediaFormatter to the WebApiConfig class</h2>
In the <b>Register</b> function add the following lines right after the opening line of the function.

```csharp
config.Formatters.Clear();
config.Formatters.Add(new jcPVSMediaFormatter());
```

<h2>2. Add the jcPVS attribute with an API Version to restrict properties</h2>
```csharp
public class TestObject {
    [jcPVS(125)]
    public string Name { get; set; }

    public int ID { get; set; }
}
```

<h2>3. Either tag your controller with the jcPVSActionFilter or use the jcPVSAPIController</h2>
At this point you can either tag your endpoints in your Controller with the <b>jcPVSActionFilter</b>.  This ActionFilter takes the API_VERSION passed from the Client and adds it to the Content Header to be used in the MediaTypeFormatter.

<h2>4. Add API_VERSION to your HttpClient</h2>
As mentioned in step 3, you'll need to add API_VERSION to your HttpClient's Header Content.

If you have any questions please email me at jarred at jarredcapellman.com
