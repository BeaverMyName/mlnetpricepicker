using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLAPP.DTOs.Requests
{
    public class FormRequestRequestDto
    {
        public string? ProductName { get; set; }
        public string? Size { get; set; } 
        public string? Currency { get; set; }
        public string? Site { get; set; }
    }
}
