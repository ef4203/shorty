# Shorty
Shorty is a minimal self-hosted link shortener.

## Getting started
You can run a prebuild container from docker hub directly on any machine with docker installed.

```sh
docker run -it -p 8080:80 --rm ef4203/shorty:latest
```

Finally you can upen shorty in your browser under http://localhost:8080

## Build Shorty from source
You can build Shorty yourself from source.

Requirements:
- Docker
- Git

Clone the repository:
```sh
git clone https://github.com/ef4203/shorty.git
```

Navigate into the folder and then build the docker container with:
```sh
docker build -t local/shorty:latest .
```

Finally you can run shorty with:
```sh
docker run -p 8080:80 local/shorty:latest
```

Finally you can upen shorty in your browser under http://localhost:8080
