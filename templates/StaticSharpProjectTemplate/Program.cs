using StaticSharp;
using StaticSharp.Gears;
using StaticSharpProjectTemplate.Root;

namespace StaticSharpProjectTemplate
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var entryPointName = Environment.GetEnvironmentVariable("ENTRY_POINT");
            if (entryPointName == null)
            {
                Console.WriteLine("EnvironmentVariable 'ENTRY_POINT' not found.");
                return;
            }

            var entryPoint = typeof(Program).GetMethod(entryPointName,
                System.Reflection.BindingFlags.Public
                | System.Reflection.BindingFlags.Static
                | System.Reflection.BindingFlags.FlattenHierarchy);

            if (entryPoint == null)
            {
                Console.WriteLine($"entryPoint {entryPointName} not found.");
                return;
            }

            if (entryPoint.ReturnType == typeof(Task))
            {
                var task = entryPoint.Invoke(null, null) as Task;
                if (task != null)
                {
                    await task;
                }
            } else
            {
                entryPoint.Invoke(null, null);
            }
        }

        public static async Task Server()
        {
            Cache.RootDirectory = Static.MakeAbsolutePath(".cache");

            await new StaticSharp.Server(
                new DefaultMultilanguagePageFinder<Language>((language) => new αRoot(language)),
                new DefaultMultilanguageNodeToPath<Language>()
                ).RunAsync();
        }

        public static async Task Generator()
        {
            Cache.RootDirectory = Static.MakeAbsolutePath(".cache");

            var projectPath = ProjectDirectory.Path;
            var baseDirectory = Path.GetFullPath(Path.Combine(projectPath, "GeneratedSite"));

            var generator = new MultilanguageStaticGenerator<Language>(
                new DefaultMultilanguageNodeToPath<Language>(),
                new AbsoluteUrl("http", "localhost"),
                FilePath.FromOsPath(baseDirectory)
                );

            await generator.GenerateAsync(new αRoot(default));
        }
    }
}