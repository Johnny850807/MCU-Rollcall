using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCR.fileProcessors;
using MCR.adapters;

namespace MCR.fileProcessors
{
    public class TextParsingDecorator : FileProcessorDecorator
    {
        private TextParser textParser;
        public TextParsingDecorator(FileProcessor fileProcessor, TextParser textParser) : base(fileProcessor){
            this.textParser = textParser;
        }

        public override string read(string fileName, bool createIfNotExists = true)
        {
            var content = fileProcessor.read(fileName, createIfNotExists);
            return textParser.deparse(content);
        }

        public override void write(string fileName, string content, bool createIfNotExists = true, bool append = false)
        {
            var parsedContent = textParser.parse(content);
            fileProcessor.write(fileName, parsedContent, createIfNotExists, append);
        }
    }
}
