using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLAPP.Data.Entities
{
    public class TrainingData
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public byte IsPrice { get; set; }
        public string Url { get; set; }
        public string NodeId { get; set; }
    }
}
