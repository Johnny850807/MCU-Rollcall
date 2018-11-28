using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCR.models.tools
{
    /// <summary>
    /// A very very hard-coding algorithm dealing with the self-extracting mechanism...
    /// 
    /// (1) It scans and loads 'all' of the files into compressed bytes under the directory where the app started.
    /// (2) Generates codes which decompressing and storing all the bytes back to its original file representation.
    /// (3) Compile the generated codes into exe.
    /// 
    /// But it finally works!!!! Surprising!!!! Shit codes though.
    /// </summary>
    public class McrInstallerFactory
    {
        public static string OUTPUT_NAME = "/output/MCR Installer.exe";
        public static void execute(Action successfullCallback, 
                                    Action errorCallback, 
                                    string outputName)
        {
            Task.Factory.StartNew(() =>
            {
                string outputByteCodeStrb = makeOutputAllFilesBytesCommandCode("", Environment.CurrentDirectory);

                string PROGRAM =
                    "using System;\n"
                    + "using System.IO;\n"
                    + "using System.IO.Compression;\n"
                    + "using System.Diagnostics;\n"
                + "namespace ProgrammaticCompilation\n"
                    + "{\n                                                                    "
                    + "    class Program\n                                                    "
                    + "    {\n                                                                "
                    + "        static void Main(string[] args)\n                              "
                    + "        {\n                                                            "
                    + "            Console.WriteLine(\"正在解壓縮屬於你的銘傳點名系統...\");\n                              "
                    + outputByteCodeStrb
                    + "            \nConsole.WriteLine(\"成功！\");\n                              "
                    + "             if (File.Exists(\"MCR.exe\"))\n "
                    + "                 Process.Start(@\".\\MCR.exe\");\n                        "
                    + "        }                                                            "
                    + "                                                                    "
                    + "        public static byte[] Compress(byte[] fi)\n                                                                                                                       "
                    + "         {\n                                                                                                                                                             "
                    + "             using (MemoryStream outFile = new MemoryStream())\n                                                                                                         "
                    + "             {\n                                                                                                                                                         "
                    + "                 using (MemoryStream inFile = new MemoryStream(fi))\n                                                                                                    "
                    + "                 using (GZipStream Compress = new GZipStream(outFile, CompressionMode.Compress))\n                                                                       "
                    + "                     inFile.CopyTo(Compress);\n                                                                                                                          "
                    + "                 return outFile.ToArray();\n                                                                                                                             "
                    + "             } \n                                                                                                                                                        "
                    + "         }   \n                                                                                                                                                          "
                    + "                                                                                                                                                                       "
                    + "        public static byte[] Decompress(byte[] compressedBytes)     \n                                                                                                  "
                    + "        {\n                                                                                                                                                             "
                    + "            using (MemoryStream input = new MemoryStream(compressedBytes))\n                                                                                            "
                    + "            using (MemoryStream output = new MemoryStream())\n                                                                                                          "
                    + "            {\n                                                                                                                                                         "
                    + "                using (System.IO.Compression.GZipStream zip = new System.IO.Compression.GZipStream(input, System.IO.Compression.CompressionMode.Decompress))\n          "
                    + "                    zip.CopyTo(output);\n                                                                                                                               "
                    + "                return output.ToArray();\n                                                                                                                              "
                    + "            }\n                                                                                                                                                         "
                    + "        }\n"
                    + "    }\n   "
                    + "}\n                              ";

                CodeDomProvider codeProvider = CodeDomProvider.CreateProvider("CSharp");
                CompilerParameters parameters = new CompilerParameters();
                parameters.ReferencedAssemblies.Add("System.dll");
                parameters.GenerateExecutable = true;
                parameters.OutputAssembly = outputName;
                CompilerResults results = codeProvider.CompileAssemblyFromSource(parameters, PROGRAM);

                if (results.Errors.Count == 0)
                    successfullCallback?.Invoke();
                else
                    errorCallback?.Invoke();
            });
        }

        private static string makeOutputAllFilesBytesCommandCode(string parent, string readPath)
        {
            var strb = new StringBuilder();
            string[] dirPaths = Directory.GetDirectories(readPath);
            string[] filePaths = Directory.GetFiles(readPath)
                                .Where(f => !f.Contains("壓縮")).ToArray();

            foreach (var filePath in filePaths)
            {
                var fileName = filePath.Split('\\').Last();
                strb.Append(makeOutputByteCodesCommandCode(
                    readPath + "\\" + fileName, parent + fileName, "F" + fileName.Replace(".", "")));
                strb.Append("\n");
            }

            foreach (var dirPath in dirPaths)
            {
                var dirName = dirPath.Split('\\').Last();
                strb.Append(makeCreateDirectoryCode(parent + dirName));
                strb.Append(makeOutputAllFilesBytesCommandCode(parent + dirName + "\\", readPath + "\\" + dirName));
                strb.Append("\n");
            }
            var result = strb.ToString();
            return result;
        }

        private static string makeCreateDirectoryCode(string path)
        {
            return "Directory.CreateDirectory(@\"" + path + "\");\n";
        }

        private static string makeOutputByteCodesCommandCode(string readFilePath, string outputFileName, string bytesVarName)
        {
            var strb = new StringBuilder();
            byte[] bytes = Compress(File.ReadAllBytes(readFilePath));
            bytesVarName = bytesVarName.Replace(" ", "");
            bytesVarName = bytesVarName.Replace("-", "");
            outputFileName = outputFileName.Replace(" ", "");
            string bytesDeclaration = makeByteArrayDeclarationCode(bytesVarName, bytes);
            strb.Append(bytesDeclaration);
            strb.Append("File.WriteAllBytes(@\"").Append(outputFileName).Append("\",")
                .Append(bytesVarName).Append(");\n");
            strb.Append("Console.WriteLine(\"").Append(bytesVarName).Append(" bytes length: \"+").Append(bytesVarName).Append(".Length);\n");
            strb.Append(bytesVarName + "= null;\n");
            strb.Append("System.GC.Collect();\n");
            var result = strb.ToString();
            return result;
        }

        private static string makeByteArrayDeclarationCode(string varName, byte[] bytes)
        {
            var strb = new StringBuilder();
            strb.Append("byte[] ").Append(varName);
            strb.Append(" = Decompress(new byte[]{ ");
            for (int i = 0; i < bytes.Length; i++)
            {
                strb.Append(bytes[i]);
                if (i % 5000 == 0) strb.Append("\n");
                strb.Append(",");
            }
            strb.Remove(strb.Length - 1, 1);  //remove tail ','
            strb.Append("});\n");
            return strb.ToString();
        }

        private static void Compress(string fileName)
        {
            byte[] before = File.ReadAllBytes(fileName);
            byte[] after = Compress(before);
            byte[] then = Decompress(after);
        }

        private static byte[] Compress(byte[] fi)
        {
            using (MemoryStream outFile = new MemoryStream())
            {
                using (MemoryStream inFile = new MemoryStream(fi))
                using (GZipStream Compress = new GZipStream(outFile, CompressionMode.Compress))
                {
                    inFile.CopyTo(Compress);
                }
                return outFile.ToArray();
            }
        }

        private static byte[] Decompress(byte[] compressedBytes)
        {
            using (MemoryStream input = new MemoryStream(compressedBytes))
            using (MemoryStream output = new MemoryStream())
            {
                using (System.IO.Compression.GZipStream zip = new System.IO.Compression.GZipStream(input, System.IO.Compression.CompressionMode.Decompress))
                {
                    zip.CopyTo(output);
                }
                return output.ToArray();
            }
        }

    }
}

