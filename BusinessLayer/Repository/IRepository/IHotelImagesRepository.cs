using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repository.IRepository
{
    public interface IHotelImagesRepository
    {
        Task<int> CreateHotelRoomImage(HotelRoomImageDTO image);
        Task<int> DeleteHotelRoomImageByImageId(int imageId);
        Task<int> DeleteHotelRoomImagesByRoomId(int roomId);
        Task<IEnumerable<HotelRoomImageDTO>> GetAllHotelRoomImages(int roomId);
        Task<HotelRoomImageDTO> GetHotelRoomImage(int imageId);
    }
}
