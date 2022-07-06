﻿using System;
using System.Collections.Generic;

namespace forum_api_back.DataAccess.DataObjects
{
    public partial class Comment
    {
        public int Idcomment { get; set; }
        public string NomUtilisateur { get; set; } = null!;
        public string Contenu { get; set; } = null!;
        public DateOnly DateCreation { get; set; }
        public DateOnly? DateModification { get; set; }
        public int? TopicId { get; set; }

        public virtual Topic? Topic { get; set; }
    }
}
