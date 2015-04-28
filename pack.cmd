@echo Off
set config=%1

if "%config%" == "" (
   set config=Release
)

nuget pack ./src/Elmah.Mvc/elmah.mvc.csproj -Prop Configuration=%config% -Build -output nuget