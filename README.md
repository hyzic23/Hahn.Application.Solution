# Hahn.Application.Solution

This is a Single Page Application built with .net 5.0 on the server side and React Typescript Framework on the client. This web api was built using trending Software Patterns and designs such as Unit Of Work, Repository pattern and SOLID. This web api used Dapper, Fluent Api, Fluent Validation, AutoMapper.

## Installation

Docker needs to be installed.
Dotnet framework needs to be installed.
Visual Studio Code was used for this development
Clone current project with git

```bash
git clone {url}
```

Project has been dockerised and image can be created with the command

```bash
docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d
```

Once this is completed the application can be reached on

```bash
docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d
```

http://localhost:3000/

Swagger url: http://localhost:8000/swagger


## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

## Contact
[Github](https://github.com/hyzic23/)

[Linkedin](https://www.linkedin.com/in/hyzic/)



## License
[MIT](https://choosealicense.com/licenses/mit/)
