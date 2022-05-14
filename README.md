# Fox's Terminal Webrowser 
## Description
A web browser completly for the terminal. Uses a modified version of https://github.com/Timu5/BasicSharp/tree/master/BasicSharp.
## Sample Code
```BlitzBasic
print "Welcome to Fox's Terminal Web Browser Search engine!\n"
let command = "null"
alt:
goto commandline
commandline:
print ">"
input command
if command = "help" then 
    print "help: view help menue\nsites: view all sites in database" 
endif
if command = "sites" then 
    load "mediaology.com/testing/sites.fw" 
endif
if command = "end" then 
    end 
endif
print "\n"
goto alt
```
## Quick Commands
```
dotnet run
```
```
dotnet publish -c Release -r linux-x64 -p:PublishReadyToRun=false
dotnet publish -c Release -r win-x64 -p:PublishReadyToRun=false
```