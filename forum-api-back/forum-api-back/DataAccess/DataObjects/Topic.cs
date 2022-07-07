using System;
using System.Collections.Generic;

namespace forum_api_back.DataAccess.DataObjects
{
    public partial class Topic
    {
        public Topic()
        {
            Comments = new HashSet<Comment>();
        }

        public int Idtopic { get; set; }
        public string Titre { get; set; } = null!;
        public string NomUtilisateur { get; set; } = null!;
        public DateTime DateCreation { get; set; }
        public DateTime? DateModification { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

    }
}
