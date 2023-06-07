using RestSharp;
using System;
using System.IO;

public class Program
{
    static void Main(string[] args)
    {
        string key = "PUT YOUR API KEY HERE";
        string filepath = @"C:\path\to\your\emails.txt";

        // Upload the file
        var client = new RestClient("https://api.mailtester.com/api/bulk?secret=" + key + "&filename=my_emails.txt");
        var request = new RestRequest(Method.POST);
        request.AddFile("file_contents", filepath);
        IRestResponse response = client.Execute(request);

        // You need to save this FILE ID for get file status and download reports in future
        string file_id = response.Content;

        // Download ready file
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
    }
}
