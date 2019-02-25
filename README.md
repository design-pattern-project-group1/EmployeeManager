# EmployeeManager

This is the Answer to Qn 3. we used Composite, Singleton, Repository and MVC Patterns. We used Asp.Net
for Server Hosting, Razor Pages and bootstrap for Rendering the Views and very few built in MVC functionalities 
other than that we used no Built in Features.

We Might Make some Modifications in the Future But It's Ready to Be Graded at this Moment. Please look in Services
Directory to Find Repository and Singleton Pattern and Models Directory to Find Composite Pattern's Implementation.

The Reason We Chose Composite Pattern is because of the Hierarchical Nature of the Employee Tree and Composite Pattern seems to be a perfect fit for representing it.

The Reason We Chose Singleton Pattern is because we needed there to be only one point of access for our Employees Repository and since we're using in Memory Data we can only use one Single Instance for the entire life-time of the Application.

The Reason we Chose Repository Pattern is because it was the best choice for Data Access especially if we ever switched to a Persistent Data Storage instead of the in Memory one currently implemented it would be a lot more easier to Switch.

The Reason We Chose MVC Pattern is because MVC (Model-View-Controller) is not only the most widely used UI Layer Pattern out there but in the case of Asp.Net Core it is also the most encouraged and most structured pattern for a sound UI. In Asp.Net Core MVC Pattern has a bunch of built-in Framework Tools and Helper Classes but we utilized very few of those only for Server Hosting and Efficient Rendering Functionalities.

Last but not least the Class Diagram Photo is in the root directory (EmployeeManager Folder) but a much more detailed, Clear, concise and interactive diagram is also located in the same directory with a .dgml format (can be viewed using Visual Studio) containing Classes, Methods and All Relationships between them.

Thank you!
