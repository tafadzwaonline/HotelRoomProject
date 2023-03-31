using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class HotelRoomDTO
    {
        
        public int Id { get; set; }

        [Range(1, 1000, ErrorMessage = "Occupancy must be between 1 and 1000")]
        public int Occupancy { get; set; }

        [Required(ErrorMessage = "Please enter a room name")]
        public string Name { get; set; }


        [Range(1, 1000, ErrorMessage = "Please enter a valid rate")]
        [Required]
        public double RegularRate { get; set; }

        public string Details { get; set; }

        public string SqFt { get; set; }
    }
}
