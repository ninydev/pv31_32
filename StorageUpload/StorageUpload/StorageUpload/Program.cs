// See https://aka.ms/new-console-template for more information

using Azure.Storage.Blobs;

string AZURE_STORAGE_CONNECTION_STRING 
    = "DefaultEndpointsProtocol=https;AccountName=pv32;AccountKey=3c0C2+IguBPbQ8sKU7jWv5x+Y5vudb7bpv+cUuBDZZrrwvI3+kv1vX9DLHVy5befkBAfU8Cs/FH++AStPHwTcw==;EndpointSuffix=core.windows.net";
string AZURE_STORAGE_CONTAINER_NAME = "avatars";


try
{
    var containerClient = new BlobContainerClient(
        AZURE_STORAGE_CONNECTION_STRING,
        AZURE_STORAGE_CONTAINER_NAME
    );

    var exists = await containerClient.ExistsAsync();

    if (exists.Value)
    {
        Console.WriteLine("Все ок: подключение установлено, контейнер доступен.");
        
        // var projectDir = Directory.GetCurrentDirectory();
        var fileToUpload = "/home/keeper/ItStep/pv31_32/StorageUpload/StorageUpload/StorageUpload/avatar.gif";
        

        if (fileToUpload == null)
        {
            Console.WriteLine("Ошибка: в корне проекта не найден ни один подходящий файл для загрузки.");
            Environment.ExitCode = 1;
            return;
        }

        var blobName = Path.GetFileName(fileToUpload);
        var blobClient = containerClient.GetBlobClient(blobName);

        await blobClient.UploadAsync(fileToUpload, overwrite: true);

        Console.WriteLine($"Загружено. URL: {blobClient.Uri}");
        
        // await using (var stream = new FileStream(fullPath, FileMode.Create, FileAccess.Write, FileShare.None))
        // {
        //     await request.File.CopyToAsync(stream);
        // }

    }
    else
    {
        Console.WriteLine("Ошибка: контейнер не существует или доступ запрещен.");
        Environment.ExitCode = 1;
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Ошибка: {ex.Message}");
    Environment.ExitCode = 1;
}





