using System;
using System.IO;
using System.Xml;
using System.Reflection;
using System.Collections.Generic;
using Utils;

namespace emulatorCasketWish
{
    //Класс установочных параметров (через XML)
    public static class AppSettings
	{
        private static bool _XMLFoundFlag = false;//сервисный параметр
        private static bool _XMLParametrsFound = true;//сервисный параметр
        private static bool _XMLReadError = false;//сервисный параметр
        private static bool _DebugMode = true;//Задает режим отладки для подробных логов
        private static string uRLAdress = "";
        private static string apiMetod = "";
        private static string apiExtension = "";
        private static string _ErrorParametrs = "";

        public static class Parameters
        {
            public static bool DebugMode
            {
                get
                {
                    return AppSettings._DebugMode;
                }
            }
        }
        
        public static class EmulatorCasketWishParams
        {
            public static string URLAdress
            {
                get
                {
                    return AppSettings.uRLAdress;
                }
            }
            public static string ApiMetod
            {
                get
                {
                    return AppSettings.apiMetod;
                }
            }
            public static string ApiExtension
            {
                get
                {
                    return AppSettings.apiExtension;
                }
            }
        }

        public static class ServiceControl
        {
            public static bool XMLFoundFlag
            {
                get
                {
                    return AppSettings._XMLFoundFlag;
                }
            }
            public static bool XMLParametrsFound
            {
                get
                {
                    return AppSettings._XMLParametrsFound;
                }
            }
            public static bool XMLReadError
            {
                get
                {
                    return AppSettings._XMLReadError;
                }
            }
            public static string ErrorParametrs
            {
                get
                {
                    return AppSettings._ErrorParametrs;
                }
            }
        }

        //Конструктор класса установок

        //Читаем файл настроек
        public static void LoadSettings()
		{
            AppSettings.uRLAdress = "";
            AppSettings.apiMetod = "";
            AppSettings.apiExtension = "";
            
            if ((AppSettings._DebugMode)) Logger.AppendLineToLog("Пытаемся прочесть файл настроек...");

            if (File.Exists(XmlFilePath))
            {
                if (AppSettings._DebugMode) Logger.AppendLineToLog("Файл настроек найден, разбираем");
                XmlDocument xmlDoc = new XmlDocument();
                try
                {
                    xmlDoc.Load(XmlFilePath);
                    //Загружаем XML и разбираем
                    XmlElement xmlElem = xmlDoc.DocumentElement;
                    if (xmlElem.Name.ToString().Trim() != "EmulatorCasketWish")
                        throw new Exception("Неверный конфигурационный файл: " + xmlElem.Name + " !EmulatorCasketWish");
                    foreach (XmlNode node in xmlElem.ChildNodes)
                    {
                        if (node.Name == "URLAdress")
                            AppSettings.uRLAdress = node.InnerText;
                        else if (node.Name == "ApiMetod")
                            AppSettings.apiMetod = node.InnerText;
                        else if (node.Name == "ApiExtension")
                            AppSettings.apiExtension = node.InnerText;
                        if (node.Name.ToString().Trim() == "Debug")
                        {
                            if (node.InnerText.ToString().Trim() == "1") AppSettings._DebugMode = true;
                            else AppSettings._DebugMode = false;
                        }

                    }
                }
                catch (Exception ex)
                {
                    AppSettings._XMLReadError = true;
                    AppSettings._ErrorParametrs = ex.Message;
                }
                if ((!AppSettings._XMLReadError) & (_XMLParametrsFound))
                {
                    if (AppSettings.uRLAdress == "") AppSettings._ErrorParametrs += " URLAdress ";
                    if (AppSettings.apiMetod == "") AppSettings._ErrorParametrs += " ApiMetod ";
                    if (AppSettings.apiExtension == "") AppSettings._ErrorParametrs += " ApiExtension ";
                    if (AppSettings._ErrorParametrs != "") AppSettings._XMLParametrsFound = false;
                    AppSettings._ErrorParametrs = AppSettings._ErrorParametrs.Trim();
                }
            }
            else
            {
                AppSettings._XMLFoundFlag = false;
                AppSettings._XMLParametrsFound = false;
            }
        }

		//Определяем путь к файлу настроек
        private static string XmlFilePath
		{
			get
			{
                return Path.Combine(Logger.BaseDirectory, "AppSettings.xml");
			}
		}
	}
}
