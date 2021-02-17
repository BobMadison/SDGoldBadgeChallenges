using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04a_KomodoOutings_Repo
{
    public class KomodoOutingsContent_Repo
    {
        private readonly List<KomodoOutingsContent> _directory =
            new List<KomodoOutingsContent>();

        public int Count
        {
            get
            {
                return _directory.Count;
            }
        }

        public bool AddContentToDirectory (KomodoOutingsContent content)
        {
            int startingCount = _directory.Count;
            _directory.Add(content);
            return _directory.Count > startingCount;
        }

        public List<KomodoOutingsContent> GetContents()
        {
            return _directory;
        }
    }
}
