# masonogcrm CRM demo application

This application is a demo application that demonstrates some of my software development capabilities. 
A live version with an In Memory database that resets when the AppDomain recycles is hosted 
[on Azure](http://ogcrm.azurewebsites.net/). When run locally (not in Azure) SqlServer's local database is used.

This application was built with a number of different tools. I'll describe most of them, my familiarity with them, why I chose them.

### ASP.NET MVC
I orginally began my development career with ASP.NET Web Forms, but I wish I had been exposed to MVC much sooner. MVC plays nicely with the web, and provides a clean way of interacting with MVC. Although I'm fairly new to MVC, I've come to greatly prefer it over Web Forms for server side web development work. 

### ASP.NET Web API
Web API is my framework of choice for exposing endpoints for client side code to interact with. The similar syntax to MVC (and in MVC 5, Web API and MVC have merged) and its ease of creating REST-based API make it pretty simple to hook some code up.

### Entity Framework
Entity Framework appears to be the most popular ORM in the .NET world. I come from an Oracle RDBMS background, so unfortunately I haven't quite gotten as much experience with EF as I would like. With Oracle I would usually create my own ADO.NET based data layer. The ORM takes care of a lot of that repitive code. I like that EF comes with a Fluent API for performing configuration rather than forcing you to edit XML files or pollute the domain models with a lot of attributes.

### Elmah
Elmah is an Error Logging Module And Handler that can process unhandled exceptions from ASP.NET. It can store exception details in a number of database formats, and it can even do an email notification when an unhandled exception has occurred. I have used Elmah extensively at work. The only way I would improve this tool is to make the web page for viewing the exception details more mobile friendly.

### Bootstrap with Insignia Layout
Most web applications I have built did not need to look pretty, form was valued over function. Bootstrap allows me to quickly create a useful responsive design without having to spend a lot of time manually writing CSS/LESS/SASS. I started developing this application with the default Bootstrap theme, but was able to quickly plug in Insignia which provided a beautiful LOB Admin themed site without needing a lot of changes to the original markup.

### Ninject
My current company has never really allowed me enough time to perform proper unit testing of my applications, so I did not get into DI/IoC until recently. Ninject has libraries for the major ASP.NET frameworks and it's what I'm most familiar with. I think in future projects I would like to try some other IoC containers such as Autofac so that I have a better appreciation of what's good and what isn't.

### Moq
Like I said above, I haven't gotten the opportunitity to write a whole lot of unit tests before. I knew the general idea of what mocking was, but I've never done mocking before in any of my projects. So I needed to pick a mocking tool in a hurry, and chose Moq because I had heard it mentioned a few times. After some initial frustrations with how to mock async code and Entity Framework's DbContext, I think I got the hang of it and had a clearer idea of how to define the mocked implementations of the dependencies.

### jQuery
jQuery is fairly ubiquitous, so much that, like any popular tool, there's a backlash. Some people prefer "VanillaJS", but jQuery's quick DOM manipulation helpers and AJAX library really improve the speed at which I can get client side code wired up, so I chose to use it in my application.

### Handlebars
I didn't want to go with a full MV* framework (I've used AngularJS and its templating engine in the past) to perform templating. I wanted to demonstrate some basic JavaScript knowledge but not have ugly HTML embedded in JavaScript strings. I did a quick evaluation of the various JS templating libraries out there and settled with this one. The syntax was similar to the one used in AngularJS, and I liked you can compile the template and reused it multiple times if necessary.

### NUnit
Having only written a few unit tests before, I wasn't familiar with this testing framework (though I had heard the name mentioned). Turns out it isn't too different from the one built into Visual Studio. The NUnit application (looks like an Old Windows Forms program) was pretty ugly and I didn't like having to switch out of VS in order to run the tests. But I found a VS extension that integrated NUnit and was able to achieve a much faster build -> test workflow.

## Tools I didn't use

### Generic repository layer

I think my code would have been a lot cleaner if I had come up with a generic repository layer. Something like:

    <T> GetEntity(Expression<Func<T, bool>> expression);
	<T> UpdateEntity(T entity);
	
Two factors kept me from doing this. The first was that I had already started writing a non-generic repository, and I didn't want to refactor the code, wasting time I could have spend elsewhere. The other consideration was that I knew I was going to unit test the repository, and I was unfamiliar with the mocking tools and I suspect that mocking these types of generic repositories adds an additional layer of complexity. I would definitely be interested in doing this in future applications though.

### Async/await
I originally started with an Async repository. But it turns out that Web API filters don't support Async. And mocking async functions is more difficult. And the big reason, the thing that made me switch back to sync code halfway through, was that I didn't do my homework and figure out if Entity Framework's DbContext class was threadsafe. When writing synchronous code, it's not too big a deal because as long as you create a new DbContext per each HTTP request/response lifecycle, you'll never have more than one thread accessing the DbContext (assuming you don't do something silly like spin up your own threads in ASP.NET). But with async code, you can encounter race conditions due to more threads accessing the DbContext. This really caught me offguard (my own fault) and I had to think about the best way to proceed. Dumping the async/await turned out to be a fairly easy refactoring. It's a bit of a shame, because I haven't had many chances to use async/await (none of the common Oracle Clients truly support it).

### ASP.NET Identity
Identity provides a quick way to get up and running with user accounts, and has really supplanted Membership in ASP.NET due to the ease of modifying user accounts and roles, and the ease of hooking up with external authentication providers via OAuth. But I sometimes feel like Identity is too much, and I wanted to demonstrate I could securely implement a user authentication mechanism. I didn't quite have time to do everything I would have liked (automatic lockouts to prevent brute force attacks) I was pretty satisfied with what I managed to come up with.

### Angular JS or client side MV* framework
The directions stated to use MVC, and so I took a more MVC oriented approach instead of creating a SPA like I might have otherwise done. I was originally going to use Angular just for it's templating and model binding features, but Angular just doesn't seem to work too well if you don't do everything in consideration of the Angular lifecycle and scope. So I went with a jQuery/Handlebars/custom solution instead.

### Lucene.NET
I really like Lucene.NET, as it is very useful for doing full text search on objects. However, I just didn't have time to get it implemented (I was going to have it search customers and notes). I would have needed to add some additional business logic to update the indexes when the data changes, or to have a background job periodically update the Index (I would have used Hangfire for this). Very cool stuff, just takes a good chunk of time to implement.