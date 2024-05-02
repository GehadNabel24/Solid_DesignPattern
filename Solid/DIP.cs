using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid
{
    internal class DIP
    {
        public interface IFileReader
        {
            string ReadFile(string filePath);
        }

        public interface IFileWriter
        {
            void WriteFile(string filePath, string content);
        }
        public class FileReader : IFileReader
        {
            public string ReadFile(string filePath)
            {
                return "File content";
            }
        }
        public class FileWriter : IFileWriter
        {
            public void WriteFile(string filePath, string content)
            {
            }
        }
        public class FileProcessor
        {
            private readonly IFileReader _fileReader;
            private readonly IFileWriter _fileWriter;

            public FileProcessor(IFileReader fileReader, IFileWriter fileWriter)
            {
                _fileReader = fileReader;
                _fileWriter = fileWriter;
            }

            public void ProcessFile(string inputFilePath, string outputFilePath)
            {
                string fileContent = _fileReader.ReadFile(inputFilePath);
                _fileWriter.WriteFile(outputFilePath, fileContent);
            }
        }

    }
}
