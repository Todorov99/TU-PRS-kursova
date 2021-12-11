using System;
using System.Collections.Generic;

namespace Files
{
    public interface IReader<T>
    {
        public List<T> LoadContent(string file);
    }
}
