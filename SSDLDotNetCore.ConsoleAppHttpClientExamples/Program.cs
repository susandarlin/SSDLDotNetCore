﻿// See https://aka.ms/new-console-template for more information

using Newtonsoft.Json;
using SSDLDotNetCore.ConsoleAppHttpClientExamples;
using System.ComponentModel.DataAnnotations;

Console.WriteLine("Hello, World!");

HttpClientExample httpClientExample = new HttpClientExample();
await httpClientExample.RunAsync();

Console.ReadLine();