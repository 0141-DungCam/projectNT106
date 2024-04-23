using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{

    public class Phong
    {
        public int DichV { get; set; }
        public int DichD { get; set; }
        public int DichXD { get; set; }
        public int DichXL { get; set; }
        public string Id { get; set; }
        public List<string> users { get; set; }
        public string HanhDong { get; set; }
        public string luotDanhCo { get; set; }
        public string luotThaiXN { get; set; }
        public int XiNgau { get; set; }
        public List<string> DsUserSS { get; set; }
        public bool status { get; set; }
        public string[] QuanLyBanCo { get; set; }
        public string[] QuanLyChuong { get; set; }
        public Phong(string id, List<string> user)
        {
            this.Id = id;
            this.users = user;

        }
    }
}
