# iPONO
iPONO

"injected Plain Old .Net Object"

iPONO brings the concept of bundle in .Net. A bundle is a module with a life cycle: it can be installed, started, stopped, updated and uninstalled.

A bundle can declare a class acting as bundle activator. This class will be instantiated by the framework and its OnStart() and OnStop() method will be called to notify the bundle about its activation and deactivation.

Please note that all of that is currently still in dev...
