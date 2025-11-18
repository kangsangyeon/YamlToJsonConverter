namespace YamlToJsonConverter
{
    public class Converter
    {
        public void ConvertDirectory(string directoryPath, bool recursive = true)
        {
            var searchOption = recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
            var yamlFiles = Directory.GetFiles(directoryPath, "*.yaml", searchOption)
                .Concat(Directory.GetFiles(directoryPath, "*.yml", searchOption));

            foreach (var filePath in yamlFiles)
            {
                ConvertFileYamlToJson(filePath);
            }
        }

        public void ConvertFileYamlToJson(string filePath)
        {
            var yaml = File.ReadAllText(filePath);
            var deserializer = new YamlDotNet.Serialization.DeserializerBuilder().Build();
            var yamlObject = deserializer.Deserialize(new StringReader(yaml));

            var serializer = new YamlDotNet.Serialization.SerializerBuilder()
                .JsonCompatible()
                .Build();

            var json = serializer.Serialize(yamlObject);

            var jsonFilePath = Path.ChangeExtension(filePath, ".json");
            File.WriteAllText(jsonFilePath, json);
        }
    }
}