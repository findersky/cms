﻿//
// Copyright 2011 @ fze.NET,All right reserved.
// Name: ArchiveUtility.cs
// author_id: newmin
// Comments:
// -------------------------------------------
// Modify:
//  2011-06-04  newmin  [+]:添加查找栏目的方法
//  2013-03-11  newmin  [+]:Getauthor_idName方法
//

using System;
using JR.Cms.Domain.Interface.User;
using JR.Cms.ServiceDto;

namespace JR.Cms.Library.Utility
{
    public static class ArchiveUtility
    {
        public static string GetOutline(string html, int length)
        {
            var str = RegexHelper.FilterHtml(html);
            return str.Length > length ? str.Substring(0, length) + "..." : str;
        }


        /// <summary>
        /// 判断是否有权限修改文档
        /// </summary>
        /// <param name="siteId"></param>
        /// <param name="publisherId"></param>
        /// <returns></returns>
        public static bool CanModifyArchive(int siteId, int publisherId)
        {
            var user = UserState.Administrator.Current;
            if (user.Id == publisherId || user.IsMaster) return true;
            var pair = user.Roles.GetRole(siteId);
            return pair != null && (pair.GetFlag() & Role.SiteOwner.Flag) != 0;
        }

        /// <summary>
        /// 获取作者名称
        /// </summary>
        /// <param name="publisherId"></param>
        /// <returns></returns>
        public static string GetPublisherName(int publisherId)
        {
            return "-";

            //todo:
            throw new NotImplementedException();

            return "";
            //            if (Regex.IsMatch(author_id, "^[a-z0-9_]+$"))
            //            {
            //                UserBll u = ubll.GetUser(author_id);
            //                if (u != null)
            //                {
            //                    return u.Name;
            //                }
            //            }
            //            return author_id;
        }

        public static string GetFormatedOutline(string outline, string content, int contentLenLimit)
        {
            if (!string.IsNullOrEmpty(outline)) return outline.Replace("\n", "<br />");

            var str = RegexHelper.FilterHtml(content);
            return str.Length > contentLenLimit ? str.Substring(0, contentLenLimit) + "..." : str;
        }
    }
}