using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HACPM
{
    public interface IGLDataRepository
    {
        bool Save();
    }

    public class GLDataRepository : IGLDataRepository
    {

        public bool Save()
        {
            return true;
        }
    }
}
