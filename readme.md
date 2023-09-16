# SpeedConverterAPI

Simple example of a http service (get/post)

Do

```bash
dotnet run
```

check port (here 5224) and try this in a browser:

```bash
http://localhost:5224/api/speedconverter?mph=20
```

To build as a docker-container:

```bash
docker build -t speedconverterapi .
docker run -d -p 8080:80 --name speedconverterapi speedconverterapi
```

now try

```bash
http://localhost:8080/api/speedconverter?mph=20
```

It's also on Docker Hub so you could just

```bash
docker pull mcronberg/speedconverterapi
docker run -d -p 8080:80 --name speedconverterapi_instance mcronberg/speedconverterapi
```
