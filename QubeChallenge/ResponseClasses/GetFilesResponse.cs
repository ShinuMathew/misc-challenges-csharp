using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubeCodingChallenge.ResponseClasses
{
    class GetFilesResponse
    {
        public List<Response> response { get; set; }
    }
    public class Response
    {
        public string status { get; set; }
        public string name { get; set; }
        public string fileHash { get; set; }
        public string createdOn { get; set; }
        public int bytesCompleted { get; set; }
        public int size { get; set; }
        public string fileId { get; set; }
    }

}
