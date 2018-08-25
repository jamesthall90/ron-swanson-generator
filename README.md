# ron-swanson-generator 

Created as a nod to [jamesseanwright](https://github.com/jamesseanwright)'s ridiculously simple Node-based Ron Swanson Quote API (and because Ron Swanson is my hero), this is an unnecessarily-overbuilt .NET Core API that will perform the same actions, and eventually even more. 

The API is built using the Command Query Segregation design pattern, which reduces coupling within the codebase and sets clear, separate paths for the Read and Write sides of the API. 

PostgreSQL was used as the development database combined with Entity Framework Core, but several options are available for use with .NET Core. [Autofac](https://github.com/autofac) is also configured within the codebase to handle Inversion of Control / Dependency Injection.

Once the API reaches a more complete state, I'll add a tutorial for setting up the API locally.

**TODO**: Create AWS S3 Document Handler for uploading / retrieving Ron Swanson images 
