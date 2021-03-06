﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_1.Watcher;

namespace Task_1.Config
{
    interface IConfigurator
    {
        /// <summary>
        /// Возвращает экземпляр <code>IWatcher</code> с конкретными зависимостями
        /// </summary>
        IWatcher GetWatcher();
    }
}
