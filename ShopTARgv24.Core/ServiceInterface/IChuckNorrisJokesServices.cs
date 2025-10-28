using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTARgv24_Ksenia.Core.ServiceInterface
{
    public interface IChuckNorrisJokesServices
    {
        Task <Dto.ChuckNorrisJokesDto?> GetRandomJokeAsync();

    }
}
