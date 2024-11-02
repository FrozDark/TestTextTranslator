// See https://aka.ms/new-console-template for more information

using Grpc.Net.Client;
using Models;

var channel = GrpcChannel.ForAddress("http://localhost:5002");
var grpcTranslatorClient = new Translator.TranslatorClient(channel);

var result = await grpcTranslatorClient.TranslateAsync(new TranslateRequest()
{
    From = "ru",
    To = "en",
    Phrase = "Привет мир!"
});

Console.WriteLine(result.Data);