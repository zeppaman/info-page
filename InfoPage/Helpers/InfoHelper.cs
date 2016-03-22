﻿using InfoPage.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using InfoPage.Model;
using InfoPage.Configuration;
using System.Web;

namespace InfoPage.Helpers
{
    public static class InfoHelper
    {
        public static string GetAssemblyAttribute<T>(Func<T, string> value, Assembly a)
     where T : Attribute
        {
            T attribute = (T)Attribute.GetCustomAttribute(a, typeof(T));
            return value.Invoke(attribute);
        }


        public static AssemblyMetadata GetAssemblyMetadata(Assembly assembly)
        {
            AssemblyMetadata aa = new AssemblyMetadata();
            aa.Title = GetAssemblyAttribute<AssemblyTitleAttribute>(a => (a!=null)?a.Title:"", assembly);
            aa.Copyright = GetAssemblyAttribute<AssemblyCopyrightAttribute>(a => (a!=null)?a.Copyright:"", assembly);
            aa.Version = GetAssemblyAttribute<AssemblyVersionAttribute>(a => (a!=null)?a.Version:"", assembly);
            aa.Description = GetAssemblyAttribute<AssemblyDescriptionAttribute>(a => (a != null) ? a.Description : "", assembly);

            aa.FullName = assembly.FullName;
            AssemblyName an = assembly.GetName();
            aa.Culture = an.CultureInfo.DisplayName;
            aa.Architecture = an.ProcessorArchitecture.ToString();
            aa.PublicKeyToken = System.Text.Encoding.ASCII.GetString(an.GetPublicKeyToken());
            aa.Version = (String.IsNullOrEmpty(aa.Version))? an.Version.ToString():aa.Version;
            return aa;
        }

        public static List<AssemblyMetadata> GetLoadedAssemblies()
        {

            List<AssemblyMetadata> result = new List<AssemblyMetadata>();
            foreach (System.Reflection.AssemblyName an in System.Reflection.Assembly.GetExecutingAssembly().GetReferencedAssemblies())
            {
                System.Reflection.Assembly asm = System.Reflection.Assembly.Load(an.ToString());

                result.Add(GetAssemblyMetadata(asm));
            }
            return result;
        }


        public static string GetMarkdownContent(string path)
        {
            string content = File.ReadAllText(path);
            return CommonMark.CommonMarkConverter.Convert(content, new CommonMark.CommonMarkSettings()
                {
                    OutputFormat = CommonMark.OutputFormat.Html
                });
        }

        public static InfoPageModel GetInfoPage(InfoPageConfiguration conf)
        {
            InfoPageModel ip = new InfoPageModel();
            ip.MainAssembly = GetAssemblyMetadata(conf.MainAssembly);
            ip.LoadedAssemblies = GetLoadedAssemblies();
            ip.Conf = conf;
            if(conf.ShowInfo)
            {
                ip.Info = GetMarkdownContent(conf.InfoPath);
            }

            if (conf.ShowLicense)
            {
                ip.License = GetMarkdownContent(conf.LicensePath);
            }

            if (conf.ShowChangeLog)
            {
                ip.ChangeLogs = GetMarkdownContent(conf.ChangeLogPath);
            }

            return ip;
        }

        public static string ResolveUrl(string path)
        {
            return HttpContext.Current.Server.MapPath(path);
        }
    }


}
