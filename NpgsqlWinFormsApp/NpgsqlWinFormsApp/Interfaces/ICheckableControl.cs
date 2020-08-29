﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NpgsqlWinFormsApp.Interfaces
{
    interface ICheckableControl
    {
        /// <summary>
        /// Проверять или нет компонент на то, что данные не пустые.
        /// </summary>
        bool EmptyDataCheck { get; set; }


        /// <summary>
        /// Проверять на наличие данных в компоненте
        /// </summary>
        /// <returns></returns>
        bool Check();
    }
}
