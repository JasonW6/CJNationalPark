using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPGeek.Web.Models;

namespace NPGeek.Web.DAL
{
    public interface IParkDAL
    {
        List<NationalPark> GetAllParks();
        NationalPark GetParkByParkCode(string parkCode);
    }
}
