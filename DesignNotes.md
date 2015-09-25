Use XML commenting syntax to document every function.

Use [doxygen](http://www.stack.nl/~dimitri/doxygen/) to generate code documentation.

May want to write a PowerShell script for build and deploy. The build script should generate the Doxygen output.

Use [Ninject](http://www.ninject.org/) for DI.

Write unit tests using [NUnit](http://www.nunit.org/).

Provide REST API for updating info. Will need some sort of token authentication mechanism.

Provide username/password on login page for easy demo access.

Use [Tether](http://github.hubspot.com/tether/) or similar to show info on client side, both Dev and Help.

Integrate [Lucene.Net](https://lucenenet.apache.org/) for searching the site. Perhaps do like Terma Enterprise Search and use custom attributes to describe models.

For the customer location, show a Google or Bing Maps location. At least hyperlink the address to a Google Maps search.

Need database seed method.

Use CDN's where possible for CSS and JS, but use bundling/minification for local content.

Use TypeScript instead of JavaScript. May need to investigate to see if a tool exists to generate TypeScript equivalents of C# domain models. Otherwise write manually.

Document tools used and describe experience level and why I chose those tools. Visual Studio Community 2015, TortoiseGit, HP Omen.

Utilize async for scaling and/or performance.

Do a single Web Forms page (perhaps the user accounts list page?) to demonstrate Web Forms knowledge. Disable ViewState on it, set ClientIdMode to static, and investigate some of the newer Web Forms strongly typed model binding tools.

Scan with tool such as W3C Validator to make sure markup is valid.

Add export to PDF, Word, and vCard formats.

Use [Favicon generator](http://www.favicon-generator.org/) to create nice favicons for all devices.

Need to pick a client side CSS framework. Probably Bootstrap. But what theme? Maybe stick with default theme just to get the application built, then towards the end experiment with a LOB-themed design. Perhaps [Supr](http://themes.suggelab.com/supr/).

# Authentication
Use Identity? Pro: built in VS support and works well with EF. Has built in tools for password hashing, auto account lockout etc. Con: requires lot of code and domain models, which may be overkill for this project.