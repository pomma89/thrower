﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace PommaLabs.Thrower.SourceCombiner
{
    public static class Program
    {
        private static readonly HashSet<string> SourceFilesToIgnore = new HashSet<string>
        {
            "AssemblyInfo.cs",
            "LibLog.cs"
        };

        private static readonly Regex IsUsingRegex = new Regex("^using .+;", RegexOptions.Compiled | RegexOptions.Singleline);
        private static readonly Regex IsLicenseRegex = new Regex("\\/\\/(\\s+|$)", RegexOptions.Compiled | RegexOptions.Singleline);
        private static readonly Regex IsObjRegex = new Regex("[\\\\/]obj[\\\\/]", RegexOptions.Compiled | RegexOptions.Singleline);

        private static void Main(string[] args)
        {
            if (args == null || args.Length < 2)
            {
                Console.WriteLine("You must provide at least 2 arguments. The first is the solution file path and the second is the output file path.");
                return;
            }

            string projectFilePath = Path.GetFullPath(args[0]);
            string outputFilePath = Path.GetFullPath(args[1]);

            bool openFile = false;
            if (args.Length > 2)
            {
                Boolean.TryParse(args[2], out openFile);
            }

            var filesToParse = GetSourceFileNames(projectFilePath);
            var namespaces = GetUniqueNamespaces(filesToParse);

            string outputSource = GenerateCombinedSource(namespaces, filesToParse);
            File.WriteAllText(outputFilePath, outputSource);

            if (openFile)
            {
                Process.Start(outputFilePath);
            }
        }

        private static string GenerateCombinedSource(List<string> namespaces, List<string> files)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(@"/*");
            sb.AppendLine($" * File generated by SourceCombiner.exe using {files.Count} source files.");
            sb.AppendLine(@" */");

            foreach (var ns in namespaces.OrderBy(s => s))
            {
                sb.AppendLine("using " + ns + ";");
            }

            foreach (var file in files)
            {
                IEnumerable<string> sourceLines = File.ReadAllLines(file);
                sb.AppendLine(@"//*** SourceCombiner -> original file " + Path.GetFileName(file) + " ***");
                foreach (var sourceLine in sourceLines)
                {
                    var trimmedLine = sourceLine.Trim();
                    var isUsing = IsUsingRegex.IsMatch(trimmedLine);
                    var isLicense = IsLicenseRegex.IsMatch(trimmedLine);
                    if (!string.IsNullOrWhiteSpace(sourceLine) && !isUsing && !isLicense)
                    {
                        sb.AppendLine(sourceLine);
                    }
                }
            }

            return sb.ToString();
        }

        private static List<string> GetSourceFileNames(string projectFilePath)
        {
            var files = new List<string>();
            var projectDirectory = Path.GetDirectoryName(projectFilePath);
            foreach (var item in Directory.EnumerateFiles(projectDirectory, "*.cs", SearchOption.AllDirectories))
            {
                if (IsObjRegex.IsMatch(item))
                {
                    continue;
                }
                if (!SourceFilesToIgnore.Contains(Path.GetFileName(item)))
                {
                    files.Add(item);
                }
            }
            return files;
        }

        private static List<string> GetUniqueNamespaces(List<string> files)
        {
            var names = new List<string>();
            const int namespaceStartIndex = 6;

            foreach (var file in files)
            {
                IEnumerable<string> sourceLines = File.ReadAllLines(file);

                foreach (var sourceLine in sourceLines)
                {
                    var trimmedLine = sourceLine.Trim();
                    if (IsUsingRegex.IsMatch(trimmedLine))
                    {
                        var name = trimmedLine.Substring(namespaceStartIndex, trimmedLine.Length - namespaceStartIndex - 1);

                        if (!names.Contains(name))
                        {
                            names.Add(name);
                        }
                    }
                }
            }

            return names;
        }
    }
}