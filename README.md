<p align="center">
<img src="https://github.com/TanmayArya-1p/blob/blob/main/tastetailor/segfaulticon.png?raw=true" width=80></img>
<img src="https://github.com/TanmayArya-1p/blob/blob/main/segfaulticon.png?raw=true" width=80></img>
</p>

# TasteTailor

This project was made by the `Segmentation Fault` team for hack8all 2024 hackathon.

This repository contains the backend needed by the mobile app.

## How to build and run

### If you do not want to build the server
You can use the instance running on my (Garvit) pc, to connect to it use this ip: `10.81.50.195:5000` while connected to IITR_HIGHSPEED_WIFI.
If not connected to wifi then use `death-sucking.gl.at.ply.gg:19979` or `147.185.221.22:19979`. If none of these work them blame pm2 or whoever turned off the floor MCB.

### Building

1. Install [dotnet 8](https://dotnet.microsoft.com/en-us/download)
2. Run `dotnet build` inside solution directory
3. ?????
4. Profit

### Running the server
1. Create a mongodb database and copy its connection string (or use the one created for this hackathon: `mongodb+srv://garvit13:<dbpassword>@segfault.zjbur.mongodb.net/?retryWrites=true&w=majority&appName=segfault` replace `<dbpassword>` with `cLsoObS5t2qYrAe4`)
2. Set the environment variable `MONGODB_CONNECTION_URI` to the connection uri mentioned above
3. Run `dotnet run --prject SegFault.Backend` while inside the solution directory or just `dotnet run` while inside the project directory

**TLDR:**
Everything combined into one command:

For windows: 
```cmd
set MONGODB_CONNECTION_URI="mongodb+srv://garvit13:cLsoObS5t2qYrAe4@segfault.zjbur.mongodb.net/?retryWrites=true&w=majority&appName=segfault" && dotnet run --project SegFault.Backend
```
For Linux:
```sh
export MONGODB_CONNECTION_URI="mongodb+srv://garvit13:cLsoObS5t2qYrAe4@segfault.zjbur.mongodb.net/?retryWrites=true&w=majority&appName=segfault" && dotnet run --project SegFault.Backend
```
use "--unsafe" to allow unsafe a server stop
For Mac:
```zsh
echo 'why do you like pain?'
```

## Other stuff
For schemas and endpoints paste the [swagger file](https://github.com/toasty1307/SegFault.Backend/blob/master/SegFault.Backend/swagger.json) into [swagger editor](https://editor-next.swagger.io/).

## Remarks
This server is in no way finished, I have willingly skipped many security checks to complete this within 36 hours.

I know I shouldn't leave secrets on public github repos but I don't care
