using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ShopTARgv24_Ksenia.Core.Dto
{
    public  class ChuckNorrisJokesDto
    {
        public string icon_url { get; set; } = string.Empty;
        public string id { get; set; } = string.Empty;
        public string url { get; set; } = string.Empty;
        public string value { get; set; } = string.Empty;

    }
}
