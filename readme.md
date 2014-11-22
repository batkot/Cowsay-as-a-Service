Cowsay-as-a-Service
===================

Description
-----------
.Net implementation of Tony Monroe's cowsay available -as-a-Service made for fun. 

API
---
To make cow say something funny just send HTTP POST to `~/api/cowsay` with your message as content. If you don't provide message, cow will say a quote got from alpha.mike-r.com [QOTD](http://en.wikipedia.org/wiki/QOTD) server.

The QOTD is also available as-a-Service. Just GET it from `~/api/fortune/get`

Service is currently available at [appharbor](http://caas.apphb.com)


Technologies
------------
- .Net
    - [ASP.NET MVC](http://asp.net/mvc/mvc5)
    - [Web API](http://asp.net/web-api)
    - WCF 
- [Ninject](http://www.ninject.org)
- [xUnit.Net](http://xunit.github.io)
- [ApprovalTests](http://github.com/approvals/ApprovalTests.Net)
- [FakeItEasy](http://fakeiteasy.github.io)
- [jQuery](http://jquery.com)
- [Bootstrap](http://getbootstrap.com)
- [TimeSpan.js](http://github.com/mstum/TimeSpan.js)
