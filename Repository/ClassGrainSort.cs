using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ClassGrainSort
    {
        private int _id;
        private string _grainName;
        public ClassGrainSort()
        {
            id = 0;
            grainName = "";
        }
        
        public ClassGrainSort(int inId, string inGrainName)
        {
            id = inId;
            grainName = inGrainName;
        }
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }
        
        public string grainName
        {
            get { return _grainName; }
            set { _grainName = value; }
        }
    }
}
