using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resurces
{
    public static class Statuses
    {
        private const string StatusOK           = "Все работает штатно, работы по обновлению не ведутся" ;
        private const string StatusNotAvailable = "Сервис недоступен, ведутся технические работы";
        private const string StatusPlanned      = "Сервис работает штатно, но запланированы работы на :";
        private const string StatusError        = "Ошибка получения статуса (возможно недоступна база данных)";

        public static Dictionary<int, string> StatusesDictionary = new Dictionary<int, string>()
        {
            {0,StatusError},
            {1,StatusOK},
            {2,StatusNotAvailable},
            {3,StatusPlanned}
        };
    }
}
