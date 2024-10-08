﻿/*
 * Copyright 2012 OPS,All rights reserved!
 * name     : SqlConst
 * author   : newmin
 * date     : 2012/12/22    19:56
 * 
 */

namespace JR.Cms.Library.DataAccess.SQL
{
    /// <summary>
    /// SQL语句常量
    /// </summary>
    public class SqlConst
    {
        public static string ArchiveNotSystemAndHiddenAlias = "schedule_time <= 0 AND (a.flag & 1 AND a.flag ^ 4)";

        /// <summary>
        /// 正常显示的文章
        /// </summary>
        public static string Archive_NotSystemAndHidden = "schedule_time <= 0 AND ($PREFIX_archive.flag & 1 AND $PREFIX_archive.flag ^ 4)";

        /// <summary>
        /// 特殊文档
        /// </summary>
        public const string Archive_Special = "($PREFIX_archive.flag & 1 AND $PREFIX_archive.flag & 2)";
    }
}