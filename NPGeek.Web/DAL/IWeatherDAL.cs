using NPGeek.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPGeek.Web.DAL
{
    public interface IWeatherDAL
    {
        List<Weather> GetFiveDayWeatherByParkCode(string parkCode);
    }
}
