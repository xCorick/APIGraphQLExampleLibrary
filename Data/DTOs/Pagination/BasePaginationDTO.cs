using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTOs.Pagination
{
    public class BasePaginationDTO
    {
        public int Page {  get; set; }
        public int Page_Size { get; set; }
        public bool Is_Active { get; set; }
        public string? Order_Type { get; set; }
        public string? Order_Key { get; set; }
        public string? Search {  get; set; }
    }
}
