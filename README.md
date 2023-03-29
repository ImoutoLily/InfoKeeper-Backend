# InfoKeeper
`InfoKeeper` is an information management system which uses a tagging system to help keep everything neat and organised.

This is a backend project written in C# 11.0 using .NET 7.0 and GraphQL for the API as opposed to REST. Although this project only supports MySQL, it should be easy to develop the necessary code to make it compatible with other databases if so desired.

### Why?
A lot of social media platforms have a "pinning" system, where users can pin messages, images or files. I have always loved using such systems, especially since I am disorganized. It has helped me out in many ways, but it feels limiting, both because most platforms have a maximum amount of pins one can have, and also because there are certain features that would make the pinned items even more organised and clear that don't yet exist on the majority of social media platforms.

## Contents
1. [Requirements](#requirements)
2. [Installation](#installation)
3. [Setup](#setup)
4. [Run](#run)
5. [Contributing](#contributing)
6. [Contact](#contact)
7. [License](#license)

## Requirements
InfoKeeper requires certain programs and tools to be installed in order to work correctly, these include the following.

* MySQL Server 8.0
* .NET 7.0

## Installation
This project can be installed by simply cloning it using Git.

```bash
git clone https://github.com/ImoutoLily/InfoKeeper-Backend.git
```

## Setup
The MySQL connection string and version are read from environment variables named `INFO_KEEPER_CONNECTION_STRING` and `INFO_KEEPER_VERSION` respectively.

Example of the environment variables:

```bash
INFO_KEEPER_CONNECTION_STRING="server=127.0.0.1;uid=root;pwd=12345;database=test"
INFO_KEEPER_VERSION="8.0.0"
```

More information about connection strings in MySQL can be found [here](https://dev.mysql.com/doc/connector-net/en/connector-net-connections-string.html), and all the connection options can be found [here](https://dev.mysql.com/doc/connector-net/en/connector-net-8-0-connection-options.html).

Once the .env files have bees successfully created, we should install the `ef` CLI and use it to update / create the database.

```bash
dotnet tool install --global dotnet-ef
dotnet ef database update --project InfoKeeper.Presentation.Api -- --environment Development
```

If you want to use the `prod.env` file for updating the database, then you should use the runtime environment `Production`.

## Run
The program can be ran by navigating into the `InfoKeeper` directory and running the following command:

```bash
dotnet run --project InfoKeeper.Presentation.Api --configuration Debug --environment Development
```

Build configurations:

* Debug
* Release

Runtime environments:

* Development
* Production

## Contributing

Coming soon.

## Contact

Discord: `Aurie 🍼🦊#1062`

## License
[MIT](https://github.com/ImoutoLily/InfoKeeper-Backend/blob/master/LICENSE)