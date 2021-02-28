# Selenium WebDriver using C#
This is a sample .NET project that uses NUnit as well as Selenium WebDriver to automate UI tests.

### Pre-requisites
*  .NET 5.0
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

### Test Report
After executing test(s), an html report is generated.  By default, it's placed at the root level of `bin\Debug` or 
`bin\Debug\net5.0`.

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