using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrkCore.Component.OBJLoader
{
    public abstract class LoaderBase : IDisposable
    {
        private StreamReader _lineStreamReader;

        protected void StartLoad(Stream lineStream)
        {
            _lineStreamReader = new StreamReader(lineStream);

            while (!_lineStreamReader.EndOfStream)
            {
                ParseLine();
            }
        }

        private void ParseLine()
        {
            var currentLine = _lineStreamReader.ReadLine();

            if (string.IsNullOrWhiteSpace(currentLine) || currentLine[0] == '#')
            {
                return;
            }

            var fields = currentLine.Trim().Split(null, 2);
            var keyword = fields[0].Trim();
            var data = fields[1].Trim();

            ParseLine(keyword, data);
        }

        protected abstract void ParseLine(string keyword, string data);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool dispose)
        {
            _lineStreamReader.Dispose();
        }
    }
}
