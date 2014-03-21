using System.ComponentModel.DataAnnotations;
using HistoryOfIdeas.DAL.Entity.Interface;

namespace HistoryOfIdeas.DAL.Entity
{
    public class Idea:IEntity
    {
        [Key]
        public int Id { set; get; }
        public string Text { set; get; }
        public int UserId { set; get; }

        public virtual User User { set; get; }

    }

    public class IdeaViewModel
    {
        public int Id { set; get; }
        public string Text { set; get; }
        public int UserId { set; get; }
    }
}
