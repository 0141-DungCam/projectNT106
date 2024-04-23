using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectNT106
{
    class Phong
    {
        private int id { get; set; }
        private List<User> users { get; set; }
        public Phong(int id, List<User> user)
        {
            this.id = id;
            this.users = user;

        }
    }
}
