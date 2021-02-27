# Selenium WebDriver using C#
This is a sample .NET project that uses NUnit as well as Selenium WebDriver to automate UI tests.

### Pre-requisites
*  .NET Core
*  VSCode

### Build
```
dotnet build
```

### Run
```
dotnet test -v=n
```
>**Note**:  The `-v=n` argument is optional.

### Configuration
---
#### JSON
`Config/Env/default.json`

A new file can be added (i.e., staging.json) to update or add settings for a specific environment.

### Environments
---
#### APP_ENV
```
APP_ENV=staging
```
The environment value must match a filename that exists in the `Config/Env` path.

#### Command Line
```
Mac/Linux
export AUT_BASEURL=mywebsie.com

Windows
set AUT_BASEURL=mywebsite.com
```