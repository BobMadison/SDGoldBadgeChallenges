using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02a_KomodoClaimsDepartment
{
    public class KomodoClaimsDepartment_Repo
    {
        private readonly List<KomodoClaimsContent> _directory =
            new List<KomodoClaimsContent>();

        public int Count
        {
            get
            {
                return _directory.Count;
            }
        }

        public bool AddContentToDirectory(KomodoClaimsContent content)
        {
            int startCount = _directory.Count;
            _directory.Add(content);
            return _directory.Count > startCount;
        }

        public List<KomodoClaimsContent> GetContents()
        {
            return _directory;
        }
        
        public KomodoClaimsContent GetContentsByClaimID(int claimID)
        {
            foreach (KomodoClaimsContent content in _directory)
            {
                if(claimID == content.ClaimID)
                {
                    return content;
                }
            }
            throw new Exception($"{claimID} is not a valid claim identification.");
        }

        public bool DeleteContentByClaimID (int claimID)
        {
            KomodoClaimsContent contentToDelete = GetContentsByClaimID(claimID);
            return _directory.Remove(contentToDelete);
        }
    }
}
