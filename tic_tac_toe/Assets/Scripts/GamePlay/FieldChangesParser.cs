using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Infrastructure.Services
{
    public class FieldChangesParser : IService
    {
        private readonly Winner _winner;
        private readonly Looser _looser;

        public FieldChangesParser(Winner winner, Looser looser)
        {
            _winner = winner;
            _looser = looser;
        }

        public void Refresh()
        {
            if(_winner.TryWin() == false)
                _looser.TryLoose();
        }
    }
}