using System.Diagnostics;
using System.Text.Json;
using Rhino.FileIO;

namespace Ara3D.RhinoReader
{
    internal class Program
    {
        public static string WorkingDir => Environment.CurrentDirectory;
        public static string ProjectDir => Path.Combine(WorkingDir, "..", "..", "..");
        public static string RepoDir => Path.Combine(ProjectDir, "..", "..", "..");        
        public static string DataDir => Path.Combine(RepoDir, "revit-test-datasets", "rhino");

        static void Main(string[] args)
        {
            Debug.Assert(Directory.Exists(WorkingDir));
            Debug.Assert(Directory.Exists(ProjectDir));
            Debug.Assert(Directory.Exists(DataDir));
            var file3dm = File3dm.Read(Path.Combine(DataDir, "Facade.3dm"));
            var tmp = JsonSerializer.Serialize(file3dm, new JsonSerializerOptions() { WriteIndented = true });
            File.WriteAllText(Path.Combine(ProjectDir, "test.json"), tmp);
            Console.WriteLine("Number of objects in file {0}", file3dm.Objects.Count);
        }
    }
}