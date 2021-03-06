# ron-swanson-generator 

[![Build Status](https://dev.azure.com/outstandingprogramming/Ron%20Swanson%20Quote%20Generator/_apis/build/status/jamesthall90.ron-swanson-generator)](https://dev.azure.com/outstandingprogramming/Ron%20Swanson%20Quote%20Generator/_build/latest?definitionId=3)

Created as a nod to [jamesseanwright](https://github.com/jamesseanwright)'s ridiculously simple Node-based Ron Swanson Quote API (and because Ron Swanson is my hero), this is an unnecessarily-overbuilt .NET Core API that performs the same basic functions, and will eventually support even more. Essentially, it's an amusing way for me to try out some new things with .NET Core.

The API is built using the [Command Query Separation (CQS)](https://martinfowler.com/bliki/CommandQuerySeparation.html) design pattern, which reduces coupling within the codebase and sets clear, separate paths for the Read and Write sides of the API. Using this pattern also inherently increases the code's adherence to the Single Responsibility Principle (SRP). 

PostgreSQL was used as the development database combined with Entity Framework Core, but several options are available for use with .NET Core. [Autofac](https://github.com/autofac) is also configured within the codebase to handle Inversion of Control / Dependency Injection.

Once the API reaches a more complete state, I'll add a tutorial for setting up the API locally.

**TODO**: Create AWS S3 Document Handler for uploading / retrieving Ron Swanson images 
