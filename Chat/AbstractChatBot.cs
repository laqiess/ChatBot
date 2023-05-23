/// @autor Ключерев Артемий 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat
{
    // абстрактный класс чатбота
    public abstract class AbstractChatBot
    {
        // абстрактный метод для ответа
        public abstract string answer(string s);
    }
}
