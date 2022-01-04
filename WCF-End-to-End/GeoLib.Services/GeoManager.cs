﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeoLib.Contracts;
using GeoLib.Data;

namespace GeoLib.Services
{
    public class GeoManager : IGeoService
    {
        public IEnumerable<string> GetStates(bool primaryOnly)
        {
            throw new NotImplementedException();
        }

        public ZipCodeData GetZipInfo(string zip)
        {
            ZipCodeData zipCodeData = null;
            IZipCodeRepository zipCodeRepository = new ZipCodeRepository();
            ZipCode zipCodeEntity = zipCodeRepository.GetByZip(zip);
            if (zipCodeEntity != null)
            {
                zipCodeData = new ZipCodeData()
                {
                    City = zipCodeEntity.City,
                    State = zipCodeEntity.State.Abbreviation,
                    ZipCode = zipCodeEntity.Zip
                };
            }
            return zipCodeData;
        }

        public IEnumerable<ZipCodeData> GetZips(string state)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ZipCodeData> GetZips(string zip, int range)
        {
            throw new NotImplementedException();
        }
    }
}