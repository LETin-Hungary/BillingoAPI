# BillingoAPI

API for applications using [Billingo](https://www.billingo.hu/) with [.Net Standard 2.0](https://github.com/dotnet/standard).

## Usage

### .Net Standard

Install `LETin.Billingo.Api` NuGet Package.

```csharp
var tokenExpireSeconds = 60;
var billingoApi = new BillingoWebAPI("host", "publickey", "privateKey", tokenExpireSeconds);
var repository = new ClientRepository(billingoApi); // Create any repository you want.
```

### ASP.NET Core

Install `LETin.Billingo.AspNetCore` NuGet Package.

Configure BillingoOptions and call `services.AddBillingo();`.

## Testing

1. Copy `src/Api.Test/Configuration/config.example.txt` to `config.txt` with testing credentials.
1. Run tests.

## Documentation

The official documentation can be found [here](http://billingo.readthedocs.io/).

## License

API for [Billingo](https://www.billingo.hu) written for .NET and ASP.NET\
Copyright (C) 2019 Robin Csutorás

This program is free software: you can redistribute it and/or modify it under
the terms of the GNU General Public License as published by the Free Software
Foundation, either version 3 of the License, or (at your option) any later
version.

This program is distributed in the hope that it will be useful, but WITHOUT
ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with
this program. If not, see <http://www.gnu.org/licenses/>.
