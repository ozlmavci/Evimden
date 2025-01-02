using Evimden.CoreLayer.Concrete.LocationEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evimden.DataAccessLayer.Seeds.LocationSeeds
{
    internal static class CitySeed
    {
        internal static List<City> GetCitiesSeeds()
        {
            var cities = new List<City>
            {
                new City { CityId = 1, CountryId = 90, CityName = "Adana" },
                new City { CityId = 2, CountryId = 90, CityName = "Adıyaman" },
                new City { CityId = 3, CountryId = 90, CityName = "Afyonkarahisar" },
                new City { CityId = 4, CountryId = 90, CityName = "Ağrı" },
                new City { CityId = 68, CountryId = 90, CityName = "Aksaray" },
                new City { CityId = 5, CountryId = 90, CityName = "Amasya" },
                new City { CityId = 6, CountryId = 90, CityName = "Ankara" },
                new City { CityId = 7, CountryId = 90, CityName = "Antalya" },
                new City { CityId = 75, CountryId = 90, CityName = "Ardahan" },
                new City { CityId = 8, CountryId = 90, CityName = "Artvin" },
                new City { CityId = 9, CountryId = 90, CityName = "Aydın" },
                new City { CityId = 10, CountryId = 90, CityName = "Balıkesir" },
                new City { CityId = 74, CountryId = 90, CityName = "Bartın" },
                new City { CityId = 72, CountryId = 90, CityName = "Batman" },
                new City { CityId = 69, CountryId = 90, CityName = "Bayburt" },
                new City { CityId = 11, CountryId = 90, CityName = "Bilecik" },
                new City { CityId = 12, CountryId = 90, CityName = "Bingöl" },
                new City { CityId = 13, CountryId = 90, CityName = "Bitlis" },
                new City { CityId = 14, CountryId = 90, CityName = "Bolu" },
                new City { CityId = 15, CountryId = 90, CityName = "Burdur" },
                new City { CityId = 16, CountryId = 90, CityName = "Bursa" },
                new City { CityId = 17, CountryId = 90, CityName = "Çanakkale" },
                new City { CityId = 18, CountryId = 90, CityName = "Çankırı" },
                new City { CityId = 19, CountryId = 90, CityName = "Çorum" },
                new City { CityId = 20, CountryId = 90, CityName = "Denizli" },
                new City { CityId = 21, CountryId = 90, CityName = "Diyarbakır" },
                new City { CityId = 81, CountryId = 90, CityName = "Düzce" },
                new City { CityId = 22, CountryId = 90, CityName = "Edirne" },
                new City { CityId = 23, CountryId = 90, CityName = "Elâzığ" },
                new City { CityId = 24, CountryId = 90, CityName = "Erzincan" },
                new City { CityId = 25, CountryId = 90, CityName = "Erzurum" },
                new City { CityId = 26, CountryId = 90, CityName = "Eskişehir" },
                new City { CityId = 27, CountryId = 90, CityName = "Gaziantep" },
                new City { CityId = 28, CountryId = 90, CityName = "Giresun" },
                new City { CityId = 29, CountryId = 90, CityName = "Gümüşhane" },
                new City { CityId = 30, CountryId = 90, CityName = "Hakkâri" },
                new City { CityId = 31, CountryId = 90, CityName = "Hatay" },
                new City { CityId = 76, CountryId = 90, CityName = "Iğdır" },
                new City { CityId = 32, CountryId = 90, CityName = "Isparta" },
                new City { CityId = 34, CountryId = 90, CityName = "İstanbul" },
                new City { CityId = 35, CountryId = 90, CityName = "İzmir" },
                new City { CityId = 46, CountryId = 90, CityName = "Kahramanmaraş" },
                new City { CityId = 78, CountryId = 90, CityName = "Karabük" },
                new City { CityId = 70, CountryId = 90, CityName = "Karaman" },
                new City { CityId = 36, CountryId = 90, CityName = "Kars" },
                new City { CityId = 37, CountryId = 90, CityName = "Kastamonu" },
                new City { CityId = 38, CountryId = 90, CityName = "Kayseri" },
                new City { CityId = 71, CountryId = 90, CityName = "Kırıkkale" },
                new City { CityId = 39, CountryId = 90, CityName = "Kırklareli" },
                new City { CityId = 40, CountryId = 90, CityName = "Kırşehir" },
                new City { CityId = 79, CountryId = 90, CityName = "Kilis" },
                new City { CityId = 41, CountryId = 90, CityName = "Kocaeli" },
                new City { CityId = 42, CountryId = 90, CityName = "Konya" },
                new City { CityId = 43, CountryId = 90, CityName = "Kütahya" },
                new City { CityId = 44, CountryId = 90, CityName = "Malatya" },
                new City { CityId = 45, CountryId = 90, CityName = "Manisa" },
                new City { CityId = 47, CountryId = 90, CityName = "Mardin" },
                new City { CityId = 33, CountryId = 90, CityName = "Mersin" },
                new City { CityId = 48, CountryId = 90, CityName = "Muğla" },
                new City { CityId = 49, CountryId = 90, CityName = "Muş" },
                new City { CityId = 50, CountryId = 90, CityName = "Nevşehir" },
                new City { CityId = 51, CountryId = 90, CityName = "Niğde" },
                new City { CityId = 52, CountryId = 90, CityName = "Ordu" },
                new City { CityId = 80, CountryId = 90, CityName = "Osmaniye" },
                new City { CityId = 53, CountryId = 90, CityName = "Rize" },
                new City { CityId = 54, CountryId = 90, CityName = "Sakarya" },
                new City { CityId = 55, CountryId = 90, CityName = "Samsun" },
                new City { CityId = 63, CountryId = 90, CityName = "Şanlıurfa" },
                new City { CityId = 56, CountryId = 90, CityName = "Siirt" },
                new City { CityId = 57, CountryId = 90, CityName = "Sinop" },
                new City { CityId = 73, CountryId = 90, CityName = "Şırnak" },
                new City { CityId = 58, CountryId = 90, CityName = "Sivas" },
                new City { CityId = 59, CountryId = 90, CityName = "Tekirdağ" },
                new City { CityId = 60, CountryId = 90, CityName = "Tokat" },
                new City { CityId = 61, CountryId = 90, CityName = "Trabzon" },
                new City { CityId = 62, CountryId = 90, CityName = "Tunceli" },
                new City { CityId = 64, CountryId = 90, CityName = "Uşak" },
                new City { CityId = 65, CountryId = 90, CityName = "Van" },
                new City { CityId = 77, CountryId = 90, CityName = "Yalova" },
                new City { CityId = 66, CountryId = 90, CityName = "Yozgat" },
                new City { CityId = 67, CountryId = 90, CityName = "Zonguldak" }
            };
            return cities;
        }
    }
}
