using System;
using System.Collections.Generic;

namespace DnDCharacterBuilderData
{
    public partial class User
    {
        public User()
        {
            Characters = new HashSet<Character>();
        }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public virtual ICollection<Character> Characters { get; set; }
    }
}
