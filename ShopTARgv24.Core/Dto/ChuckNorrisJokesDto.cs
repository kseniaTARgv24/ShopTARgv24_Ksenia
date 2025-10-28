
using System.Text.Json.Serialization;


namespace ShopTARgv24_Ksenia.Core.Dto
{
    public class ChuckNorrisJokesDto
    {

            [JsonPropertyName("icon_url")]
            public string? IconURL { get; set; }
            public string? value { get; set; }
        

    }
}
