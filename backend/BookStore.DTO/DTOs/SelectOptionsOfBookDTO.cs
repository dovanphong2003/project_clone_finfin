using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DTO.DTOs
{
    public class SelectOptionsOfBookDTO
    {
        public List<SelectOptionDTO> Authors { get; set; }
        public List<SelectOptionDTO> Categories { get; set; }
        public List<SelectOptionDTO> Publishers { get; set; }
    }

    public class SelectOptionDTO
    {
        public long Id { get; set; }      
        public string Name { get; set; }  
    }

}
