using Infrastructure.Services;

namespace GamePlay
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