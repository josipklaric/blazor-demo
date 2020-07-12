using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorTestApp.Shared;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BlazorTestApp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CapitalsController : ControllerBase
    {
        private readonly ILogger<CapitalsController> logger;
        private readonly List<Capital> capitals;

        public CapitalsController(ILogger<CapitalsController> logger)
        {
            this.logger = logger;
            this.capitals = new List<Capital>();
            LoadCapitals();
        }

        [HttpGet]
        [Route("GetCountries")]
        public IEnumerable<string> GetCountries()
        {
            var countries = this.capitals.Select(c => c.CountryName).ToList();
            return countries;
        }

        [HttpGet]
        [Route("GetCapital")]
        public Capital GetCapital(string country)
        {
            var capital = this.capitals.FirstOrDefault(c => c.CountryName.Equals(country, StringComparison.OrdinalIgnoreCase));
            return capital;
        }

        private void LoadCapitals()
        {
            string json = @"
[
    {
        ""CountryName"": ""Afghanistan"",
        ""CapitalName"": ""Kabul"",
        ""CapitalLatitude"": 34.516666666666666,
        ""CapitalLongitude"": 69.183333,
        ""CountryCode"": ""AF"",
        ""ContinentName"": ""Asia""
    }, {
        ""CountryName"": ""Albania"",
        ""CapitalName"": ""Tirana"",
        ""CapitalLatitude"": 41.31666666666667,
        ""CapitalLongitude"": 19.816667,
        ""CountryCode"": ""AL"",
        ""ContinentName"": ""Europe""
    }, {
        ""CountryName"": ""Algeria"",
        ""CapitalName"": ""Algiers"",
        ""CapitalLatitude"": 36.75,
        ""CapitalLongitude"": 3.050000,
        ""CountryCode"": ""DZ"",
        ""ContinentName"": ""Africa""
    }, {
        ""CountryName"": ""American Samoa"",
        ""CapitalName"": ""Pago Pago"",
        ""CapitalLatitude"": -14.266666666666667,
        ""CapitalLongitude"": -170.700000,
        ""CountryCode"": ""AS"",
        ""ContinentName"": ""Australia""
    }, {
        ""CountryName"": ""Andorra"",
        ""CapitalName"": ""Andorra la Vella"",
        ""CapitalLatitude"": 42.5,
        ""CapitalLongitude"": 1.516667,
        ""CountryCode"": ""AD"",
        ""ContinentName"": ""Europe""
    }, {
        ""CountryName"": ""Angola"",
        ""CapitalName"": ""Luanda"",
        ""CapitalLatitude"": -8.833333333333334,
        ""CapitalLongitude"": 13.216667,
        ""CountryCode"": ""AO"",
        ""ContinentName"": ""Africa""
    }, {
        ""CountryName"": ""Anguilla"",
        ""CapitalName"": ""The Valley"",
        ""CapitalLatitude"": 18.216666666666665,
        ""CapitalLongitude"": -63.050000,
        ""CountryCode"": ""AI"",
        ""ContinentName"": ""North America""
    },  {
        ""CountryName"": ""Chile"",
        ""CapitalName"": ""Santiago"",
        ""CapitalLatitude"": -33.45,
        ""CapitalLongitude"": -70.666667,
        ""CountryCode"": ""CL"",
        ""ContinentName"": ""South America""
    }, {
        ""CountryName"": ""China"",
        ""CapitalName"": ""Beijing"",
        ""CapitalLatitude"": 39.916666666666664,
        ""CapitalLongitude"": 116.383333,
        ""CountryCode"": ""CN"",
        ""ContinentName"": ""Asia""
    }, {
        ""CountryName"": ""Christmas Island"",
        ""CapitalName"": ""The Settlement"",
        ""CapitalLatitude"": -10.416666666666666,
        ""CapitalLongitude"": 105.716667,
        ""CountryCode"": ""CX"",
        ""ContinentName"": ""Australia""
    }, {
        ""CountryName"": ""Cocos Islands"",
        ""CapitalName"": ""West Island"",
        ""CapitalLatitude"": -12.166666666666666,
        ""CapitalLongitude"": 96.833333,
        ""CountryCode"": ""CC"",
        ""ContinentName"": ""Australia""
    }, {
        ""CountryName"": ""Colombia"",
        ""CapitalName"": ""Bogota"",
        ""CapitalLatitude"": 4.6,
        ""CapitalLongitude"": -74.083333,
        ""CountryCode"": ""CO"",
        ""ContinentName"": ""South America""
    }, {
        ""CountryName"": ""Comoros"",
        ""CapitalName"": ""Moroni"",
        ""CapitalLatitude"": -11.7,
        ""CapitalLongitude"": 43.233333,
        ""CountryCode"": ""KM"",
        ""ContinentName"": ""Africa""
    }, {
        ""CountryName"": ""Democratic Republic of the Congo"",
        ""CapitalName"": ""Kinshasa"",
        ""CapitalLatitude"": -4.316666666666666,
        ""CapitalLongitude"": 15.300000,
        ""CountryCode"": ""CD"",
        ""ContinentName"": ""Africa""
    }, {
        ""CountryName"": ""Republic of Congo"",
        ""CapitalName"": ""Brazzaville"",
        ""CapitalLatitude"": -4.25,
        ""CapitalLongitude"": 15.283333,
        ""CountryCode"": ""CG"",
        ""ContinentName"": ""Africa""
    }, {
        ""CountryName"": ""Cook Islands"",
        ""CapitalName"": ""Avarua"",
        ""CapitalLatitude"": -21.2,
        ""CapitalLongitude"": -159.766667,
        ""CountryCode"": ""CK"",
        ""ContinentName"": ""Australia""
    }, {
        ""CountryName"": ""Costa Rica"",
        ""CapitalName"": ""San Jose"",
        ""CapitalLatitude"": 9.933333333333334,
        ""CapitalLongitude"": -84.083333,
        ""CountryCode"": ""CR"",
        ""ContinentName"": ""Central America""
    }, {
        ""CountryName"": ""Croatia"",
        ""CapitalName"": ""Zagreb"",
        ""CapitalLatitude"": 45.8,
        ""CapitalLongitude"": 16.00,
        ""CountryCode"": ""HR"",
        ""ContinentName"": ""Europe""
    },  {
        ""CountryName"": ""Guam"",
        ""CapitalName"": ""Hagatna"",
        ""CapitalLatitude"": 13.466666666666667,
        ""CapitalLongitude"": 144.733333,
        ""CountryCode"": ""GU"",
        ""ContinentName"": ""Australia""
    }, {
        ""CountryName"": ""Guatemala"",
        ""CapitalName"": ""Guatemala City"",
        ""CapitalLatitude"": 14.616666666666667,
        ""CapitalLongitude"": -90.516667,
        ""CountryCode"": ""GT"",
        ""ContinentName"": ""Central America""
    }, {
        ""CountryName"": ""Guernsey"",
        ""CapitalName"": ""Saint Peter Port"",
        ""CapitalLatitude"": 49.45,
        ""CapitalLongitude"": -2.533333,
        ""CountryCode"": ""GG"",
        ""ContinentName"": ""Europe""
    }, {
        ""CountryName"": ""Guinea"",
        ""CapitalName"": ""Conakry"",
        ""CapitalLatitude"": 9.5,
        ""CapitalLongitude"": -13.700000,
        ""CountryCode"": ""GN"",
        ""ContinentName"": ""Africa""
    }, {
        ""CountryName"": ""Guinea-Bissau"",
        ""CapitalName"": ""Bissau"",
        ""CapitalLatitude"": 11.85,
        ""CapitalLongitude"": -15.583333,
        ""CountryCode"": ""GW"",
        ""ContinentName"": ""Africa""
    }, {
        ""CountryName"": ""Guyana"",
        ""CapitalName"": ""Georgetown"",
        ""CapitalLatitude"": 6.8,
        ""CapitalLongitude"": -58.150000,
        ""CountryCode"": ""GY"",
        ""ContinentName"": ""South America""
    }, {
        ""CountryName"": ""Haiti"",
        ""CapitalName"": ""Port-au-Prince"",
        ""CapitalLatitude"": 18.533333333333335,
        ""CapitalLongitude"": -72.333333,
        ""CountryCode"": ""HT"",
        ""ContinentName"": ""North America""
    }, {
        ""CountryName"": ""Vatican City"",
        ""CapitalName"": ""Vatican City"",
        ""CapitalLatitude"": 41.9,
        ""CapitalLongitude"": 12.450000,
        ""CountryCode"": ""VA"",
        ""ContinentName"": ""Europe""
    }, {
        ""CountryName"": ""Honduras"",
        ""CapitalName"": ""Tegucigalpa"",
        ""CapitalLatitude"": 14.1,
        ""CapitalLongitude"": -87.216667,
        ""CountryCode"": ""HN"",
        ""ContinentName"": ""Central America""
    }, {
        ""CountryName"": ""Hungary"",
        ""CapitalName"": ""Budapest"",
        ""CapitalLatitude"": 47.5,
        ""CapitalLongitude"": 19.083333,
        ""CountryCode"": ""HU"",
        ""ContinentName"": ""Europe""
    }, {
        ""CountryName"": ""Iceland"",
        ""CapitalName"": ""Reykjavik"",
        ""CapitalLatitude"": 64.15,
        ""CapitalLongitude"": -21.950000,
        ""CountryCode"": ""IS"",
        ""ContinentName"": ""Europe""
    }, {
        ""CountryName"": ""India"",
        ""CapitalName"": ""New Delhi"",
        ""CapitalLatitude"": 28.6,
        ""CapitalLongitude"": 77.200000,
        ""CountryCode"": ""IN"",
        ""ContinentName"": ""Asia""
    }, {
        ""CountryName"": ""Indonesia"",
        ""CapitalName"": ""Jakarta"",
        ""CapitalLatitude"": -6.166666666666667,
        ""CapitalLongitude"": 106.816667,
        ""CountryCode"": ""ID"",
        ""ContinentName"": ""Asia""
    }, {
        ""CountryName"": ""Iran"",
        ""CapitalName"": ""Tehran"",
        ""CapitalLatitude"": 35.7,
        ""CapitalLongitude"": 51.416667,
        ""CountryCode"": ""IR"",
        ""ContinentName"": ""Asia""
    }, {
        ""CountryName"": ""Iraq"",
        ""CapitalName"": ""Baghdad"",
        ""CapitalLatitude"": 33.333333333333336,
        ""CapitalLongitude"": 44.400000,
        ""CountryCode"": ""IQ"",
        ""ContinentName"": ""Asia""
    }, {
        ""CountryName"": ""Ireland"",
        ""CapitalName"": ""Dublin"",
        ""CapitalLatitude"": 53.31666666666667,
        ""CapitalLongitude"": -6.233333,
        ""CountryCode"": ""IE"",
        ""ContinentName"": ""Europe""
    }, {
        ""CountryName"": ""Isle of Man"",
        ""CapitalName"": ""Douglas"",
        ""CapitalLatitude"": 54.15,
        ""CapitalLongitude"": -4.483333,
        ""CountryCode"": ""IM"",
        ""ContinentName"": ""Europe""
    }, {
        ""CountryName"": ""Israel"",
        ""CapitalName"": ""Jerusalem"",
        ""CapitalLatitude"": 31.766666666666666,
        ""CapitalLongitude"": 35.233333,
        ""CountryCode"": ""IL"",
        ""ContinentName"": ""Asia""
    }, {
        ""CountryName"": ""Italy"",
        ""CapitalName"": ""Rome"",
        ""CapitalLatitude"": 41.9,
        ""CapitalLongitude"": 12.483333,
        ""CountryCode"": ""IT"",
        ""ContinentName"": ""Europe""
    }, {
        ""CountryName"": ""Jamaica"",
        ""CapitalName"": ""Kingston"",
        ""CapitalLatitude"": 18,
        ""CapitalLongitude"": -76.800000,
        ""CountryCode"": ""JM"",
        ""ContinentName"": ""North America""
    }, {
        ""CountryName"": ""Japan"",
        ""CapitalName"": ""Tokyo"",
        ""CapitalLatitude"": 35.68333333333333,
        ""CapitalLongitude"": 139.750000,
        ""CountryCode"": ""JP"",
        ""ContinentName"": ""Asia""
    }, {
        ""CountryName"": ""Jersey"",
        ""CapitalName"": ""Saint Helier"",
        ""CapitalLatitude"": 49.18333333333333,
        ""CapitalLongitude"": -2.100000,
        ""CountryCode"": ""JE"",
        ""ContinentName"": ""Europe""
    }, {
        ""CountryName"": ""Jordan"",
        ""CapitalName"": ""Amman"",
        ""CapitalLatitude"": 31.95,
        ""CapitalLongitude"": 35.933333,
        ""CountryCode"": ""JO"",
        ""ContinentName"": ""Asia""
    }, {
        ""CountryName"": ""Kazakhstan"",
        ""CapitalName"": ""Astana"",
        ""CapitalLatitude"": 51.166666666666664,
        ""CapitalLongitude"": 71.416667,
        ""CountryCode"": ""KZ"",
        ""ContinentName"": ""Asia""
    }, {
        ""CountryName"": ""Kenya"",
        ""CapitalName"": ""Nairobi"",
        ""CapitalLatitude"": -1.2833333333333332,
        ""CapitalLongitude"": 36.816667,
        ""CountryCode"": ""KE"",
        ""ContinentName"": ""Africa""
    }, {
        ""CountryName"": ""Kiribati"",
        ""CapitalName"": ""Tarawa"",
        ""CapitalLatitude"": -0.8833333333333333,
        ""CapitalLongitude"": 169.533333,
        ""CountryCode"": ""KI"",
        ""ContinentName"": ""Australia""
    }, {
        ""CountryName"": ""North Korea"",
        ""CapitalName"": ""Pyongyang"",
        ""CapitalLatitude"": 39.016666666666666,
        ""CapitalLongitude"": 125.750000,
        ""CountryCode"": ""KP"",
        ""ContinentName"": ""Asia""
    }, {
        ""CountryName"": ""South Korea"",
        ""CapitalName"": ""Seoul"",
        ""CapitalLatitude"": 37.55,
        ""CapitalLongitude"": 126.983333,
        ""CountryCode"": ""KR"",
        ""ContinentName"": ""Asia""
    }, {
        ""CountryName"": ""Kosovo"",
        ""CapitalName"": ""Pristina"",
        ""CapitalLatitude"": 42.666666666666664,
        ""CapitalLongitude"": 21.166667,
        ""CountryCode"": ""KO"",
        ""ContinentName"": ""Europe""
    }, {
        ""CountryName"": ""Kuwait"",
        ""CapitalName"": ""Kuwait City"",
        ""CapitalLatitude"": 29.366666666666667,
        ""CapitalLongitude"": 47.966667,
        ""CountryCode"": ""KW"",
        ""ContinentName"": ""Asia""
    }, {
        ""CountryName"": ""Kyrgyzstan"",
        ""CapitalName"": ""Bishkek"",
        ""CapitalLatitude"": 42.86666666666667,
        ""CapitalLongitude"": 74.600000,
        ""CountryCode"": ""KG"",
        ""ContinentName"": ""Asia""
    }, {
        ""CountryName"": ""Laos"",
        ""CapitalName"": ""Vientiane"",
        ""CapitalLatitude"": 17.966666666666665,
        ""CapitalLongitude"": 102.600000,
        ""CountryCode"": ""LA"",
        ""ContinentName"": ""Asia""
    }, {
        ""CountryName"": ""Latvia"",
        ""CapitalName"": ""Riga"",
        ""CapitalLatitude"": 56.95,
        ""CapitalLongitude"": 24.100000,
        ""CountryCode"": ""LV"",
        ""ContinentName"": ""Europe""
    }, {
        ""CountryName"": ""Lebanon"",
        ""CapitalName"": ""Beirut"",
        ""CapitalLatitude"": 33.86666666666667,
        ""CapitalLongitude"": 35.500000,
        ""CountryCode"": ""LB"",
        ""ContinentName"": ""Asia""
    }, {
        ""CountryName"": ""Lesotho"",
        ""CapitalName"": ""Maseru"",
        ""CapitalLatitude"": -29.316666666666666,
        ""CapitalLongitude"": 27.483333,
        ""CountryCode"": ""LS"",
        ""ContinentName"": ""Africa""
    }, {
        ""CountryName"": ""Liberia"",
        ""CapitalName"": ""Monrovia"",
        ""CapitalLatitude"": 6.3,
        ""CapitalLongitude"": -10.800000,
        ""CountryCode"": ""LR"",
        ""ContinentName"": ""Africa""
    }, {
        ""CountryName"": ""Libya"",
        ""CapitalName"": ""Tripoli"",
        ""CapitalLatitude"": 32.88333333333333,
        ""CapitalLongitude"": 13.166667,
        ""CountryCode"": ""LY"",
        ""ContinentName"": ""Africa""
    }, {
        ""CountryName"": ""Liechtenstein"",
        ""CapitalName"": ""Vaduz"",
        ""CapitalLatitude"": 47.13333333333333,
        ""CapitalLongitude"": 9.516667,
        ""CountryCode"": ""LI"",
        ""ContinentName"": ""Europe""
    }, {
        ""CountryName"": ""Lithuania"",
        ""CapitalName"": ""Vilnius"",
        ""CapitalLatitude"": 54.68333333333333,
        ""CapitalLongitude"": 25.316667,
        ""CountryCode"": ""LT"",
        ""ContinentName"": ""Europe""
    }, {
        ""CountryName"": ""Luxembourg"",
        ""CapitalName"": ""Luxembourg"",
        ""CapitalLatitude"": 49.6,
        ""CapitalLongitude"": 6.116667,
        ""CountryCode"": ""LU"",
        ""ContinentName"": ""Europe""
    }, {
        ""CountryName"": ""Macedonia"",
        ""CapitalName"": ""Skopje"",
        ""CapitalLatitude"": 42,
        ""CapitalLongitude"": 21.433333,
        ""CountryCode"": ""MK"",
        ""ContinentName"": ""Europe""
    }, {
        ""CountryName"": ""Madagascar"",
        ""CapitalName"": ""Antananarivo"",
        ""CapitalLatitude"": -18.916666666666668,
        ""CapitalLongitude"": 47.516667,
        ""CountryCode"": ""MG"",
        ""ContinentName"": ""Africa""
    }, {
        ""CountryName"": ""Malawi"",
        ""CapitalName"": ""Lilongwe"",
        ""CapitalLatitude"": -13.966666666666667,
        ""CapitalLongitude"": 33.783333,
        ""CountryCode"": ""MW"",
        ""ContinentName"": ""Africa""
    }, {
        ""CountryName"": ""Malaysia"",
        ""CapitalName"": ""Kuala Lumpur"",
        ""CapitalLatitude"": 3.1666666666666665,
        ""CapitalLongitude"": 101.700000,
        ""CountryCode"": ""MY"",
        ""ContinentName"": ""Asia""
    }, {
        ""CountryName"": ""Maldives"",
        ""CapitalName"": ""Male"",
        ""CapitalLatitude"": 4.166666666666667,
        ""CapitalLongitude"": 73.500000,
        ""CountryCode"": ""MV"",
        ""ContinentName"": ""Asia""
    }, {
        ""CountryName"": ""Mali"",
        ""CapitalName"": ""Bamako"",
        ""CapitalLatitude"": 12.65,
        ""CapitalLongitude"": -8.000000,
        ""CountryCode"": ""ML"",
        ""ContinentName"": ""Africa""
    }, {
        ""CountryName"": ""Malta"",
        ""CapitalName"": ""Valletta"",
        ""CapitalLatitude"": 35.88333333333333,
        ""CapitalLongitude"": 14.500000,
        ""CountryCode"": ""MT"",
        ""ContinentName"": ""Europe""
    }, {
        ""CountryName"": ""Marshall Islands"",
        ""CapitalName"": ""Majuro"",
        ""CapitalLatitude"": 7.1,
        ""CapitalLongitude"": 171.383333,
        ""CountryCode"": ""MH"",
        ""ContinentName"": ""Australia""
    }, {
        ""CountryName"": ""Mauritania"",
        ""CapitalName"": ""Nouakchott"",
        ""CapitalLatitude"": 18.066666666666666,
        ""CapitalLongitude"": -15.966667,
        ""CountryCode"": ""MR"",
        ""ContinentName"": ""Africa""
    }, {
        ""CountryName"": ""Mauritius"",
        ""CapitalName"": ""Port Louis"",
        ""CapitalLatitude"": -20.15,
        ""CapitalLongitude"": 57.483333,
        ""CountryCode"": ""MU"",
        ""ContinentName"": ""Africa""
    }, {
        ""CountryName"": ""Mexico"",
        ""CapitalName"": ""Mexico City"",
        ""CapitalLatitude"": 19.433333333333334,
        ""CapitalLongitude"": -99.133333,
        ""CountryCode"": ""MX"",
        ""ContinentName"": ""Central America""
    }, {
        ""CountryName"": ""Federated States of Micronesia"",
        ""CapitalName"": ""Palikir"",
        ""CapitalLatitude"": 6.916666666666667,
        ""CapitalLongitude"": 158.150000,
        ""CountryCode"": ""FM"",
        ""ContinentName"": ""Australia""
    }, {
        ""CountryName"": ""Moldova"",
        ""CapitalName"": ""Chisinau"",
        ""CapitalLatitude"": 47,
        ""CapitalLongitude"": 28.850000,
        ""CountryCode"": ""MD"",
        ""ContinentName"": ""Europe""
    }, {
        ""CountryName"": ""Monaco"",
        ""CapitalName"": ""Monaco"",
        ""CapitalLatitude"": 43.733333333333334,
        ""CapitalLongitude"": 7.416667,
        ""CountryCode"": ""MC"",
        ""ContinentName"": ""Europe""
    }, {
        ""CountryName"": ""Mongolia"",
        ""CapitalName"": ""Ulaanbaatar"",
        ""CapitalLatitude"": 47.916666666666664,
        ""CapitalLongitude"": 106.916667,
        ""CountryCode"": ""MN"",
        ""ContinentName"": ""Asia""
    }, {
        ""CountryName"": ""Montenegro"",
        ""CapitalName"": ""Podgorica"",
        ""CapitalLatitude"": 42.43333333333333,
        ""CapitalLongitude"": 19.266667,
        ""CountryCode"": ""ME"",
        ""ContinentName"": ""Europe""
    }, {
        ""CountryName"": ""Montserrat"",
        ""CapitalName"": ""Plymouth"",
        ""CapitalLatitude"": 16.7,
        ""CapitalLongitude"": -62.216667,
        ""CountryCode"": ""MS"",
        ""ContinentName"": ""North America""
    }, {
        ""CountryName"": ""Morocco"",
        ""CapitalName"": ""Rabat"",
        ""CapitalLatitude"": 34.016666666666666,
        ""CapitalLongitude"": -6.816667,
        ""CountryCode"": ""MA"",
        ""ContinentName"": ""Africa""
    }, {
        ""CountryName"": ""Mozambique"",
        ""CapitalName"": ""Maputo"",
        ""CapitalLatitude"": -25.95,
        ""CapitalLongitude"": 32.583333,
        ""CountryCode"": ""MZ"",
        ""ContinentName"": ""Africa""
    }, {
        ""CountryName"": ""Namibia"",
        ""CapitalName"": ""Windhoek"",
        ""CapitalLatitude"": -22.566666666666666,
        ""CapitalLongitude"": 17.083333,
        ""CountryCode"": ""NA"",
        ""ContinentName"": ""Africa""
    }, {
        ""CountryName"": ""Nepal"",
        ""CapitalName"": ""Kathmandu"",
        ""CapitalLatitude"": 27.716666666666665,
        ""CapitalLongitude"": 85.316667,
        ""CountryCode"": ""NP"",
        ""ContinentName"": ""Asia""
    }, {
        ""CountryName"": ""Netherlands"",
        ""CapitalName"": ""Amsterdam"",
        ""CapitalLatitude"": 52.35,
        ""CapitalLongitude"": 4.916667,
        ""CountryCode"": ""NL"",
        ""ContinentName"": ""Europe""
    }, {
        ""CountryName"": ""New Caledonia"",
        ""CapitalName"": ""Noumea"",
        ""CapitalLatitude"": -22.266666666666666,
        ""CapitalLongitude"": 166.450000,
        ""CountryCode"": ""NC"",
        ""ContinentName"": ""Australia""
    }, {
        ""CountryName"": ""New Zealand"",
        ""CapitalName"": ""Wellington"",
        ""CapitalLatitude"": -41.3,
        ""CapitalLongitude"": 174.783333,
        ""CountryCode"": ""NZ"",
        ""ContinentName"": ""Australia""
    }, {
        ""CountryName"": ""Nicaragua"",
        ""CapitalName"": ""Managua"",
        ""CapitalLatitude"": 12.133333333333333,
        ""CapitalLongitude"": -86.250000,
        ""CountryCode"": ""NI"",
        ""ContinentName"": ""Central America""
    }, {
        ""CountryName"": ""Niger"",
        ""CapitalName"": ""Niamey"",
        ""CapitalLatitude"": 13.516666666666667,
        ""CapitalLongitude"": 2.116667,
        ""CountryCode"": ""NE"",
        ""ContinentName"": ""Africa""
    }, {
        ""CountryName"": ""Nigeria"",
        ""CapitalName"": ""Abuja"",
        ""CapitalLatitude"": 9.083333333333334,
        ""CapitalLongitude"": 7.533333,
        ""CountryCode"": ""NG"",
        ""ContinentName"": ""Africa""
    }, {
        ""CountryName"": ""Niue"",
        ""CapitalName"": ""Alofi"",
        ""CapitalLatitude"": -19.016666666666666,
        ""CapitalLongitude"": -169.916667,
        ""CountryCode"": ""NU"",
        ""ContinentName"": ""Australia""
    }, {
        ""CountryName"": ""Norfolk Island"",
        ""CapitalName"": ""Kingston"",
        ""CapitalLatitude"": -29.05,
        ""CapitalLongitude"": 167.966667,
        ""CountryCode"": ""NF"",
        ""ContinentName"": ""Australia""
    }, {
        ""CountryName"": ""Northern Mariana Islands"",
        ""CapitalName"": ""Saipan"",
        ""CapitalLatitude"": 15.2,
        ""CapitalLongitude"": 145.750000,
        ""CountryCode"": ""MP"",
        ""ContinentName"": ""Australia""
    }, {
        ""CountryName"": ""Norway"",
        ""CapitalName"": ""Oslo"",
        ""CapitalLatitude"": 59.916666666666664,
        ""CapitalLongitude"": 10.750000,
        ""CountryCode"": ""NO"",
        ""ContinentName"": ""Europe""
    }, {
        ""CountryName"": ""Oman"",
        ""CapitalName"": ""Muscat"",
        ""CapitalLatitude"": 23.616666666666667,
        ""CapitalLongitude"": 58.583333,
        ""CountryCode"": ""OM"",
        ""ContinentName"": ""Asia""
    }, {
        ""CountryName"": ""Pakistan"",
        ""CapitalName"": ""Islamabad"",
        ""CapitalLatitude"": 33.68333333333333,
        ""CapitalLongitude"": 73.050000,
        ""CountryCode"": ""PK"",
        ""ContinentName"": ""Asia""
    }, {
        ""CountryName"": ""Palau"",
        ""CapitalName"": ""Melekeok"",
        ""CapitalLatitude"": 7.483333333333333,
        ""CapitalLongitude"": 134.633333,
        ""CountryCode"": ""PW"",
        ""ContinentName"": ""Australia""
    }, {
        ""CountryName"": ""Panama"",
        ""CapitalName"": ""Panama City"",
        ""CapitalLatitude"": 8.966666666666667,
        ""CapitalLongitude"": -79.533333,
        ""CountryCode"": ""PA"",
        ""ContinentName"": ""Central America""
    }, {
        ""CountryName"": ""Papua New Guinea"",
        ""CapitalName"": ""Port Moresby"",
        ""CapitalLatitude"": -9.45,
        ""CapitalLongitude"": 147.183333,
        ""CountryCode"": ""PG"",
        ""ContinentName"": ""Australia""
    }, {
        ""CountryName"": ""Paraguay"",
        ""CapitalName"": ""Asuncion"",
        ""CapitalLatitude"": -25.266666666666666,
        ""CapitalLongitude"": -57.666667,
        ""CountryCode"": ""PY"",
        ""ContinentName"": ""South America""
    }, {
        ""CountryName"": ""Peru"",
        ""CapitalName"": ""Lima"",
        ""CapitalLatitude"": -12.05,
        ""CapitalLongitude"": -77.050000,
        ""CountryCode"": ""PE"",
        ""ContinentName"": ""South America""
    }, {
        ""CountryName"": ""Philippines"",
        ""CapitalName"": ""Manila"",
        ""CapitalLatitude"": 14.6,
        ""CapitalLongitude"": 120.966667,
        ""CountryCode"": ""PH"",
        ""ContinentName"": ""Asia""
    }, {
        ""CountryName"": ""Pitcairn Islands"",
        ""CapitalName"": ""Adamstown"",
        ""CapitalLatitude"": -25.066666666666666,
        ""CapitalLongitude"": -130.083333,
        ""CountryCode"": ""PN"",
        ""ContinentName"": ""Australia""
    }, {
        ""CountryName"": ""Poland"",
        ""CapitalName"": ""Warsaw"",
        ""CapitalLatitude"": 52.25,
        ""CapitalLongitude"": 21.000000,
        ""CountryCode"": ""PL"",
        ""ContinentName"": ""Europe""
    }, {
        ""CountryName"": ""Portugal"",
        ""CapitalName"": ""Lisbon"",
        ""CapitalLatitude"": 38.71666666666667,
        ""CapitalLongitude"": -9.133333,
        ""CountryCode"": ""PT"",
        ""ContinentName"": ""Europe""
    }, {
        ""CountryName"": ""Puerto Rico"",
        ""CapitalName"": ""San Juan"",
        ""CapitalLatitude"": 18.466666666666665,
        ""CapitalLongitude"": -66.116667,
        ""CountryCode"": ""PR"",
        ""ContinentName"": ""North America""
    }, {
        ""CountryName"": ""Qatar"",
        ""CapitalName"": ""Doha"",
        ""CapitalLatitude"": 25.283333333333335,
        ""CapitalLongitude"": 51.533333,
        ""CountryCode"": ""QA"",
        ""ContinentName"": ""Asia""
    }, {
        ""CountryName"": ""Romania"",
        ""CapitalName"": ""Bucharest"",
        ""CapitalLatitude"": 44.43333333333333,
        ""CapitalLongitude"": 26.100000,
        ""CountryCode"": ""RO"",
        ""ContinentName"": ""Europe""
    }, {
        ""CountryName"": ""Russia"",
        ""CapitalName"": ""Moscow"",
        ""CapitalLatitude"": 55.75,
        ""CapitalLongitude"": 37.600000,
        ""CountryCode"": ""RU"",
        ""ContinentName"": ""Europe""
    }, {
        ""CountryName"": ""Rwanda"",
        ""CapitalName"": ""Kigali"",
        ""CapitalLatitude"": -1.95,
        ""CapitalLongitude"": 30.050000,
        ""CountryCode"": ""RW"",
        ""ContinentName"": ""Africa""
    }, {
        ""CountryName"": ""Saint Barthelemy"",
        ""CapitalName"": ""Gustavia"",
        ""CapitalLatitude"": 17.883333333333333,
        ""CapitalLongitude"": -62.850000,
        ""CountryCode"": ""BL"",
        ""ContinentName"": ""North America""
    }, {
        ""CountryName"": ""Saint Helena"",
        ""CapitalName"": ""Jamestown"",
        ""CapitalLatitude"": -15.933333333333334,
        ""CapitalLongitude"": -5.716667,
        ""CountryCode"": ""SH"",
        ""ContinentName"": ""Africa""
    }, {
        ""CountryName"": ""Saint Kitts and Nevis"",
        ""CapitalName"": ""Basseterre"",
        ""CapitalLatitude"": 17.3,
        ""CapitalLongitude"": -62.716667,
        ""CountryCode"": ""KN"",
        ""ContinentName"": ""North America""
    }, {
        ""CountryName"": ""Saint Lucia"",
        ""CapitalName"": ""Castries"",
        ""CapitalLatitude"": 14,
        ""CapitalLongitude"": -61.000000,
        ""CountryCode"": ""LC"",
        ""ContinentName"": ""North America""
    }, {
        ""CountryName"": ""Saint Pierre and Miquelon"",
        ""CapitalName"": ""Saint-Pierre"",
        ""CapitalLatitude"": 46.766666666666666,
        ""CapitalLongitude"": -56.183333,
        ""CountryCode"": ""PM"",
        ""ContinentName"": ""Central America""
    }, {
        ""CountryName"": ""Saint Vincent and the Grenadines"",
        ""CapitalName"": ""Kingstown"",
        ""CapitalLatitude"": 13.133333333333333,
        ""CapitalLongitude"": -61.216667,
        ""CountryCode"": ""VC"",
        ""ContinentName"": ""Central America""
    }, {
        ""CountryName"": ""Samoa"",
        ""CapitalName"": ""Apia"",
        ""CapitalLatitude"": -13.816666666666666,
        ""CapitalLongitude"": -171.766667,
        ""CountryCode"": ""WS"",
        ""ContinentName"": ""Australia""
    }, {
        ""CountryName"": ""San Marino"",
        ""CapitalName"": ""San Marino"",
        ""CapitalLatitude"": 43.93333333333333,
        ""CapitalLongitude"": 12.416667,
        ""CountryCode"": ""SM"",
        ""ContinentName"": ""Europe""
    }, {
        ""CountryName"": ""Sao Tome and Principe"",
        ""CapitalName"": ""Sao Tome"",
        ""CapitalLatitude"": 0.3333333333333333,
        ""CapitalLongitude"": 6.733333,
        ""CountryCode"": ""ST"",
        ""ContinentName"": ""Africa""
    }, {
        ""CountryName"": ""Saudi Arabia"",
        ""CapitalName"": ""Riyadh"",
        ""CapitalLatitude"": 24.65,
        ""CapitalLongitude"": 46.700000,
        ""CountryCode"": ""SA"",
        ""ContinentName"": ""Asia""
    }, {
        ""CountryName"": ""Senegal"",
        ""CapitalName"": ""Dakar"",
        ""CapitalLatitude"": 14.733333333333333,
        ""CapitalLongitude"": -17.633333,
        ""CountryCode"": ""SN"",
        ""ContinentName"": ""Africa""
    }, {
        ""CountryName"": ""Serbia"",
        ""CapitalName"": ""Belgrade"",
        ""CapitalLatitude"": 44.833333333333336,
        ""CapitalLongitude"": 20.500000,
        ""CountryCode"": ""RS"",
        ""ContinentName"": ""Europe""
    }, {
        ""CountryName"": ""Seychelles"",
        ""CapitalName"": ""Victoria"",
        ""CapitalLatitude"": -4.616666666666667,
        ""CapitalLongitude"": 55.450000,
        ""CountryCode"": ""SC"",
        ""ContinentName"": ""Africa""
    }, {
        ""CountryName"": ""Sierra Leone"",
        ""CapitalName"": ""Freetown"",
        ""CapitalLatitude"": 8.483333333333333,
        ""CapitalLongitude"": -13.233333,
        ""CountryCode"": ""SL"",
        ""ContinentName"": ""Africa""
    }, {
        ""CountryName"": ""Singapore"",
        ""CapitalName"": ""Singapore"",
        ""CapitalLatitude"": 1.2833333333333332,
        ""CapitalLongitude"": 103.850000,
        ""CountryCode"": ""SG"",
        ""ContinentName"": ""Asia""
    }, {
        ""CountryName"": ""Sint Maarten"",
        ""CapitalName"": ""Philipsburg"",
        ""CapitalLatitude"": 18.016666666666666,
        ""CapitalLongitude"": -63.033333,
        ""CountryCode"": ""SX"",
        ""ContinentName"": ""North America""
    }, {
        ""CountryName"": ""Slovakia"",
        ""CapitalName"": ""Bratislava"",
        ""CapitalLatitude"": 48.15,
        ""CapitalLongitude"": 17.116667,
        ""CountryCode"": ""SK"",
        ""ContinentName"": ""Europe""
    }, {
        ""CountryName"": ""Slovenia"",
        ""CapitalName"": ""Ljubljana"",
        ""CapitalLatitude"": 46.05,
        ""CapitalLongitude"": 14.516667,
        ""CountryCode"": ""SI"",
        ""ContinentName"": ""Europe""
    }, {
        ""CountryName"": ""Solomon Islands"",
        ""CapitalName"": ""Honiara"",
        ""CapitalLatitude"": -9.433333333333334,
        ""CapitalLongitude"": 159.950000,
        ""CountryCode"": ""SB"",
        ""ContinentName"": ""Australia""
    }, {
        ""CountryName"": ""Somalia"",
        ""CapitalName"": ""Mogadishu"",
        ""CapitalLatitude"": 2.066666666666667,
        ""CapitalLongitude"": 45.333333,
        ""CountryCode"": ""SO"",
        ""ContinentName"": ""Africa""
    }, {
        ""CountryName"": ""South Africa"",
        ""CapitalName"": ""Pretoria"",
        ""CapitalLatitude"": -25.7,
        ""CapitalLongitude"": 28.216667,
        ""CountryCode"": ""ZA"",
        ""ContinentName"": ""Africa""
    }, {
        ""CountryName"": ""South Sudan"",
        ""CapitalName"": ""Juba"",
        ""CapitalLatitude"": 4.85,
        ""CapitalLongitude"": 31.616667,
        ""CountryCode"": ""SS"",
        ""ContinentName"": ""Africa""
    }, {
        ""CountryName"": ""Spain"",
        ""CapitalName"": ""Madrid"",
        ""CapitalLatitude"": 40.4,
        ""CapitalLongitude"": -3.683333,
        ""CountryCode"": ""ES"",
        ""ContinentName"": ""Europe""
    }, {
        ""CountryName"": ""Sri Lanka"",
        ""CapitalName"": ""Colombo"",
        ""CapitalLatitude"": 6.916666666666667,
        ""CapitalLongitude"": 79.833333,
        ""CountryCode"": ""LK"",
        ""ContinentName"": ""Asia""
    }, {
        ""CountryName"": ""Sudan"",
        ""CapitalName"": ""Khartoum"",
        ""CapitalLatitude"": 15.6,
        ""CapitalLongitude"": 32.533333,
        ""CountryCode"": ""SD"",
        ""ContinentName"": ""Africa""
    }, {
        ""CountryName"": ""Suriname"",
        ""CapitalName"": ""Paramaribo"",
        ""CapitalLatitude"": 5.833333333333333,
        ""CapitalLongitude"": -55.166667,
        ""CountryCode"": ""SR"",
        ""ContinentName"": ""South America""
    }, {
        ""CountryName"": ""Svalbard"",
        ""CapitalName"": ""Longyearbyen"",
        ""CapitalLatitude"": 78.21666666666667,
        ""CapitalLongitude"": 15.633333,
        ""CountryCode"": ""SJ"",
        ""ContinentName"": ""Europe""
    }, {
        ""CountryName"": ""Swaziland"",
        ""CapitalName"": ""Mbabane"",
        ""CapitalLatitude"": -26.316666666666666,
        ""CapitalLongitude"": 31.133333,
        ""CountryCode"": ""SZ"",
        ""ContinentName"": ""Africa""
    }, {
        ""CountryName"": ""Sweden"",
        ""CapitalName"": ""Stockholm"",
        ""CapitalLatitude"": 59.333333333333336,
        ""CapitalLongitude"": 18.050000,
        ""CountryCode"": ""SE"",
        ""ContinentName"": ""Europe""
    }, {
        ""CountryName"": ""Switzerland"",
        ""CapitalName"": ""Bern"",
        ""CapitalLatitude"": 46.916666666666664,
        ""CapitalLongitude"": 7.466667,
        ""CountryCode"": ""CH"",
        ""ContinentName"": ""Europe""
    }, {
        ""CountryName"": ""Syria"",
        ""CapitalName"": ""Damascus"",
        ""CapitalLatitude"": 33.5,
        ""CapitalLongitude"": 36.300000,
        ""CountryCode"": ""SY"",
        ""ContinentName"": ""Asia""
    }, {
        ""CountryName"": ""Taiwan"",
        ""CapitalName"": ""Taipei"",
        ""CapitalLatitude"": 25.033333333333335,
        ""CapitalLongitude"": 121.516667,
        ""CountryCode"": ""TW"",
        ""ContinentName"": ""Asia""
    }, {
        ""CountryName"": ""Tajikistan"",
        ""CapitalName"": ""Dushanbe"",
        ""CapitalLatitude"": 38.55,
        ""CapitalLongitude"": 68.766667,
        ""CountryCode"": ""TJ"",
        ""ContinentName"": ""Asia""
    }, {
        ""CountryName"": ""Tanzania"",
        ""CapitalName"": ""Dar es Salaam"",
        ""CapitalLatitude"": -6.8,
        ""CapitalLongitude"": 39.283333,
        ""CountryCode"": ""TZ"",
        ""ContinentName"": ""Africa""
    }, {
        ""CountryName"": ""Thailand"",
        ""CapitalName"": ""Bangkok"",
        ""CapitalLatitude"": 13.75,
        ""CapitalLongitude"": 100.516667,
        ""CountryCode"": ""TH"",
        ""ContinentName"": ""Asia""
    }, {
        ""CountryName"": ""Timor-Leste"",
        ""CapitalName"": ""Dili"",
        ""CapitalLatitude"": -8.583333333333334,
        ""CapitalLongitude"": 125.600000,
        ""CountryCode"": ""TL"",
        ""ContinentName"": ""Asia""
    }, {
        ""CountryName"": ""Togo"",
        ""CapitalName"": ""Lome"",
        ""CapitalLatitude"": 6.116666666666666,
        ""CapitalLongitude"": 1.216667,
        ""CountryCode"": ""TG"",
        ""ContinentName"": ""Africa""
    }
]";

            var capitals = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<Capital>>(json);

            foreach (var capital in capitals)
            {
                this.capitals.Add(capital);
            }
            
        }
    }
}
