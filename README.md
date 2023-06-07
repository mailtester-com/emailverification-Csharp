# Bulk Email Verification API in C#

This repository contains a C# implementation for bulk email verification using MailTester's API.

## Description

The given C# script uploads a text file containing email addresses to MailTester's bulk email verification API, retrieves the File ID of the uploaded file and downloads the verification results. 

## Setup

### Requirements

- .NET Core 3.1 or later
- RestSharp library

### Installing RestSharp

To use this script, you need to have the RestSharp library installed. RestSharp is a simple REST and HTTP API client for .NET.

You can install it via NuGet in Visual Studio using the following command in the NuGet Package Manager Console:

```bash
Install-Package RestSharp
```

## Usage

First, replace `"PUT YOUR API KEY HERE"` in the script with your actual MailTester API key. Then replace `"C:\path\to\your\emails.txt"` with the path to your file. 

```csharp
string key = "PUT YOUR API KEY HERE";
string filepath = @"C:\path\to\your\emails.txt";
```

Please note that the '\' in file paths need to be escaped, so use '\\' or '/' in your file paths.

Then, run the script. The script will upload the file, retrieve the file ID and download the verification results. The results are stored in variables `file_id`, `filename`, `unique`, `lines`, `lines_processed`, `status`, `timestamp`, `link1`, `link2`.

```csharp
string file_id = response.Content;

client = new RestClient("https://api.mailtester.com/api/details?secret=" + key + "&id=" + file_id);
request = new RestRequest(Method.GET);
response = client.Execute(request);

// Parse data
var data = response.Content.Split('|');
file_id = data[0];
string filename = data[1];
string unique = data[2];
string lines = data[3];
string lines_processed = data[4];
string status = data[5];
string timestamp = data[6];
string link1 = data[7];
string link2 = data[8];
```

## Note

This is a simple example and doesn't handle exceptions. You might want to add error handling for a production-level application.

## License

[MIT](https://choosealicense.com/licenses/mit/)

Feel free to use, modify and distribute this code as you see fit.

## Contribution

Contributions are always welcome. Please fork this repository and open a pull request to add more features or make improvements.

