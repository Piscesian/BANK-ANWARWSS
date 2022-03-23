using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
//using Nasabah.DataAccess.Models;
using Nasabah.ViewModel;

namespace Nasabah.ServiceProvider
{
    public class NasabahProvider
    {
        //private NasabahContext _context;
        private readonly IConfiguration _config;
        private readonly IMemoryCache _memoryCache;
        public List<NasabahViewModel> _views = new List<NasabahViewModel> { 
            new NasabahViewModel{ 
                ID = 1, NoKTP = "1234567890123456", Nama = "Coba", Alamat = "Disitu", TempatLahir = "Disana", TanggalLahir = new DateTime(1995,02,03), NoHP = "081212123232" },
            new NasabahViewModel{ ID = 2, NoKTP = "5678901234567890", Nama = "Test", Alamat = "Jalan", TempatLahir = "Dipan", TanggalLahir = new DateTime(1996,07,03), NoHP = "081212123131" } };
        public NasabahProvider( IConfiguration config, IMemoryCache memoryCache)
        {
            //_context = context;
            _memoryCache = memoryCache;
            _config = config;
        }
        public NasabahViewModel GetSingleData(int id)
        {
            //var data = _context.MstData.Where(x => x.Id == id).SingleOrDefault();
            var data = _views.Where(x => x.ID == id).SingleOrDefault();
            return data;
        }
        public AjaxViewModel GetAllData()
        {
            var result = new AjaxViewModel();
            //var data = (from datum in _context.MstData
            //            select new MstDatum
            //            {
            //                Id = datum.Id,
            //                Nama = datum.Nama,
            //                NoKtp = datum.NoKtp,
            //                Alamat = datum.Alamat,
            //                TempatLahir = datum.TempatLahir,
            //                TanggalLahir = datum.TanggalLahir,
            //                NoHp = datum.NoHp
            //            });
            var data = _views;
            if (!_memoryCache.TryGetValue("ListNasabah", out List<NasabahViewModel> cacheValue))
            {
                cacheValue = data;

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromSeconds(3));

                _memoryCache.Set("ListNasabah", cacheValue, cacheEntryOptions);
            }
            var cacheData = cacheValue.ToList();

            result.Data = cacheValue;
            result.ItemsCount = _views.Count();
            return result;
        }
        public AjaxViewModel GetDataByKTP(string NoKTP)
        {
            var result = new AjaxViewModel();
            //var data = (from datum in _context.MstData
            //            select new MstDatum
            //            {
            //                Id = datum.Id,
            //                Nama = datum.Nama,
            //                NoKtp = datum.NoKtp,
            //                Alamat = datum.Alamat,
            //                TempatLahir = datum.TempatLahir,
            //                TanggalLahir = datum.TanggalLahir,
            //                NoHp = datum.NoHp
            //            }).Where(x => x.NoKtp == NoKTP);
            var data = _views;
            if (!_memoryCache.TryGetValue("ListNasabah", out List<NasabahViewModel> cacheValue))
            {
                cacheValue = data;

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromSeconds(3));

                _memoryCache.Set("ListNasabah", cacheValue, cacheEntryOptions);
            }
            var cacheData = cacheValue.ToList().Where(x=> x.NoKTP == NoKTP);
            result.Data = cacheData;
            result.ItemsCount =_views.Count();
            return result;
        }

        public AjaxViewModel CreateNewData(NasabahViewModel model)
        {
            try
            {
                var result = new AjaxViewModel();
                //var newData = new MstDatum();
                //newData.NoKTP = model.NoKTP;
                //newData.Nama = model.Nama;
                //newData.Alamat = model.Alamat;
                //newData.TempatLahir = model.TempatLahir;
                //newData.TanggalLahir = model.TanggalLahir;
                //newData.NoHp = model.NoHP;
                //_context.MstData.Add(newData);
                //_context.SaveChanges();
                var data = _views;
                if (!_memoryCache.TryGetValue("ListNasabah", out List<NasabahViewModel> cacheValue))
                {
                    cacheValue = data;

                    var cacheEntryOptions = new MemoryCacheEntryOptions()
                        .SetSlidingExpiration(TimeSpan.FromSeconds(3));

                    _memoryCache.Set("ListNasabah", cacheValue, cacheEntryOptions);
                }
                var cacheData = cacheValue.ToList();

                cacheData.Add(model);
                _memoryCache.Set("ListNasabah", cacheData, TimeSpan.FromDays(1));
                result.IsSuccess = true;
                result.Data = model;
                return result;
            }
            catch (Exception e)
            {
                var result = new AjaxViewModel();
                result.IsSuccess = false;
                result.Message = e.Message;
                return result;
            }
        }
        public AjaxViewModel UpdateData(NasabahEditModel model)
        {
            try
            {
                var result = new AjaxViewModel();
                //var data = _context.MstData.SingleOrDefault(x => x.Id == model.ID);
                var data = _views;
                if (!_memoryCache.TryGetValue("ListNasabah", out List<NasabahViewModel> cacheValue))
                {
                    cacheValue = data;

                    var cacheEntryOptions = new MemoryCacheEntryOptions()
                        .SetSlidingExpiration(TimeSpan.FromSeconds(3));

                    _memoryCache.Set("ListNasabah", cacheValue, cacheEntryOptions);
                }
                var cacheData = cacheValue.ToList();

                var oldData = cacheData.SingleOrDefault(x => x.ID == model.ID);
                var newdata = cacheData.SingleOrDefault(x => x.ID == model.ID);
                newdata.Nama = model.Nama;
                newdata.Alamat = model.Alamat;
                newdata.NoHP = model.NoHP;
                cacheData.Remove(oldData);
                cacheData.Add(newdata);
                _memoryCache.Set("ListNasabah", cacheData, TimeSpan.FromDays(1));
                result.IsSuccess = true;
                result.Data = data;
                return result;
            }
            catch (Exception e)
            {
                var result = new AjaxViewModel();
                result.IsSuccess = false;
                result.Message = e.Message;
                return result;
            }
        }
        public AjaxViewModel DeleteData(int id)
        {
            var result = new AjaxViewModel();
            try
            {
                var data = _views;
                if (!_memoryCache.TryGetValue("ListNasabah", out List<NasabahViewModel> cacheValue))
                {
                    cacheValue = data;

                    var cacheEntryOptions = new MemoryCacheEntryOptions()
                        .SetSlidingExpiration(TimeSpan.FromSeconds(3));

                    _memoryCache.Set("ListNasabah", cacheValue, cacheEntryOptions);
                }
                var cacheData = cacheValue.ToList();

                var tdata = cacheData.SingleOrDefault(x => x.ID == id);
                if (tdata != null)
                {
                    //_context.Remove(data);
                    //_context.SaveChanges();
                    cacheData.Remove(tdata);

                    _memoryCache.Set("ListNasabah", cacheData, TimeSpan.FromDays(1));
                    result.IsSuccess = true;
                }
                return result;
            }
            catch (Exception e)
            {
                result.IsSuccess = false;
                result.Message = e.Message;
                return result;
            }
        }
    }
}
