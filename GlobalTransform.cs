
namespace kadry
{
    public class GlobalTransform
    {

        // Преобразование месяца из цифры в слово..
        public static string TransMonth(int m)
        {
            switch (m)
            {
                case 1: return "январь";
                case 2: return "февраль";
                case 3: return "март";
                case 4: return "апрель";
                case 5: return "май";
                case 6: return "июнь";
                case 7: return "июль";
                case 8: return "август";
                case 9: return "сентябрь";
                case 10: return "октябрь";
                case 11: return "ноябрь";
                case 12: return "декабрь";
                default: return "";
            }

        }

        // Преобразование (сокращение) специальных званий...
        public static string TransformZvanNames(string zv)
        {
            System.Text.StringBuilder str = new System.Text.StringBuilder(zv);
            str.Replace("Рядовой полиции", "ряд.пол.");
            str.Replace("Младший сержант полиции", "мл.с-т пол.");
            str.Replace("Сержант полиции", "с-т пол.");
            str.Replace("Старший сержант полиции", "ст.с-т пол.");
            str.Replace("Старшина полиции", "старшина пол.");
            str.Replace("Прапорщик полиции", "пр-к пол.");
            str.Replace("Старший прапорщик полиции", "ст.пр-к пол.");
            str.Replace("Младший лейтенант полиции", "мл.л-т пол.");
            str.Replace("Лейтенант полиции", "л-т пол.");
            str.Replace("Старший лейтенант полиции", "ст.л-т пол.");
            str.Replace("Капитан полиции", "к-н пол.");
            str.Replace("Майор полиции", "м-р пол.");
            str.Replace("Подполковник полиции", "п.п-к пол.");
            str.Replace("Полковник полиции", "п-к пол.");

            str.Replace("Рядовой милиции", "ряд.мил.");
            str.Replace("Младший сержант милиции", "мл.с-т мил.");
            str.Replace("Сержант милиции", "с-т мил.");
            str.Replace("Старший сержант милиции", "ст.с-т мил.");
            str.Replace("Старшина милиции", "старшина мил.");
            str.Replace("Прапорщик милиции", "пр-к мил.");
            str.Replace("Старший прапорщик милиции", "ст.пр-к мил.");
            str.Replace("Младший лейтенант милиции", "мл.л-т мил.");
            str.Replace("Лейтенант милиции", "л-т мил.");
            str.Replace("Старший лейтенант милиции", "ст.л-т мил.");
            str.Replace("Капитан милиции", "к-н мил.");
            str.Replace("Майор милиции", "м-р мил.");
            str.Replace("Подполковник милиции", "п.п-к мил.");
            str.Replace("Полковник милиции", "п-к мил.");

            str.Replace("Рядовой внутренней службы", "ряд.вн.сл.");
            str.Replace("Младший сержант вн.службы", "мл.с-т вн.сл.");
            str.Replace("Сержант внутренней службы", "с-т вн.сл.");
            str.Replace("Старший сержант вн.службы", "ст.с-т вн.сл.");
            str.Replace("Старшина внутр. службы", "старшина вн.сл.");
            str.Replace("Прапорщик внутр. службы", "пр-к вн.сл.");
            str.Replace("Ст. прапорщик вн. службы", "ст.пр-к вн.сл.");
            str.Replace("Мл. лейтенант вн. службы", "мл.л-т вн.сл.");
            str.Replace("Лейтенант внутр. службы", "л-т вн.сл.");
            str.Replace("Ст. лейтенант вн. службы", "ст.л-т вн.сл.");
            str.Replace("Капитан внутренней службы", "к-н вн.сл.");
            str.Replace("Майор внутренней службы", "м-р вн.сл.");
            str.Replace("Подполковник вн. службы", "п.п-к вн.сл.");
            str.Replace("Полковник вн. службы", "п-к вн.сл.");

            str.Replace("Рядовой юстиции", "ряд.юст.");
            str.Replace("Младший сержант юстиции", "мл.с-т юст.");
            str.Replace("Сержант юстиции", "с-т юст.");
            str.Replace("Старший сержант юстиции", "ст.с-т юст.");
            str.Replace("Старшина юстиции", "старшина юст.");
            str.Replace("Прапорщик юстиции", "пр-к юст.");
            str.Replace("Старший прапорщик юстиции", "ст.пр-к юст.");
            str.Replace("Младший лейтенант юстиции", "мл.л-т юст.");
            str.Replace("Лейтенант юстиции", "л-т юст.");
            str.Replace("Старший лейтенант юстиции", "ст.л-т юст.");
            str.Replace("Капитан юстиции", "к-н юст.");
            str.Replace("Майор юстиции", "м-р юст.");
            str.Replace("Подполковник юстиции", "п.п-к юст.");
            str.Replace("Полковник юстиции", "п-к юст.");
            
            return str.ToString();
        }

        // Преобразование (сокращение) некоторых наименований служб...
        public static string TransformSlzNames(string sl)
        {
            System.Text.StringBuilder str = new System.Text.StringBuilder(sl);
            str.Replace("Уголовный розыск", "УР");
            str.Replace("Тыловое обеспечение", "Тыл");
            str.Replace("Секретариаты", "ОДиР");
            str.Replace("По борьбе с экон.преступлениям", "БЭП");
            str.Replace("Орг.деятельности УУМ", "ОД УУМ");
            str.Replace("Дежурные части", "ДЧ");
            str.Replace("Подразделения связи", "Связь");
            str.Replace("Информационные центры", "ИЦ");
            str.Replace("Спецприемники для адм.арестова", "Спецприемники");
            str.Replace("Центры кинологической службы", "ЦКС");
            str.Replace("Технический надзор ГИБДД", "ГИБДД");
            str.Replace("Специального назначения", "ОМСН");
            str.Replace("Экспертно-криминал.подраздел-я", "ЭКЦ");
            str.Replace("Государственная Авто Инспекция", "ГИБДД");
            str.Replace("Центр врем. изоляции Н/Л прав.", "ЦВСНП");
            str.Replace("Патрульно-постовая служба", "ППС");
            str.Replace("Участковые уполномоч. милиции", "УУМ");
            str.Replace("Строевые подразд-я ДПС", "ДПС ГИБДД");
            str.Replace("Криминальной милиции", "КМ");
            str.Replace("Милиции обществен.безопасности", "МОБ");
            str.Replace("Лицензионно-разрешительная раб", "ЛРР");
            str.Replace("По предупр. правонар.н/летних.", "ПДН");
            str.Replace("Обеспечения и обслуживания", "ОиО");
            str.Replace("Финансовые подразделения", "Фин.");
            str.Replace("По б-бе с прест.на потр.рынке", "БППР");
            str.Replace("Замы нач. ГРПОМ без кадров", "Зам.нач.ГРПОМ");
            str.Replace("Медицинские вытрезвители", "Мед.вытр.");
            str.Replace("По организации дознания", "Дознание");
            str.Replace("Охрана общественного порядка", "ООП");
            str.Replace("Медицинская служба", "МСЧ");
            str.Replace("По налоговым преступлениям", "НП");
            str.Replace("Учебные центры", "ЦПП");
            str.Replace("Правового обеспечения", "ОПО");
            str.Replace("Конвойные подразделения милици", "Конвой");
            str.Replace("ИВС подозреваемых, обвиняемых", "ИВС");
            str.Replace("Начальники ГОМ, РОМ, ПОМ", "Нач.ГРПОМ");
            str.Replace("Замы нач. ГРУОВД по кадрам", "Зам.нач.ГРУОВД по РЛС");
            str.Replace("Начальники ГРУОВД", "Нач.ГРУОВД");
            str.Replace("Кадры-Конвой", "Конвой");
            str.Replace("Отряды милиции особого назнач.", "ОМОН");

            return str.ToString();

        }

        // Преобразование некоторых наименований подразделений...
        public static string TransformPdrNames(string pdr)
        {
            System.Text.StringBuilder str = new System.Text.StringBuilder(pdr);

            str.Replace("УМВД по Ивановской обл.", "Управление МВД России по Ивановской области");
            str.Replace("УВД Ивановской области", "УВД по Ивановской области");
            str.Replace("УВД г. Иванова", "УВД по городу Иваново");
            str.Replace("отдела Штаб", "Штаба");
            str.Replace("отделения Штаб", "Штаба");
            str.Replace("отделения Дежурная часть", "ДЧ");
            str.Replace("группы Дежурная часть", "ДЧ");
            str.Replace("подотдела Дежурная часть", "ДЧ");
            str.Replace("отдела Уголовного розыска", "отдела УР");
            str.Replace("группы Филиал", "филиал");
            str.Replace("отделения Финансовое отделение", "финансовое отделение");
            str.Replace("отдела Финансово-экономический", "ФЭО");
            str.Replace("управления Управление Уголовного розыска", "УУР");
            str.Replace("управления По борьбе с экономическими преступлениями", "УБЭП");
            str.Replace("Эксплуатационно - технический центр", "ЭТЦ");
            str.Replace("Вневедомственной охраны УВД по Ивановской области", "УВО при УВД по Ивановской области");
            str.Replace("управления Организации деятельности УУМ и ПДН", "УОД УУМ и ПДН");
            str.Replace("отдела Технический (-ое,-ая)", "Технического отдела");
            str.Replace("Следственная часть", "СЧ");
            str.Replace("отделения Боевое", "Боевого отделения");
            str.Replace("Отряд милиции специального назначения КМ", "ОМСН КМ");
            str.Replace("Отряд мобильный особого назначения", "ОМОН");
            str.Replace("Отряд специальный быстрого реагирования", "СОБР");
            str.Replace("Экспертно-криминалистический центр ", "ЭКЦ");
            str.Replace("Региональное отд-е информационного обеспечен.ГИБДД", "РОИО ГИБДД");
            str.Replace("Центр временного содержания Н/Л правонарушителей", "ЦВСНП");
            str.Replace("Центр оперативно-розыскной информации", "ЦОРИ КМ");
            str.Replace("группы Взвод", "взвод");
            str.Replace("Оперативно-розыскная часть", "ОРЧ");
            str.Replace("отдела Следственный (ое, ая)", "следственный отдел");
            str.Replace("отделения Следственный (ое, ая)", "следственного отделения");
            str.Replace("группы Следственный (ое, ая)", "следственной группы");
            str.Replace("Следственный (ое, ая)", "следственного подразделения");
            str.Replace("отделения Следственное", "следственного отделения");
            str.Replace("отдела Отдел", "отдела");
            str.Replace("отделения Отделение №", "Отделение №");
            str.Replace("отдела Межрайонный отдел", "межрайонного отдела");
            str.Replace("Центр профессиональной подготовки", "ЦПП");
            str.Replace("группы Комендантская", "комендатской группы");
            str.Replace("Центр по б-бе с правон.в сфере потреб.рынка и ИАЗ", "ЦБППРиИАЗ");
            str.Replace("отделения 1-ое отделение", "1-ое отделение");
            str.Replace("По борьбе с правонарушениями в сфере потреб.рынка", "БППР");
            str.Replace("По борьбе с правонар.в сфере потреб.рынка и ИАЗ", "БППРиИАЗ");
            str.Replace("Борьбы с правонарушениями на потр.рынке и ИАЗ", "БППРиИАЗ");
            str.Replace("подотдела ПЦО", "ПЦО");
            str.Replace("группы ПЦО", "ПЦО");
            str.Replace("РОВД", "ОВД");
            str.Replace("ГОВД", "ОВД");
            str.Replace("подотдела Рота", "Рота");
            str.Replace("подотдельная Рота", "Рота");
            str.Replace("подотдела ", "");
            str.Replace("группы Долевое содержание", "");
            str.Replace("Участковых уполномоченных милиции", "УУМ");
            str.Replace("По делам несовершеннолетних", "ПДН");
            str.Replace("Государственной инспекции БДД", "ГИБДД");
            str.Replace("По борьбе с экономическими преступлениями", "БЭП");
            str.Replace("Борьбы с правонарушениями на потр.рынке и ИАЗ", "БППРиИАЗ");
            str.Replace("группы Бухгалтерия", "бухгалтерия");
            str.Replace("отделения Бухгалтерия", "бухгалтерия");
            str.Replace("отдела Бухгалтерия", "бухгалтерия");
            str.Replace("группы Мобильный", "мобильный");
            str.Replace("отделения Взвод", "взвод");
            str.Replace("ОБКС", "ОБОКПО УВД по городу Иваново");
            str.Replace("группы Правовая", "Правовой группы");
            str.Replace("Обеспечения общественного порядка", "ООП");
            str.Replace("Автотранспортное хозяйство", "АТХ");
            str.Replace("УВД Кинешемского района", "УВД по Кинешемскому МР");
            str.Replace("Отдельный батальон ДПС ГИБДД", "ОБ ДПС ГИБДД");
            str.Replace("Экспертно-криминалистический Центр", "ЭКЦ");
            str.Replace("Отдел Делопроизводства и Режима", "ОДиР");
            
            return str.ToString();
        }

        // Преобразование (сокращение) некоторых наименований должностей...
        public static string TransformDolzNames(string dlz)
        {
            System.Text.StringBuilder str = new System.Text.StringBuilder(dlz);

            str.Replace("Старший инспектор по особым поручениям", "Ст.инспектор по ОП");
            str.Replace("Старший оперуполномоченный", "Ст. оперуполномоченный");
            str.Replace("Участковый уполномоченный полиции", "УУП");
            return str.ToString();
        }

        // Преобразование статуса резервистов...
        public static string TransResComment(string c)
        {
            System.Text.StringBuilder str = new System.Text.StringBuilder(c);

            str.Replace("зачислен(а) в распоряж", "зачислен в распоряжение начальника УМВД.");
            str.Replace("декретный отпуск", "находится в отпуске по уходу за ребенком.");
            str.Replace("зачислен(а) в резерв", "зачислен в распоряжение начальника УМВД.");
            
            return str.ToString();
        }


        // ------------- кодификатор падежей ----------------
        // 0 - Именительный (Кто,что)
        // 1 - Родительный (Кого, Чего)
        // 2 - Дательный (Кому, Чему)

        // Преобразование Фамилий (по падежам)
        public static string TransFamily(string name, int p)
        {
            switch (p)
            {
                case 1: // Родительный
                    {
                        if (name.Substring(name.Length - 2, 2) == "ов") return name += "а";
                        if (name.Substring(name.Length - 2, 2) == "ев") return name += "а";
                        if (name.Substring(name.Length - 2, 2) == "рг") return name += "а";
                        if (name.Substring(name.Length - 2, 2) == "ин") return name += "а";
                        
                        break;
                    }
                case 2: // Дательный
                    {
                        if (name.Substring(name.Length - 2, 2) == "ов") return name += "у";
                        if (name.Substring(name.Length - 2, 2) == "ев") return name += "у";
                        if (name.Substring(name.Length - 2, 2) == "рг") return name += "у";
                        if (name.Substring(name.Length - 2, 2) == "ин") return name += "у";
                        if (name.Substring(name.Length - 2, 2) == "ич") return name += "у";
                        if (name.Substring(name.Length - 3, 3) == "ина") return name.Replace("ина","иной");
                        if (name.Substring(name.Length - 3, 3) == "кий") return name.Replace("кий", "кому");
                        if (name.Substring(name.Length - 2, 2) == "ек") return name += "у";
                        if (name.Substring(name.Length - 3, 3) == "ова") return name.Replace("ова", "овой");
                        break;
                    }

                default: break;

            }
            return name;
        }

        // Преобразование имен (по падежам)
        public static string TransName(string name, int p)
        {
            switch (p)
            {
                case 2:// Дательный
                    {
                        if (name.Substring(name.Length - 2, 2) == "ей") return name.Replace("ей","ею");
                        if (name.Substring(name.Length - 2, 2) == "ий") return name.Replace("ий", "ию");
                        if (name.Substring(name.Length - 3, 3) == "ана") return name.Replace("ана", "ане");
                        if (name.Substring(name.Length - 3, 3) == "ина") return name.Replace("ина", "ине");
                        if (name.Substring(name.Length - 3, 3) == "ьга") return name.Replace("ьга", "ьге");
                        if (name.Substring(name.Length - 3, 3) == "яна") return name.Replace("яна", "яне");
                        if (name.Substring(name.Length - 3, 3) == "ена") return name.Replace("ена", "ене");
                        if (name.Substring(name.Length - 3, 3) == "орь") return name.Replace("орь", "орю");
                        if (name.Substring(name.Length - 2, 2) == "ир") return name+="у";
                        if (name.Substring(name.Length - 2, 2) == "ил") return name += "у";
                        if (name.Substring(name.Length - 2, 2) == "ан") return name+="у";
                        if (name.Substring(name.Length - 2, 2) == "ел") return name.Replace("ел", "лу");
                        if (name.Substring(name.Length - 2, 2) == "ай") return name.Replace("ай", "аю");
                        if (name.Substring(name.Length - 2, 2) == "др") return name+="у";
                        if (name.Substring(name.Length - 2, 2) == "ин") return name+= "у";
                        if (name.Substring(name.Length - 2, 2) == "ис") return name += "у";
                        if (name.Substring(name.Length - 2, 2) == "тр") return name += "у";
                        if (name.Substring(name.Length - 2, 2) == "ор") return name += "у";
                        if (name.Substring(name.Length - 2, 2) == "ен") return name += "у";
                        if (name.Substring(name.Length - 2, 2) == "ег") return name += "у";
                        if (name.Substring(name.Length - 2, 2) == "еб") return name += "у";
                        if (name.Substring(name.Length - 2, 2) == "ид") return name += "у";
                        if (name.Substring(name.Length - 2, 2) == "ад") return name += "у";
                        if (name.Substring(name.Length - 2, 2) == "ем") return name += "у";
                        if (name.Substring(name.Length - 2, 2) == "им") return name += "у";
                        if (name.Substring(name.Length - 2, 2) == "ия") return name.Replace("ия", "ие");
                        if (name.Substring(name.Length - 2, 2) == "ья") return name.Replace("ья", "ье");
                        if (name.Substring(name.Length - 2, 2) == "ав") return name += "у";
                        if (name.Substring(name.Length - 2, 2) == "ьф") return name += "у";
                        if (name.Substring(name.Length - 3, 3) == "ара") return name.Replace("ара", "аре");
                        if (name.Substring(name.Length - 3, 3) == "ард") return name.Replace("ард", "ару");
                        if (name.Substring(name.Length - 3, 3) == "нна") return name.Replace("нна", "нне");
                        if (name.Substring(name.Length - 3, 3) == "ита") return name.Replace("ита", "ите");

                        
                        break;
                    }

                default: break;

            }
            return name;
        }

        // Преобразование отчеств (по падежам)
        public static string TransLastName(string name, int p)
        {
            switch (p)
            {
                case 2:// Дательный
                    {
                        if (name.Substring(name.Length - 3, 3) == "вич") return name+= "у";
                        if (name.Substring(name.Length - 3, 3) == "вна") return name.Replace("вна", "вне");
                        if (name.Substring(name.Length - 3, 3) == "ьич") return name += "у";
                        break;
                    }

                default: break;

            }
            return name;
        }
        
        // Преобразование должности (по падежам)
        public static string TransDolName(string name, int p)
        {
            switch (p)
            {
                case 2:// Дательный
                    {
                        name = name.Replace("Заместитель", "Заместителю");
                        name = name.Replace("Старший", "Старшему");
                        name = name.Replace("Инспектор", "Инспектору");
                        name = name.Replace("Помощник", "Помощнику");
                        name = name.Replace("Дознователь", "Дознователю");
                        name = name.Replace("снайпер", "снайперу");
                        name = name.Replace("высотник", "высотнику");
                        name = name.Replace("Боец", "Бойцу");

                        if (name == "Начальник УМВД") return name = "Начальнику ";
                        if (name == "Начальник центра") return name = "Начальнику центра";
                        if (name == "Старший оперуполномоченный") return name = "Страшему оперуполномоченному";
                        if (name == "Главный инспектор") return name = "Главному инспектору";
                        if (name == "Оперуполномоченный") return name = "Оперуполномоченному";
                        if (name == "Оперуполномоченный по ОВД") return name = "Оперуполномоченному по ОВД";
                        //if (name == "Инспектор") return name = "Инспектору";
                        //if (name == "Инспектор (дорожно-патрульной службы)") return name = "Инспектору (дорожно-патрульной службы)";
                        if (name == "Старший инспектор (дорожно-патрульной службы)") return name = "Старшему инспектору (дорожно-патрульной службы)";
                        //if (name == "Инспектор по ОП") return name = "Инспектору по ОП";
                        if (name == "Старший инспектор") return name = "Старшему инспектору";
                        if (name == "Участковый уполномоченный милиции") return name = "Участковому уполномоченному милиции";
                        if (name == "Милиционер") return name = "Милиционеру";
                        if (name == "Милиционер-водитель") return name = "Милиционеру-водителю";
                        //if (name == "Инспектор дорожно-патрульной службы") return name = "Инспектору дорожно-патрульной службы";
                        if (name == "Начальник отделения") return name = "Начальнику отделения";
                        if (name == "Начальник отдела") return name = "Начальнику отдела";
                        if (name == "Начальник цикла") return name = "Начальнику цикла";
                        if (name == "Начальник управления") return name = "Начальнику управления";
                        if (name == "Помощник начальника ОВД по кадрам") return name = "Помощнику начальника ОВД по кадрам";
                        //if (name == "Заместитель командира отряда по тылу") return name = "Заместителю командира отряда по тылу";
                        if (name == "Специалист") return name = "Специалисту";
                        if (name == "Следователь") return name = "Следователю";
                        if (name == "Старший следователь") return name = "Старшему следователю";
                        if (name == "Следователь по ОВД") return name = "Следователю по ОВД";
                        if (name == "Зам.начальника управления") return name = "Заместителю начальника управления";
                        if (name == "Зам.начальника отдела") return name = "Заместителю начальника отдела";
                        if (name == "Зам.начальника отделения") return name = "Заместителю начальника отделения";
                        if (name == "Зам.нач-ка отдела") return name = "Заместителю начальника отдела";
                        if (name == "Зам.нач.отдела") return name = "Заместителю начальника отдела";
                        if (name == "Эксперт") return name = "Эксперту";
                        if (name == "Старший эксперт") return name = "Старшему эксперту";
                        //if (name == "Заместитель начальника отдела МВД России") return name = "Заместителю начальника отдела МВД России";
                        if (name == "Старший референт") return name = "Старшему референту";
                        if (name == "Дежурный") return name = "Дежурному";
                        if (name == "Дежурный (по режиму)") return name = "Дежурному (по режиму)";
                        if (name == "Инженер") return name = "Инженеру";
                        if (name == "Инженер (в/н)") return name = "Инженеру";
                        if (name == "Начальник части-врач") return name = "Начальнику части-врачу";
                        if (name == "Полицейский-водитель") return name = "Полицейскому-водителю";
                        if (name == "Полицейский") return name = "Полицейскому";
                        if (name == "Водитель-сотрудник") return name = "Водителю-сотруднику";
                        if (name == "Инженер-программист)") return name = "Инженеру-программисту";
                        //if (name == "Заместитель начальника полиции") return name = "Заместителю начальника полиции";
                        break;;
                    }

                default: break;

            }
            return name;
        }

        // Преобразование Наименования ОВД (Дательный падеж)
        public static string TransOVDNameD(string name)
        {
            System.Text.StringBuilder str = new System.Text.StringBuilder(name);

            str.Replace("УВД Ивановской области", "УВД по Ивановской области");
            str.Replace("Комсомольский РОВД", "Комсомольского ОВД");
            str.Replace("Палехский РОВД", "Палехского ОВД");
            str.Replace("Приволжский РОВД", "Приволжского ОВД");
            str.Replace("Пучежский РОВД", "Пучежского ОВД");
            str.Replace("Юрьевецкий РОВД", "Юрьевецкого ОВД");
            str.Replace("Шуйский РОВД", "Шуйского ОВД");
            str.Replace("Савинский РОВД", "Савинского ОВД");
            str.Replace("Тейковский ГОВД", "Тейковского ОВД");
            str.Replace("Ильинский РОВД", "Ильинского ОВД");
            str.Replace("УВД г.Иванова", "УВД по городу Иваново");
            str.Replace("Верхнеладеховский РОВД", "Верхнеландеховского ОВД");
            str.Replace("Лежневский РОВД", "Лежневского ОВД");
            str.Replace("Фурмановский ГОВД", "Фурмановского ОВД");
            str.Replace("Южский РОВД", "Южского ОВД");
            str.Replace("Вичугский ГОВД", "Вичугского ОВД");
            str.Replace("Гаврилово-Посадский РОВД", "Гаврилово-Посадского ОВД");
            str.Replace("Заволжский РОВД", "Заволжского ОВД");
            str.Replace("Ивановский РОВД", "Ивановского ОВД");
            str.Replace("Лухский РОВД", "Лухского ОВД");

            str.Replace("УМВД по Ивановской обл.", "УМВД России по Ивановской области");
            str.Replace("Отдел МВД РФ Приволжский", "Отдела МВД России \"Приволжский\"");
            str.Replace("Отдел МВД РФ Пучежский", "Отдела МВД России \"Пучежский\"");
            str.Replace("Отдел МВД РФ Шуйский", "Отдела МВД России \"Шуйский\"");
            str.Replace("Отдел МВД РФ Тейковский", "Отдела МВД России \"Тейковский\"");
            str.Replace("УМВД по городу Иваново", "УМВД России по городу Иваново");
            str.Replace("Отдел МВД РФ Фурмановский", "Отдела МВД России \"Фурмановский\"");
            str.Replace("Отдел МВД РФ Южский", "Отдела МВД России \"Южский\"");
            str.Replace("Отдел МВД РФ Вичугский", "Отдела МВД России \"Вичугский\"");
            str.Replace("Отдел МВД РФ Ивановский", "Отдела МВД России \"Ивановский\"");
            str.Replace("Отдел МВД РФ Родниковский", "Отдела МВД России \"Родниковский\"");
            
            return str.ToString();
        }

    }
}
