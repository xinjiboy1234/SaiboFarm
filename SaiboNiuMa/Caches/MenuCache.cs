using Microsoft.UI.Xaml.Controls;
using SaiboNiuMa.UI.MarkupInterfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace SaiboNiuMa.Caches
{
    internal static class MenuCache
    {
        internal static Dictionary<string, Type> MenuMap = [];

        //MenuMap[type.Name] = () => (Page) Activator.CreateInstance(type);

        internal static void InitMenu()
        {
            var interfaceType = typeof(IMarkUpMenu);
            // 遍历当前程序集中所有类型
            var pageTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a =>
                {
                    try { return a.GetTypes(); }
                    catch { return []; } // 忽略反射错误的程序集
                })
                .Where(t =>
                    interfaceType.IsAssignableFrom(t) &&
                    !t.IsAbstract &&
                    typeof(Page).IsAssignableFrom(t) &&
                    t.GetConstructor(Type.EmptyTypes) != null // 必须有无参构造函数
                );

            foreach (var type in pageTypes)
            {
                try
                {
                    MenuMap[type.Name] = type;
                }
                catch (Exception ex)
                {
                    // 可加日志记录
                    Debug.WriteLine($"Failed to instantiate {type.Name}: {ex.Message}");
                }
            }
        }
    }
}
