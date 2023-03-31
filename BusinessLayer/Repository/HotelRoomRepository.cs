using AutoMapper;
using BusinessLayer.Repository.IRepository;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repository
{
    public class HotelRoomRepository : IHotelRoomRepository
    {

        private readonly ApplicationDbContext _db;

        private readonly IMapper _mapper;

        public HotelRoomRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<HotelRoomDTO> CreateHotelRoom(HotelRoomDTO hotelRoomDTO)
        {
            try
            {
                HotelRoom hotelroom = _mapper.Map<HotelRoomDTO, HotelRoom>(hotelRoomDTO);
                hotelroom.CreatedDate = DateTime.Now;   
                hotelroom.CreatedBy = "";
                hotelroom.UpdatedBy = "Tafadzwa";
                var addedHotelRoom = await _db.HotelRooms.AddAsync(hotelroom);
                await _db.SaveChangesAsync();

                return _mapper.Map<HotelRoom, HotelRoomDTO>(addedHotelRoom.Entity);
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public async Task<int> DeleteHotelRoom(int roomId)
        {
            var roomDeatils = await _db.HotelRooms.FindAsync(roomId);

            if (roomDeatils != null)
            {
                _db.HotelRooms.Remove(roomDeatils);
                return await _db.SaveChangesAsync();
            }


            return 0;
        }

        public async Task<IEnumerable<HotelRoomDTO>> GetAllHotelRooms()
        {
            try
            {
                IEnumerable<HotelRoomDTO> hotelRoomDTOs = _mapper.Map<IEnumerable<HotelRoom>, IEnumerable < HotelRoomDTO >> (_db.HotelRooms);

                return hotelRoomDTOs;
            }
            catch (Exception ex)
            {
                return null;
                
            }
        }

        public async Task<HotelRoomDTO> GetHotelRoom(int roomId)
        {
            try
            {
                HotelRoomDTO hotelRoom = _mapper.Map<HotelRoom,HotelRoomDTO>(
                    await _db.HotelRooms.FirstOrDefaultAsync(x => x.Id == roomId));

                return hotelRoom;

            }
            catch (Exception ex)
            {
                return null;
            }
                    
        }

        //if unique return null else return object
        public async Task<HotelRoomDTO> IsRoomUnique(string name)
        {
            try
            {
                HotelRoomDTO hotelRoom = _mapper.Map<HotelRoom, HotelRoomDTO>(
                    await _db.HotelRooms.FirstOrDefaultAsync(x => x.Name.ToLower() == name));

                return hotelRoom;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<HotelRoomDTO> UpdateHotelRoom(int roomId, HotelRoomDTO hotelRoomDTO)
        {
            try
            {

                if (roomId == hotelRoomDTO.Id)
                {
                    //valid

                    HotelRoom roomDeatils = await _db.HotelRooms.FindAsync(roomId);
                    HotelRoom room = _mapper.Map<HotelRoomDTO, HotelRoom>(hotelRoomDTO,roomDeatils);

                    room.UpdatedBy = "";
                    room.UpdatedDate = DateTime.Now;

                    var updatedroom = _db.HotelRooms.Update(room);
                    await _db.SaveChangesAsync();

                    return _mapper.Map<HotelRoom, HotelRoomDTO>(updatedroom.Entity);
                }
                else
                {
                    //invalid
                    return null;
                }
            }
            catch (Exception ex)
            {

                return null;
            }
        }
    }
}
