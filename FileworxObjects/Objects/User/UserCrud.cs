using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileworxObjects
{
    public partial class User
    {
        public void Update()
        {
            this.DBUpdate();
        }

        public void Delete()
        {
            this.DBDelete();
        }

    }

}
