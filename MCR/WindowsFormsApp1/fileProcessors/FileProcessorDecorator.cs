using MCR.fileProcessors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCR.fileProcessors
{
    public abstract class FileProcessorDecorator : FileProcessor
    {
        protected FileProcessor fileProcessor;

        public FileProcessorDecorator(FileProcessor fileProcessor)
        {
            this.fileProcessor = fileProcessor;
        }

        public abstract string read(string fileName, bool createIfNotExists = true);
        public abstract void write(string fileName, string content, bool createIfNotExists = true, bool append = false);
    }
}
