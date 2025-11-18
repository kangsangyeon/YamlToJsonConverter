using ConsoleAppFramework;

ConsoleApp.Run(args, (string dirPath) =>
{
    Console.WriteLine($"dirPath: {dirPath}");
    var converter = new YamlToJsonConverter.Converter();
    converter.ConvertDirectory(dirPath, true);
});