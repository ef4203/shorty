# shorty
Minimal self-hosted link shortener

## Getting started
You can run a prebuild container from docker hub directly on any machine with docker installed.

```sh
docker run -it --network=host --rm ef4203/shorty:latest
```

## Build shorty from source
You can build shorty yourself from source.

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
docker run --network=host local/shorty:latest
```
