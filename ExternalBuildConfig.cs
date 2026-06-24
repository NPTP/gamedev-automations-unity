// ReSharper disable InconsistentNaming
// ReSharper disable UnassignedField.Global
// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable ConvertToAutoProperty

using System.Text;
using UnityEngine;

namespace NPTP.GamedevAutomationsUnityHelper
{
    internal struct ExternalBuildConfig
    {
        // These private field names have to match the argument names passed in by the Python build tool.
        [SerializeField] private bool unity_development_build;
        [SerializeField] private bool unity_auto_connect_profiler;
        [SerializeField] private bool unity_deep_profiling_support;
        [SerializeField] private bool unity_script_debugging;
        [SerializeField] private string unity_build_executable_output_path;
        [SerializeField] private string unity_build_target;
        [SerializeField] private string unity_compression_method;
        [SerializeField] private string[] unity_scripting_defines;

        public string BuildExecutableOutputPath => unity_build_executable_output_path;
        public string BuildTarget => unity_build_target;
        public bool DevelopmentBuild => unity_development_build;
        public bool AutoConnectProfiler => unity_auto_connect_profiler;
        public bool DeepProfilingSupport => unity_deep_profiling_support;
        public bool ScriptDebugging => unity_script_debugging;
        public string CompressionMethod => unity_compression_method;
        public string[] ScriptingDefines => unity_scripting_defines;

        public static ExternalBuildConfig FromCommandLine()
        {
            ExternalBuildConfig externalBuildConfig = new ExternalBuildConfig();

            externalBuildConfig.unity_auto_connect_profiler = Utilities.HasCLIArg(nameof(unity_auto_connect_profiler));
            externalBuildConfig.unity_deep_profiling_support = Utilities.HasCLIArg(nameof(unity_deep_profiling_support));
            externalBuildConfig.unity_script_debugging = Utilities.HasCLIArg(nameof(unity_script_debugging));
            externalBuildConfig.unity_development_build = Utilities.HasCLIArg(nameof(unity_development_build));

            string value;
            
            if (Utilities.TryGetCLIArgValue(nameof(unity_build_executable_output_path), out value))
            {
                externalBuildConfig.unity_build_executable_output_path = value;
            }

            if (Utilities.TryGetCLIArgValue(nameof(unity_build_target), out value))
            {
                externalBuildConfig.unity_build_target = value;
            }

            if (Utilities.TryGetCLIArgValue(nameof(unity_compression_method), out value))
            {
                externalBuildConfig.unity_compression_method = value;
            }

            if (Utilities.TryGetCLIArgValue(nameof(unity_scripting_defines), out value))
            {
                externalBuildConfig.unity_scripting_defines = value.Split(';');
            }

            return externalBuildConfig;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(nameof(unity_build_executable_output_path) + ": " + unity_build_executable_output_path);
            sb.AppendLine(nameof(unity_build_target) + ": " + unity_build_target);
            sb.AppendLine(nameof(unity_development_build) + ": " + unity_development_build);
            sb.AppendLine(nameof(unity_auto_connect_profiler) + ": " + unity_auto_connect_profiler);
            sb.AppendLine(nameof(unity_deep_profiling_support) + ": " + unity_deep_profiling_support);
            sb.AppendLine(nameof(unity_script_debugging) + ": " + unity_script_debugging);
            sb.AppendLine(nameof(unity_compression_method) + ": " + unity_compression_method);

            sb.AppendLine(nameof(unity_scripting_defines) + ": ");
            foreach (string define in unity_scripting_defines)
            {
                sb.AppendLine(define);
            }

            return sb.ToString();
        }
    }
}