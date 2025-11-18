namespace YamlToJsonConverter
{
    public class ContextMenuRegistry
    {
        // windows의 context menu에 프로그램 실행하는 명령을 추가하는 함수임.
        // args[0]으로 현재 선택한 파일/폴더 또는 위치를 매개변수로 건네줌.
        public void AddContextMenu()
        {
#if PLATFORM_WINDOWS
            var appPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var key = Microsoft.Win32.Registry.ClassesRoot.CreateSubKey(@"Directory\Background\shell\YamlToJsonConverter");
            key.SetValue("", "Convert YAML to JSON");
            key.SetValue("Icon", appPath);
            var commandKey = key.CreateSubKey("command");
            commandKey.SetValue("", $"\"{appPath}\" \"%V\"");
#else
            throw new NotImplementedException();
#endif
        }
    }
}