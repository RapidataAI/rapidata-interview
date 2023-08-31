# Rapidata Backend
The Rapidata Backend contains multiple projects that all work together to make Rapidata work. There are currently 3 Accesspoints to the Application and they are:
- Rapidata.Web
- Rapidata.Cli
- Rapidata.Admin


# Rapidata.Web
The Rapidata.Web project is the backend for [rapids-frontend](https://github.com/RapidataAI/rapids-frontend). It's goal is to serve the users that complete our rapids through their mobile devices. 

# Rapidata.Cli
With this CLI the user is able to interact with the application through the command line. The biggest benefit it gives is that it allows for the creation of new Datasets etc.

# Rapidata.Admin
The more improved version of the CLI is the Admin Platform that will allow employees to more directly interact with the Rapidata Ecosystem. It is based on the Dotnet Identities for Authentication and Authorization. It also uses JWT to authenticate the user. The goal of this application is to more easily see the results that Rapidata has generated as well as doing most administrative tasks. The application also has the potential to house the Self-Serve-Portal at some point.