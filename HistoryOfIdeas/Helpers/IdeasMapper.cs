using System.Collections.Generic;
using HistoryOfIdeas.DAL.Entity;

namespace HistoryOfIdeas.Helpers
{
    public static class IdeasMapper
    {
        public static IdeaViewModel MapToViewModel(Idea idea)
        {
            return new IdeaViewModel { Id = idea.Id, Text = idea.Text, UserId = idea.UserId, PublicationTime = idea.PublicationTime.ToString()};
        }

        public static IEnumerable<IdeaViewModel> MapListToViewModels(IEnumerable<Idea> list)
        {
            var resultList = new List<IdeaViewModel>();
            foreach (var idea in list)
            {
                resultList.Add(MapToViewModel(idea));
            }

            return resultList;
        }
    }
}