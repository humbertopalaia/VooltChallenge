
# VooltChallenge Blocks Management API

API created to technical acknowledgement test to Volt job 

This solution has 5 projects:

## VooltChallenge.API

API responsible to provide endpoints to frontend realize posts, gets, puts and deletes.

## VooltChallenge.Domain

Responsible for Domain classes, like entities, dtos, and enums.

## VooltChallenge.Infra

Responsible for infrastructure classes of solution, like Repository and Exceptions.

## VooltChallenge.Service

Responsible for all business logic of solution and validations.

## VooltChallenge.Test

Some unit tests using xUnit

- Prerequisites
    
    [Visual Studio 2022](https://visualstudio.microsoft.com/pt-br/vs/community/)
    
    [Git 2.38.1 ou mais atual](https://git-scm.com/downloads)

- Setting Up     

  *1. Cloning Repository*

       1.1 Create a directory to store the source code, for example: C:\Work\VoolChallenge*
       1.2 Open Command Prompt in administrator mode and go to created directory
       1.3 Clone the repository (git clone https://github.com/humbertopalaia/VooltChallenge.git)
    
## Package Generation to Deploy
   
    - Inside Visual Studio 2022, access Developer PowerShell (Terminal) and go to API project folder and execute the command abaixo, according your envirionment.

    Windows x64 Environment
    
      dotnet publish -o deploy -f net8.0 -r win-x64 -c Release --self-contained true


    Linux x64 Environment
        
        dotnet publish -o deploy -f net8.0 -r linux-x64 -c Release --self-contained true


