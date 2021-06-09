using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using System.Reflection;

namespace PerfBenchmark
{
    internal class BenchmarkConfig : ManualConfig
    {
        public BenchmarkConfig()
        {
            AddDiagnoser(MemoryDiagnoser.Default);
            AddJob(Job.ShortRun.WithWarmupCount(1).WithIterationCount(1).WithRuntime(CoreRuntime.Core50));

            // Add TargetFrameworks net47 to csproj(removed for CI)
            //AddJob(Job.ShortRun.WithWarmupCount(1).WithIterationCount(1).WithRuntime(ClrRuntime.Net47));
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(Assembly.GetEntryAssembly()).Run(args);
        }
    }
}
