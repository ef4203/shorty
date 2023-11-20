# Shorty
[![.NET Build](https://github.com/ef4203/shorty/actions/workflows/dotnet.yml/badge.svg)](https://github.com/ef4203/shorty/actions/workflows/dotnet.yml)
![GitHub](https://img.shields.io/github/license/ef4203/shorty)
![GitHub pull requests](https://img.shields.io/github/issues-pr/ef4203/shorty)

Shorty is a minimal self-hosted link shortener.

## Getting started
You can run a pre-build container from DockerHub directly on any machine with docker installed.

```sh
docker run -it -p 8080:80 --rm ef4203/shorty:latest
```

Finally you can upen shorty in your browser under http://localhost:8080

## Building from source
Download and install the [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0). You can build the applications with:

```sh
dotnet publish src/Shorty.Web/Shorty.Web.csproj -c Release -o out/
```

Which then can be run with:

```sh
dotnet out/Shorty.Web.dll
```

## Contributing
All contributions are welcome, if you have ideas, improvements or suggestions feel free to open an issue or a pull request on GitHub.

## License
This project is licensed under the MIT license, see: [LICENSE](LICENSE). External dependencies may be subject to different licenses, see [Software Bill of Material](docs/SBOM.md).
