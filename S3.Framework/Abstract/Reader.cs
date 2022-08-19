using System;
using System.Collections.Generic;
using System.IO;

namespace S3.Framework.Abstract
{
    public abstract class Reader
    {
        protected internal string Directory { get; set; }

        public virtual void Load(string filePath)
        {
            if (File.Exists(filePath))
            {
                Directory = Path.GetDirectoryName(filePath);
                Load(File.ReadAllLines(filePath));
            }
            else
            {
                throw new Exception("File cannot be found." + filePath);
            }
        }

        public void Load(IEnumerable<string> data)
        {
            foreach (var line in data)
            {
                Parse(line);
            }

            UpdateSize();
        }

        protected internal abstract void Parse(string line);

        protected internal virtual void UpdateSize()
        {

        }
    }
}
